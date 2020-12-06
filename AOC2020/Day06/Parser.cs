using System;
using System.Linq;

namespace Day06
{
    public class Parser
    {
        public static CustomsDeclarationForm Parse(string input)
        {
            return new CustomsDeclarationForm(input.ToCharArray());
        }

        public static CustomsGroup ParseGroup(string input)
        {
            var forms = input.Split(Environment.NewLine)
                .Select(line => new CustomsDeclarationForm(line.ToCharArray()));
            return new CustomsGroup(forms);
        }
    }
}
