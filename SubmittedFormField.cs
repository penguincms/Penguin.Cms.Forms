using Penguin.Forms.Abstractions.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Penguin.Cms.Forms
{
    public class SubmittedFormField : IFieldSubmission
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}