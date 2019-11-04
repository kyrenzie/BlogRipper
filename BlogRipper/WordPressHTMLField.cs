using Microsoft.AspNetCore.Html;
using Newtonsoft.Json;

namespace BlogRipper
{
    internal class WordPressHTMLField
    {
        [JsonProperty("rendered")]
        internal string rendered;

    }
}