using System;
using System.Collections.Generic;
using System.Linq;

namespace Day_04_passports
{
    public static class PassportParser
    {
        public static Passport Parse(string source)
        {
            // eyr:1971 byr:1955 pid:193cm hgt:189cm hcl:#ceb3a1 ecl:grn iyr:2023
            var sources = source.Split(" ");

            var properties = sources.Select(ParseProperty);

            return new Passport(properties);
        }

        public static Passport[] ParseMany(string[] sources)        {
            return sources.Select(Parse).ToArray();
        }

        private static PassportProperty ParseProperty(string property)
        {
            var items = property.Split(":");
            return new PassportProperty
            {
                PropertyType = (PassportPropertyType)Enum.Parse(typeof(PassportPropertyType), items[0]),
                Value = items[1]
            };
        }
    }
}
