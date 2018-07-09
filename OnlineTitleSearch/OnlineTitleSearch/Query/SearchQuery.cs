using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Configuration;
using OnlineTitleSearch.Models;

namespace OnlineTitleSearch.Query
{
    public class SearchQuery : ISearchQuery
    {
        private readonly IConfiguration _configuration;

        public SearchQuery(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetSearchPosition(SearchQueryModel query)
        {


            string search = string.Format(_configuration["SearchEnglineUrl"], HttpUtility.UrlEncode(query.KeyWord), query.ResultSetCount);

            var request = (HttpWebRequest)WebRequest.Create(search);
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var reader = new StreamReader(response.GetResponseStream(), Encoding.ASCII))
                {
                    string html = reader.ReadToEnd();
                    return FindPosition(html, new Uri(query.Website));
                }
            }

        }

        private string FindPosition(string html, Uri url)
        {
            var outputStr = "0";
            var matches = Regex.Matches(html, "<cite.*", RegexOptions.IgnoreCase);

            for (int i = 0; i < matches.Count; i++)
            {
                string match = matches[i].Groups[0].Value;
                if (match.Contains(url.Host))
                    if (outputStr == "0")
                    {
                        outputStr = (i + 1).ToString();
                    }
                    else
                    {
                        outputStr = outputStr + "," + (i + 1).ToString();
                    }
            }

            return outputStr;
        }
    }
}
