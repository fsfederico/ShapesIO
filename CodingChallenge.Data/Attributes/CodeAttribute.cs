using System;

namespace CodingChallenge.Data.Attributes
{
    public class CodeAttribute : Attribute
    {
        public string Value { get; set; }

        public CodeAttribute(string value) : base() => this.Value = value;
    }

}
