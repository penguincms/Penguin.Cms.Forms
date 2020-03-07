using Penguin.Forms.Abstractions.Interfaces;

namespace Penguin.Cms.Forms
{
    public class SubmittedFormField : IFieldSubmission
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}