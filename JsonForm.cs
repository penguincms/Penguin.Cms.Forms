using Newtonsoft.Json;
using Penguin.Cms.Abstractions.Attributes;
using Penguin.Persistence.Abstractions.Attributes.Control;
using Penguin.Persistence.Abstractions.Attributes.Relations;
using Penguin.Persistence.Abstractions.Attributes.Rendering;
using System.Collections.Generic;

namespace Penguin.Cms.Forms
{
    public class JsonForm : Form
    {
        [NotMapped]
        [DontAllow(DisplayContexts.Any)]
        public List<JsonFormField> Fields => !string.IsNullOrWhiteSpace(this.FormData) ? JsonConvert.DeserializeObject<List<JsonFormField>>(this.FormData) : new List<JsonFormField>();

        [DontAllow(DisplayContexts.Any)]
        public string FormData { get; set; } = string.Empty;

        [DontAllow(DisplayContexts.Edit | DisplayContexts.BatchEdit)]
        [Display(Name = "Friendly Url")]
        [DisplayType("System.String.Url")]
        public override string FriendlyUrl => $"/Form/{this.ExternalId}";

        public override bool IsJsonForm => true;

        public override string Name { get => this.ExternalId; set => this.ExternalId = value; }

        [DontAllow(DisplayContexts.Edit | DisplayContexts.BatchEdit)]
        [Display(Name = "Permanent Url")]
        public override string PermanentUrl => $"/Form/View/{this._Id}";
    }
}