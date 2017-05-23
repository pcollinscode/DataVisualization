using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DataVisualization.Models;

namespace DataVisualization.Repository
{
  public class ParsedCodeRepository : IParsedCodeRepository
  {
    public ParsedCode Get()
    {
      var file = AppDomain.CurrentDomain.BaseDirectory + @"Data\code_parse_example.txt";

      var result = new ParsedCode
      {
        DateParsed = DateTime.Now,
        Id = 1,
        ProjectName = "greylog",
        Packages = new List<Package>()
      };

      using (var sr = new StreamReader(file))
      {
        while (!sr.EndOfStream)
        {
          var line = sr.ReadLine();

          if (string.IsNullOrEmpty(line))
            continue;

          if (line.StartsWith("package"))
          {
            var split = line.Split('=');
            var package = split[1];
            package = package.Replace("\"", string.Empty);

            //if package already exists
            if (result.Packages.Count(i => i.PackageName == package) > 0)
            {
              continue;
            }

            result.Packages.Add(new Package
            {
              PackageName = package,
              Source = new List<string>()
            });
          }
          else if (line.StartsWith("source"))
          {
            var split = line.Split('|');
            var source = split[0].Trim();
            source = source.Split('=')[1].Replace("\"", string.Empty);
            var target = split[1].Trim();
            target = target.Split('=')[1].Replace("\"", string.Empty);

            //package was not listed so skip
            if (result.Packages.FirstOrDefault(x => x.PackageName == target) == null)
            {
              continue;
            }
            result.Packages.First(x => x.PackageName == target).Source.Add(source);
          }
          else
          {
            throw new ArgumentException("Incorrect file format");
          }
        }
      }

      return result;
    }

    public Task<ParsedCode> Get(int id)
    {
      var result = new ParsedCode
      {
        Id = 1,
        DateParsed = DateTime.Now,
        ProjectName = "Greylog",
        Packages = new List<Package>
        {
          new Package()
        }
      };

      throw new NotImplementedException();
    }

    public Task Create(ParsedCode entity)
    {
      throw new NotImplementedException();
    }

    public Task Delete(int id)
    {
      throw new NotImplementedException();
    }

    public Task<ParsedCode> Update(ParsedCode entity)
    {
      throw new NotImplementedException();
    }
  }
}