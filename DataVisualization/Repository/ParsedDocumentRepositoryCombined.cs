using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using DataVisualization.Models;

namespace DataVisualization.Repository
{
  public class ParsedDocumentRepositoryCombined : IParsedDocumentationRepository
  {
    private ParsedDocumentation one;
    public ParsedDocumentRepositoryCombined()
    {
      TEST_SETUP();
    }
    private void TEST_SETUP()
    {
      one = new ParsedDocumentation
      {
        Id = 1,
        ProjectName = "Greylog",
        ProjectUrl = "http://docs.graylog.org/en/2.2/",
        PageDatas = new List<PageData>()
      };

      var file = AppDomain.CurrentDomain.BaseDirectory + @"Data\GrayLog_Web_Parse.txt";

      using (var sr = new StreamReader(file))
      {
        while (!sr.EndOfStream)
        {
          var line = sr.ReadLine();

          if (string.IsNullOrEmpty(line) || line.StartsWith("###"))
            continue;

          var splitColon = line.Split('|');

          // this would be the webpage numbering
          if (splitColon.Length == 2)
          {
            one.PageDatas.Add(new PageData
            {
              Url = splitColon[1].Trim(),
              UrlNumber = int.Parse(splitColon[0].Trim()),
              word_counts = new Dictionary<string, int>()
            });
          }
          // this is webpage, word, and count
          else
          {
            var split = line.Split(',');

            var webpageNumber = int.Parse(split[0]);
            var word = split[1];
            var count = int.Parse(split[2]);

            var currentDict = one.PageDatas.First(x => x.UrlNumber == webpageNumber).word_counts;

            if (currentDict.ContainsKey(word))
            {
              currentDict[word] = currentDict[word] + count;
            }
            else
            {
              currentDict.Add(word, count);
            }
          }
        }
      }
    }
    public List<ParsedDocumentation> Get()
    {
      return new List<ParsedDocumentation>
      {
        one
      };
    }

    public ParsedDocumentation Get(int id)
    {
      return one;
    }

    public ParsedDocumentation Create(ParsedDocumentation entity)
    {
      throw new NotImplementedException();
    }

    public void Delete(int id)
    {
      throw new NotImplementedException();
    }

    public ParsedDocumentation Update(ParsedDocumentation entity)
    {
      throw new NotImplementedException();
    }
  }
}