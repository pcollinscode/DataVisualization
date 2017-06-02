function example() {

  var w = 700,
    h = 700,
    r = 450,
    x = d3.scale.linear().range([0, r]),
    y = d3.scale.linear().range([0, r]),
    node,
    root;

  var pack = d3.layout.pack()
    .size([r, r])
    .value(function (d) { return d.size; });

  var vis = d3.select("#puthere")
    .append("svg:svg", "h2")
    //.insert("svg:svg", "h2")
    .attr("width", w)
    .attr("height", h)
    .append("svg:g")
    .attr("transform", "translate(" + (w - r) / 2 + "," + (h - r) / 2 + ")");

  d3.json("./api/visualizationdata/1", function (data) {

    //var data = JSON.parse(data_inc);
    node = root = data.DependencyGroup;

    var nodes = pack.nodes(root);

    vis.selectAll("circle")
      .data(nodes)
      .enter().append("svg:circle")
      .attr("class", function (d) { return d.children ? "parent" : "child"; })
      .attr("cx", function (d) { return d.x; })
      .attr("cy", function (d) { return d.y; })
      .attr("r", function (d) { return d.r; })
      .attr("fill", function (d) {

        var jsonDate = (new Date()).toJSON();
        var backToDate = new Date(jsonDate);

        var _MS_PER_DAY = 1000 * 60 * 60 * 24;

        var modDate = new Date(d.datemodified);

        var age = Math.floor((backToDate - modDate) / _MS_PER_DAY);

        var color = "grey";

        //in days
        if (age < 7) {
          color = "DarkGreen";
        } else if (age < 30) {
          color = "DarkRed";
        } else if (age < 90) {
          color = "Gold";
        } else if (age < 180) {
          color = "Indigo";
        } else if (age < 365) {
          color = "DarkBlue";
        } else {
          color = "grey";
        }

        // put a switch statement here that changes color based off date modified ranges
        //d is the current array element from the JSON file
        return color;
      })
      .on("click", function (d) { return zoom(node == d ? root : d); });

    vis.selectAll("text")
      .data(nodes)
      .enter().append("svg:text")
      .attr("class", function (d) { return d.children ? "parent" : "child"; })
      .attr("x", function (d) { return d.x; })
      .attr("y", function (d) { return d.y; })
      .attr("dy", ".35em")
      .attr("text-anchor", "middle")
      .style("opacity", function (d) { return d.r > 20 ? 1 : 0; })
      .text(function (d) { return d.name; });

    d3.select(window).on("click", function () { zoom(root); });
  });

  function zoom(d, i) {
    var k = r / d.r / 2;
    x.domain([d.x - d.r, d.x + d.r]);
    y.domain([d.y - d.r, d.y + d.r]);

    var t = vis.transition()
      .duration(d3.event.altKey ? 7500 : 750);

    t.selectAll("circle")
      .attr("cx", function (d) { return x(d.x); })
      .attr("cy", function (d) { return y(d.y); })
      .attr("r", function (d) { return k * d.r; });

    t.selectAll("text")
      .attr("x", function (d) { return x(d.x); })
      .attr("y", function (d) { return y(d.y); })
      .style("opacity", function (d) { return k * d.r > 20 ? 1 : 0; });

    node = d;
    d3.event.stopPropagation();
  }
}

function buildDepWheel() {

  d3.json("./api/visualizationdata/3", function (data) {

    var chord = d3.layout.chord()
      .padding(.15)
      .sortChords(d3.descending)
      .matrix(data.DependencyWheel.matrix);

    var innerRadius = Math.min(640, 400) * .39;
    var outerRadius = innerRadius * 1.1;

    var chart = d3.chart.dependencyWheel();

    var svg = d3.select("#depWheel")
      .datum(data.DependencyWheel)
      .call(chart);

    //https://www.visualcinnamon.com/2016/06/orientation-gradient-d3-chord-diagram.html
    //JUST USE THIS ENTIRE CODE INSTEAD OF CURRENT AND REPLACE THE DATA WITH DATA FROM SERVICE

    //Create a gradient definition for each chord
    var grads = svg.append("defs").selectAll("linearGradient")
      .data(chord.chords())
      .enter().append("linearGradient")
      //Create a unique gradient id per chord: e.g. "chordGradient-0-4"
      .attr("id", function (d) { return "chordGradient-" + d.source.index + "-" + d.target.index; })
      //Instead of the object bounding box, use the entire SVG for setting locations
      //in pixel locations instead of percentages (which is more typical)
      .attr("gradientUnits", "userSpaceOnUse")
      //The full mathematical formula to find the x and y locations of the Avenger's source chord
      .attr("x1",
      function (d, i) {
        return innerRadius *
          Math.cos((d.source.endAngle - d.source.startAngle) / 2 + d.source.startAngle - Math.PI / 2);
      })
      .attr("y1",
      function (d, i) {
        return innerRadius *
          Math.sin((d.source.endAngle - d.source.startAngle) / 2 + d.source.startAngle - Math.PI / 2);
      })
      //Find the location of the target Avenger's chord 
      .attr("x2",
      function (d, i) {
        return innerRadius *
          Math.cos((d.target.endAngle - d.target.startAngle) / 2 + d.target.startAngle - Math.PI / 2);
      })
      .attr("y2",
      function (d, i) {
        return innerRadius *
          Math.sin((d.target.endAngle - d.target.startAngle) / 2 + d.target.startAngle - Math.PI / 2);
      });
  });
}

$(document).ready(function () {
  $('#showDepGroup').click(function showDepGroup() {
    $(".dep-group").show();
    $(".dep-wheel").hide();

    $('#showDepGroup').addClass('active');
    $('#showDepWheel').removeClass('active');
  });

  $('#showDepWheel').click(function showDepWheel() {

    buildDepWheel();

    $(".dep-group").hide();
    $(".dep-wheel").show();

    $('#showDepGroup').removeClass('active');
    $('#showDepWheel').addClass('active');
  });
});