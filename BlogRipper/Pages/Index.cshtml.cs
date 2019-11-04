using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;

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
            //https://www.newtonsoft.com/json/help/html/ParseJsonAny.htm
 
            JArray postArray = JArray.Parse(jsonData); //https://www.newtonsoft.com/json/help/html/ToObjectComplex.htm
            //[] items = postArray.ToObject<WordPressPost[]>();
            
            
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
                /**if (Brand.Contains(" & "))
                {
                    Brand = Brand.Substring(0, Brand.IndexOf("&"));
                }
                **/

                post.Paragraph1 = ps[0].InnerText;
                if (ps.Count >= 2)
                {
                    post.Paragraph2 = ps[1].InnerText;
                }
                else {
                    post.Paragraph2 = "";
                }

                if (ps.Count >= 3)
                { 
                    post.Paragraph3 = replaceLinks(ps[2].InnerXml, 1);
                }
                else
                {
                    post.Paragraph2 = "";
                }


                post.Paragraph4 = "";
                if (ps.Count >= 3)
                {
                    ps[4].InnerXml = addBreak(ps[4].InnerXml);
                    for (int n = 3; n < ps.Count - 1; n++)
                    {
                        post.Paragraph4 += replaceLinks(ps[n].InnerXml, 1);
                    }
                }

                var datestring = StartOfWeek().ToString("MMddyy");
                post.PlanUrl = datestring+'_'+Brand+Extension ;
                post.PrintUrl = datestring+'_'+Brand+"_print"+Extension;

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
        }
        
        public string addBreak(string p)
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

        public string replaceLinks(string v, int mode = 1)
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
            string replaceWith = "http://rab.recas.com/search?channel_id=301&func=search&keywords="+id.PadLeft(6,'0')+'"';
            if (mode != 1)
            {
                Partial = "_MGOPartial";
                replaceWith = "http://mediagrouponlineinc.recas.com/search.mp?show_plan=" + id + "&schema=u&schema1=y" + '"';
                Extension = ".shtml";
            }

            string source = v;

        // Use Regex.Replace for more flexibility. 
        // Replace "the" or "The" with "many" or "Many".
        // using System.Text.RegularExpressions
            source = System.Text.RegularExpressions.Regex.Replace(v, @"http.*app.coopconnect.com.*plan_id=(\d*).*"+'"', LocalReplaceMatchCase, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            return source;

            string LocalReplaceMatchCase(System.Text.RegularExpressions.Match matchExpression)
            {
                // Test whether the match is capitalized
                if (Char.IsUpper(replaceWith.ToCharArray()[0] ))
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