using CodingChallenge.Data.Attributes;
using System;
using System.Linq;
using System.Reflection;

namespace CodingChallenge.Data.Extensions
{
    public static class EnumExtension
    {
        public static string GetCode(this Enum val)
        {
            var key = val.GetType()
               .GetMember(val.ToString())
               .FirstOrDefault()
               ?.GetCustomAttribute<CodeAttribute>(false)
               ?.Value
               ?? val.ToString();

            return key;
        }
    }
}
