using Newtonsoft.Json;
using System.Collections.Generic;

namespace Penguin.Cms.Forms
{
    public class JsonFormField
    {
        [JsonProperty("className")]
        public string ClassName { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("required")]
        public bool Required { get; set; }

        [JsonProperty("subtype")]
        public string Subtype { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("values")]
        public List<JsonFormValue> Values { get; set; } = new List<JsonFormValue>();
    }

    public class JsonFormValue
    {
        [JsonProperty("label")]
        public string Label { get; set; } = string.Empty;

        [JsonProperty("selected")]
        public bool Selected { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; } = string.Empty;
    }
}