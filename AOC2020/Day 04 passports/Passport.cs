using System.Collections.Generic;
using System.Linq;

namespace Day_04_passports
{
    public enum PassportPropertyType
    {
        byr = 1,// (Birth Year)
        iyr,// (Issue Year)
        eyr,// (Expiration Year)
        hgt,// (Height)
        hcl,// (Hair Color)
        ecl,// (Eye Color)
        pid,// (Passport ID)
        cid,// (Country ID)
    };

    public class PassportProperty
    {
        public PassportPropertyType PropertyType { get; set; }
        public string Value { get; set; }
        public override string ToString() => $"{PropertyType}:{Value}";
    }

    public class Passport
    {
        public readonly IEnumerable<PassportProperty> Properties;
        public PassportProperty this[PassportPropertyType type] =>
            Properties.SingleOrDefault(x => x.PropertyType == type);

        public readonly Dictionary<PassportPropertyType, string> Map;

        public Passport(IEnumerable<PassportProperty> properties)
        {
            Properties = properties;
            Map = properties.ToDictionary(x => x.PropertyType, x => x.Value);
        }
    }
}
