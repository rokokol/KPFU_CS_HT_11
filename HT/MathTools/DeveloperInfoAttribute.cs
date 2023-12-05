using System;

namespace MathTools
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class DeveloperInfoAttribute : Attribute
    {
        public DeveloperInfoAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public string Date { get; set; }
    }
}