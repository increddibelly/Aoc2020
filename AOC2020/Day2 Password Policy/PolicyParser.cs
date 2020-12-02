using Day2_Password_Policy.Rules;
using System;
using System.ComponentModel;
using System.Linq;

namespace Day2_Password_Policy
{
    public enum ParseMethod : byte
    {
        [Description("sled rental place down the street")]
        SledRental = 0,
        [Description("Official Toboggan Corporate Authentication System")]
        OfficialTobogganCorporate = 1
    }

    public class PolicyParser
    {
        public static Policy Parse(string source, ParseMethod mode = ParseMethod.SledRental)
        {
            /*
            1-3 a: abcde
            1-3 b: cdefg
            2-9 c: ccccccccc
            Each line gives the password policy and then the password. 
            The password policy indicates the lowest and highest number of times a given letter must appear for the password to be valid. 
            For example, 1-3 a means that the password must contain a at least 1 time and at most 3 times.
            In the above example, 2 passwords are valid. 
            The middle password, cdefg, is not; it contains no instances of b, but needs at least 1. 
            The first and third passwords are valid: they contain one a or nine c, both within the limits of their respective policies.
             */
            var lines = source.Split(Environment.NewLine);
            var output = new Policy();
            foreach (var line in lines)
            {
                var reqs = new PasswordRequirements();

                var ruleParts = line.Split(" "); // [1-3, a:, abcde]
                var password = new Password { Value = ruleParts.Last() }; // abcde
                var token = ruleParts.Single(x => x.Contains(":")).Replace(":", string.Empty); // a: => a
                var limits = ruleParts[0].Split("-");

                switch (mode)
                {
                    case ParseMethod.SledRental:
                        reqs.Rules.Add(new OccursAtLeastRule(token, int.Parse(limits[0])));
                        reqs.Rules.Add(new OccursAtMostRule(token, int.Parse(limits[1])));
                        break;
                    case ParseMethod.OfficialTobogganCorporate:
                        reqs.Rules.Add(new EitherRule(
                            new OccursAtPositionRule(token, int.Parse(limits[0])),
                            new OccursAtPositionRule(token, int.Parse(limits[1]))));
                        break;
                }

                output.Add(password, reqs);
            }

            return output;
        }
    }
}
