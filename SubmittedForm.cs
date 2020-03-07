using Newtonsoft.Json.Linq;
using Penguin.Cms.Entities;
using Penguin.Forms.Abstractions.Interfaces;
using System;
using System.Collections.Generic;

namespace Penguin.Cms.Forms
{
    public class SubmittedForm : Entity, IFormSubmission
    {
        IEnumerable<IFieldSubmission> IFormSubmission.Fields
        {
            get
            {
                foreach (string Key in this.GetKeys())
                {
                    yield return new SubmittedFormField()
                    {
                        Name = Key,
                        Value = this.GetValue(Key)
                    };
                }
            }
        }

        public string FormData { get; set; } = string.Empty;
        string IFormSubmission.Name => this.Owner.ToString();
        public Guid Owner { get; set; }
        Guid IFormSubmission.Owner => this.Owner;

        public Guid Submitter { get; set; }

        public List<string> GetKeys()
        {
            List<string> toReturn = new List<string>();

            foreach (JProperty prop in JObject.Parse(this.FormData).Properties())
            {
                toReturn.Add(prop.Name);
            }

            return toReturn;
        }

        public string GetValue(string Key)
        {
            return JObject.Parse(this.FormData)[Key].ToString();
        }
    }
}