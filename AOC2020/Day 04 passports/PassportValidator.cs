using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day_04_passports
{
    public class PassportValidator
    {
        public bool Validate(Passport passport, bool advancedValidation = false)
        {
            foreach (var x in Enum.GetValues(typeof(PassportPropertyType)))
            {
                var t = (PassportPropertyType)x;
                
                // optional property does not exist
                if (t == PassportPropertyType.cid)
                    return true;

                // property exists
                var properties = passport.Properties.Where(x => x.PropertyType == t).ToArray();
                if (properties.Length != 1)
                    return false;

                var property = properties.Single();
                if (advancedValidation)
                {
                    if (!Validate(t, property.Value))
                        return false;
                }
            }
            return true;
        }

        public bool Validate(PassportPropertyType type, string value)
        {
            switch (type)
            {
                // byr(Birth Year) - four digits; at least 1920 and at most 2002.
                case PassportPropertyType.byr: 
                    return int.TryParse(value, out var byr) && 
                        byr >= 1920 &&
                        byr <= 2002;
                // iyr(Issue Year) - four digits; at least 2010 and at most 2020.
                case PassportPropertyType.iyr:
                    return int.TryParse(value, out var iyr) && 
                        iyr >= 2010 && 
                        iyr <= 2020;
                // eyr(Expiration Year) - four digits; at least 2020 and at most 2030.
                case PassportPropertyType.eyr:
                    return int.TryParse(value, out var eyr) &&
                        eyr >= 2020 &&
                        eyr <= 2030;
                // hgt(Height) - a number followed by either cm or in:
                // If cm, the number must be at least 150 and at most 193.
                // If in, the number must be at least 59 and at most 76.
                case PassportPropertyType.hgt:
                    if (value.EndsWith("cm"))
                    {
                        return int.TryParse(value.Replace("cm", ""), out var centimeters) &&
                            centimeters >= 150 &&
                            centimeters <= 193;
                    } else if (value.EndsWith("in"))
                    {
                        return int.TryParse(value.Replace("in", ""), out var inches) &&
                            inches >= 59 &&
                            inches <= 76;
                    }
                    return false;
                // hcl(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
                case PassportPropertyType.hcl:
                    return value.StartsWith("#") && 
                        value.Length == 7 && 
                        int.TryParse(value.Substring(1), System.Globalization.NumberStyles.HexNumber, null, out var _);
                
                // ecl(Eye Color) - exactly one of: amb/blu/brn/gry/grn/hzl/oth.
                case PassportPropertyType.ecl:
                    return new[] { "amb", "blu", "brn", "gry", "grn", "hzl", "oth" }.Contains(value);
                
                // pid(Passport ID) - a nine - digit number, including leading zeroes.
                case PassportPropertyType.pid:
                    return value.Length == 9 && int.TryParse(value, out var _);

                // cid(Country ID) - ignored, missing or not.
                case PassportPropertyType.cid:
                    return true;

            }
            return false;
        }

    }
}
