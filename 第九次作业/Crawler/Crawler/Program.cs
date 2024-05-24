using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Crawler
{
    class Program
    {
        static ConcurrentBag<string> visitedUrls = new ConcurrentBag<string>();  // 用于存储已经访问过的 URL
        static ConcurrentBag<string> phoneNumbers = new ConcurrentBag<string>();  // 用于存储找到的电话号码

        static void Main(string[] args)
        {
            Console.WriteLine("请输入要搜索的关键字：");
            string keyword = Console.ReadLine();
            Crawl(keyword);
            Console.WriteLine("已完成爬取，找到的电话号码如下：");
            foreach (var phoneNumber in phoneNumbers)
            {
                Console.WriteLine(phoneNumber);
            }
            Console.WriteLine("按任意键退出程序。");
            Console.ReadKey();
        }

        static void Crawl(string keyword)
        {
            int count = 0;
            string[] searchEngines = { "https://www.baidu.com/s?wd=", "https://www.bing.com/search?q=" };
            Parallel.ForEach(searchEngines, searchEngine =>
            {
                string url = searchEngine + keyword;
                ExtractPhoneNumber(url, ref count); // 传递计数器的引用
                if (count == 100) return; // 找到100个电话号码，直接返回
            });
        }


        static void ExtractPhoneNumber(string url, ref int count)
        {
            if (!visitedUrls.Contains(url) && count < 100)
            {
                visitedUrls.Add(url);
                Console.WriteLine("正在访问：" + url);
                string html = DownloadHtml(url);
                if (html != null)
                {
                    string[] phoneNumbersInHtml = FindPhoneNumbers(html);
                    foreach (string phoneNumber in phoneNumbersInHtml)
                    {
                        if (!phoneNumbers.Contains(phoneNumber))
                        {
                            phoneNumbers.Add(phoneNumber);
                            Console.WriteLine("找到电话号码：" + phoneNumber + "，所属的 URL：" + url);
                            count++;
                        }
                        if (count == 100) return; // 找到100个电话号码，直接返回
                    }
                    string[] linksInHtml = FindLinks(html);
                    foreach (string link in linksInHtml)
                    {
                        ExtractPhoneNumber(link, ref count); // 传递计数器的引用
                        if (count == 100) return; // 找到100个电话号码，直接返回
                    }
                }
            }
        }


        static string DownloadHtml(string url)
        {
            try
            {
                WebClient client = new WebClient();
                client.Encoding = System.Text.Encoding.UTF8;
                string html = client.DownloadString(url);
                return html;
            }
            catch (WebException ex)
            {
                Console.WriteLine("访问 URL " + url + " 失败，错误信息：" + ex.Message);
                return null;
            }
        }

        static string[] FindPhoneNumbers(string html)
        {
            string[] patterns = { @"\d{3}-\d{8}", @"\d{4}-\d{7}", @"\d{7,8}", @"\d{3}-\d{4}-\d{4}" };
            List<string> phoneNumbers = new List<string>();
            foreach (string pattern in patterns)
            {
                MatchCollection matches = Regex.Matches(html, pattern);
                foreach (Match match in matches)
                {
                    phoneNumbers.Add(match.Value);
                }
            }
            return phoneNumbers.ToArray();
        }

        static string[] FindLinks(string html)
        {
            MatchCollection matches = Regex.Matches(html, @"<a\s+.*?href=[\""']?([^\""'\s>]+)[^>]*>");
            List<string> links = new List<string>();
            foreach (Match match in matches)
            {
                string link = match.Groups[1].Value;
                if (link.StartsWith("http"))
                {
                    links.Add(link);
                }
            }
            return links.ToArray();
        }
    }
}
