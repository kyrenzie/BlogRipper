using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace BlogRipper.Pages
{
    public class IndexModel : PageModel
    {
        public List<WordPressPost> Posts { get; set; }

        public string Debug { get; set; }
        public string Partial { get; set; }

        public string Extension { get; set; }

        public void OnGet()
        {
            getPosts();
        }

        public void getPosts()
        {
            const string baseurl = "https://promotions.coopconnect.com/wp-json/wp/v2/posts/?per_page=30";
            HttpClient client = new HttpClient();
            var jsonData = client.GetStringAsync(baseurl).Result;
            //https://www.newtonsoft.com/json/help/html/ParseJsonAny.htm+

            //Mode sets which mode the scraper will act in. 1 = Recas Rab Site, 2 = Media Group Online, 3 = Automatically Download last weeks images and set links to them.
            var mode = 3;

            JArray postArray = JArray.Parse(jsonData); //https://www.newtonsoft.com/json/help/html/ToObjectComplex.htm
                                                       //[] items = postArray.ToObject<WordPressPost[]>();

            var date = StartOfWeek().ToString("MMddyy");
            string path = @"C:\Users\kyler\Documents\LSA" + "\\" + date;
            Posts = new List<WordPressPost>();

            for (int i = 0; i < postArray.Count; i++)
            {
                WordPressPost post = new WordPressPost();

                post.Title = postArray[i]["title"]["rendered"].ToString();
                post.Title = post.Title.Substring(0);
                post.Date = DateTime.Parse(postArray[i]["date"].ToString());


                //get a dom object of the post html
                System.Xml.XmlDocument postDom = new System.Xml.XmlDocument();
                postDom.LoadXml("<div>" + postArray[i]["content"]["rendered"].ToString().Replace("&nbsp;", "&#160;") + "</div>"); // as long as html is well-formed, i.e. XHTML

                /**
                var x = postDom.GetElementsByTagName()
                for (i = 0; i < x.length ;i++) {
                    Debug += x[i].nodeName + ": " + x[i].childNodes[0].nodeValue + "<br>";
                }
                **/
                var ps = postDom.ChildNodes[0].ChildNodes;
                //convert brand names to lower case
                var Brand = post.Title.Substring(0, post.Title.IndexOf(' ')).ToLower();
                //remove any non alphanumeric input
                Regex rgx = new Regex("[^a-zA-Z0-9 -]");
                Brand = rgx.Replace(Brand, "");
                //remove any numbers.
                Brand = Regex.Replace(Brand, @"[\d-]", string.Empty);
                post.Brand = Brand;

                post.Paragraph1 = ps[0].InnerText;
                if (ps.Count >= 2)
                {
                    post.Paragraph2 = ps[1].InnerText;
                }
                else
                {
                    post.Paragraph2 = "";
                }

                if (ps.Count >= 3)
                {
                    post.Paragraph3 = ReplaceLinks(ps[2].InnerXml, mode);
                }
                else
                {
                    post.Paragraph2 = "";
                }


                post.Paragraph4 = "";
                if (ps.Count >= 3)
                {
                    ps[4].InnerXml = AddBreak(ps[4].InnerXml);
                    for (int n = 3; n < ps.Count - 1; n++)
                    {
                        post.Paragraph4 += ReplaceLinks(ps[n].InnerXml, mode);
                    }
                }

                var datestring = StartOfWeek().ToString("MMddyy");

                post.PlanUrl = datestring + '_' + Brand + Extension;
                post.PrintUrl = datestring + '_' + Brand + "_print" + Extension;

                string pTitle = post.Title.ToString();
                if (pTitle.Contains("<br>"))
                {
                    pTitle = pTitle.Substring(0, pTitle.IndexOf("<br>"));
                    post.Title = pTitle;
                }

                if (ps[0].ChildNodes.Count <= 2)
                {
                    post.PlanImage = ps[0].ChildNodes[0].Attributes["src"].Value;
                }

                Posts.Add(post);
            }
            if (mode == 3)
            {
                for (int i = 0; i < 10; i++)
                {
                    Posts[i].PlanImage = "images/" + ImageDownload(Posts[i].PlanImage, Posts[i].Brand, path, date);
                    WriteHTML(path, date, Posts[i]);
                }
            }
        }

        public string AddBreak(string p)
        {
            p = "<br/>" + p;
            return p;
        }

        public static DateTime StartOfWeek()
        {
            DateTime dt = DateTime.Today;
            DayOfWeek startOfWeek = DayOfWeek.Monday;
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public void WriteHTML(string path, string date, WordPressPost Posts)
        {
            string lines = @"<!DOCTYPE html>
            <html lang = 'en'>
            <head>
                <meta http - equiv = ""content - type"" content = ""text / html; charset = utf - 8"" >
                <link rel = ""stylesheet"" type = ""text/css"" media = ""screen"" href = ""/images/newlook/css/main.css"" >
                <link rel = ""stylesheet"" type = ""text/css"" href = ""/images/newlook/css/print.css"" title = ""printpage"" media = ""print"" >
                <link rel = ""stylesheet"" type = ""text/css"" media = ""screen"" href = ""/images/newlook/css/thickbox.css"" >
                <script type = ""text/javascript"" src = ""/images/newlook/js/jquery-1.2.6.min.js"" >
            </script >
                <script type = ""text/javascript"" src = ""/images/newlook/js/thickbox-compressed2.js"" >
            </script >
                <script type = ""text/javascript"" src = ""/images/newlook/js/jquery.newsticker.pack.js"" >
            </script >
                <script type = ""text/javascript"" src = ""/images/searches/javascript/headersearch.js"" >
            </script >
                <script type = ""text/javascript"" src = ""/images/searches/javascript/popupurl.js"" >
            </script >
                <script type = ""text/javascript"" src = ""/images/searches/javascript/searchCookies.js"" >
            </script >
                <script type = ""text/javascript"" src = ""/images/searches/javascript/addEngine.js"" >
            </script >
                <title ></title >
            </head >
            <body >
                <div id = ""pageBackground"" >
                    <div id = ""pageMain"" >
                        <div id = ""headerWrap"" >
                            <a href = ""http://www.rab.com"" ><img src = ""/images/newlook/header/coop-1.jpg"" alt = ""MultiAd Logo"" ></a >
                            <div id = ""headerSearch"" >
                                <form action = """" name = ""search_form"" onsubmit = ""return search_submit(document.search_form);"" target = ""_top"" >
                                    <div>
                                        <input type = ""text"" class=""quickSearchField"" name=""keywords"" value=""Quick Co-op Search"" onfocus=""if (value == 'Quick Co-op Search') {value ='' }"" onblur=""if (value == '') {value = 'Quick Co-op Search' }""> <input type = ""submit"" value=""Search"" class=""headerSearchSubmitButton""> <input type = ""hidden"" name=""search_value"" value=""""> <input type = ""hidden"" name=""find_plan"" value=""""> <input type = ""hidden"" name=""search_field"" value=""""> <input type = ""hidden"" name=""search_type"" value=""""> <input type = ""hidden"" name=""schema"" value=""__schema__""> <input type = ""hidden"" name=""schema1"" value=""__schema1__""> <input type = ""hidden"" name=""quick_search"" value=""1""> <input type = ""hidden"" name=""record_index"" value=""""> <input type = ""hidden"" name=""func"" value="""">
                                    </div>
                                </form><script type = ""text/javascript"" >
            setButtons();
                                </script>
                            </div>
                            <div id = ""headerTabs"" >
                                <ul >
                                    <li>
                                        <a href=""/coop_search_form"">Co-op Advertising Home</a>
                                    </li>
                                    <li>
                                        <a href = ""/search?search_form_type=materials&amp;channel_id=301"" > Ad Material Warehouse</a>
                                    </li>
                                    <li>
                                        <a href = ""/blog/blog_main.html"" > Co-op Sales Leads</a>
                                    </li>
                                    <li>
                                        <a href = ""/training"" > Tutorials </a >

                                                    </li >
                                                </ul >
                                            </div >
                                        </div >
                                    </div>
                                    <div id= ""content"" >
                                        <div id= ""content-inner"" >
                                            <div id= ""alpha"" >
                                                <div id= ""alpha-inner"" >
                                                    <div id= ""entry-2650"" class=""entry-asset asset hentry"">
                                                        <div>&nbsp;</div> 
                                                        <div class=""asset-header"" style="" padding: 10px;"">
                                                    <h1 id = ""page-title"" class=""asset-name entry-title"" style="" margin: 10px 0 5px 0;"">
                                                        <!-- {mmddyy}_{brand}.shtml -->";
            using (FileStream fs = new FileStream(path + "\\" + date + "_" + Posts.Brand + ".html", FileMode.Create))
            {
                using (StreamWriter w = new StreamWriter(fs, Encoding.UTF8))
                {
                    w.WriteLine(lines);
                    w.WriteLine("<a href=\"" + date + "_" + Posts.Brand + ".html\">" + Posts.Title + "</a>");
                    w.WriteLine(@" </h1>
                                <div class=""asset-meta""></div>
                                <div class=""asset-content entry-content"">
                                    <div class=""asset-body"">");
                    w.WriteLine("<img src=\"images/" + date + "_" + Posts.Brand + "_promo.png\"" + "align=\"right\" width=\"288\">");
                    w.WriteLine(@" <br>The Offers:
                                            <br>
                                            <br>
                                            <ul style = ""padding-left:20px;"">
                                                <li style = ""list-style-type:disc;""> ");
                    w.WriteLine(Posts.Paragraph1);
                    w.WriteLine(" </li> <br> </ul> ");
                    w.WriteLine("<p>" + Posts.Paragraph2 + "</p>");
                    w.WriteLine(" <br><br>");
                    w.WriteLine("<p>" + Posts.Paragraph3 + "</p>");
                    w.WriteLine(" <br><br>");
                    w.WriteLine(@"<span class=""noprint"">");
                    w.WriteLine("<p>" + Posts.Paragraph4 + "</p>");
                    w.WriteLine(@"<br>This information is provided by Co>Op Connect to assist you in selling more advertising, both to new and existing clients. Use it to take a complete advertising solution to your local retailers.
                                            <br>
                                            <br> ");
                    w.WriteLine("<a href=\"" + date + "_" + Posts.Brand + "_print.html\">" + "<img alt=\"Print this Promo\" src=\"/blog/images/print_blog.png\"></a>");
                    w.WriteLine(@"                      </span>
                                                    </div >
                                                </div >
                                            </div >
                                        </div >
                                    </div >
                                </div >
                            </div >
                        </div >
                        </div ><!--#include virtual=""/analytics.html""-->
                    </body>
                </html> ");
                }
            }

        }

        public string ImageDownload(string imgURL, string brand, string path, string date)
        {
            var imageString = date + "_" + brand + "_promo.png";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(imgURL), path + "\\" + imageString);
            }
            return imageString;
        }

        public string ReplaceLinks(string v, int mode)
        {

            // var pattern = @"http.*app.coopconnect.com.*plan_id=(?<Identifier>[0-9]*)";
            // var id = Regex.Match(v, pattern).NextMatch();

            Regex expression = new Regex(@"http.*app.coopconnect.com.*plan_id=(?<plan_id>[0-9]*)");
            var results = expression.Matches(v);
            var id = "0";
            foreach (Match match in results)
            {
                id = match.Groups["plan_id"].Value;
            }

            Partial = "_RABPartial";
            Extension = ".html";
            string replaceWith = "http://rab.recas.com/search?channel_id=301&func=search&keywords=" + id.PadLeft(6, '0') + '"';
            if (mode == 2)
            {
                Partial = "_MGOPartial";
                replaceWith = "http://mediagrouponlineinc.recas.com/search.mp?show_plan=" + id + "&schema=u&schema1=y" + '"';
                Extension = ".shtml";
            }

            string source = v;

            // Use Regex.Replace for more flexibility. 
            // Replace "the" or "The" with "many" or "Many".
            // using System.Text.RegularExpressions
            source = System.Text.RegularExpressions.Regex.Replace(v, @"http.*app.coopconnect.com.*plan_id=(\d*).*" + '"', LocalReplaceMatchCase, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            return source;

            string LocalReplaceMatchCase(System.Text.RegularExpressions.Match matchExpression)
            {
                // Test whether the match is capitalized
                if (Char.IsUpper(replaceWith.ToCharArray()[0]))
                {
                    // Capitalize the replacement string
                    System.Text.StringBuilder replacementBuilder = new System.Text.StringBuilder(replaceWith);
                    replacementBuilder[0] = Char.ToUpper(replacementBuilder[0]);
                    return replacementBuilder.ToString();
                }
                else
                {
                    return replaceWith;
                }
            }
        }
    }
}