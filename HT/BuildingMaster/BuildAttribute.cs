using System;

namespace BuildingMaster
{
    [AttributeUsage(AttributeTargets.Class)]
    public class BuildAttribute : Attribute
    {
        public string Name { get; set; }
        public string Organization { get; set; }

        public BuildAttribute(string name, string organization)
        {
            Name = name;
            Organization = organization;
        }
    }
}