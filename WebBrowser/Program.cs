using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Diagnostics;
using System.Threading;
using HtmlAgilityPack;
using Microsoft.Azure.Amqp.Framing;
using System.Web;
using System.Text.RegularExpressions;

namespace webBrowser
{
    class Program
    {
        // HttpClient status code:
        //      1) Informational responses (100–199)
        //      2) Successful responses(200–299)
        //      3) Redirects(300–399)
        //      4) Client errors(400–499)
        //      5) Server errors(500–599


        static async Task Main(string[] args)
        {
            // Create a GET request to a website!
            using var client = new HttpClient();

            // Sends a GET request to the specified Uri and returns the response body (simple HTML code from one of my own webpages)!
            string content1 = await client.GetStringAsync("https://rb.gy/ylz6fh");
            Console.WriteLine(content1);

            string inputTAGS = content1;

           // Remove HTML tags which are without any attribute!
           string htmlTAGS = Regex.Replace(inputTAGS, @"(\<(\/)?(\w)*(\d)?\>)", string.Empty);

           // Remove all kind of tags!
           string allTAGS = Regex.Replace(inputTAGS, @"<.*?>", string.Empty);

           Console.WriteLine(htmlTAGS);
           Console.WriteLine(allTAGS);
           Console.ReadLine();
        }
    }
}
