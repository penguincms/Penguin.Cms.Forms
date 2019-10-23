using System.Collections.Generic;

#pragma warning disable CA2227 // Collection properties should be read only
#pragma warning disable IDE1006 // Naming Styles

namespace Penguin.Cms.Forms
{
    public class JsonFormField
    {
        public string className { get; set; }
        public string description { get; set; }
        public string label { get; set; }
        public string name { get; set; }
        public bool required { get; set; }
        public string subtype { get; set; }
        public string type { get; set; }

        public List<Value> values { get; set; } = new List<Value>();
    }

    public class Value
    {
        public string label { get; set; } = string.Empty;
        public bool selected { get; set; }
        public string value { get; set; } = string.Empty;
    }
}

#pragma warning restore IDE1006 // Naming Styles
#pragma warning restore CA2227 // Collection properties should be read only