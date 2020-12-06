using System;
using System.Collections.Generic;
using System.Linq;

namespace Day06
{
    public class CustomsDeclarationForm
    {
        public char[] Answers { get; }

        public CustomsDeclarationForm(char[] positiveAnswers)
        {
            Answers = positiveAnswers;
        }
    }

    public class CustomsGroup
    {
        private static readonly char[] questions = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        public ICollection<CustomsDeclarationForm> Forms { get; }

        public int Count() => Forms.Sum(form => form.Answers.Length);
        public char[] Distinct() => Forms.SelectMany(form => form.Answers).Distinct().ToArray();
        public char[] All() => questions
                .Where(question => 
                    Forms.All(form => form.Answers.Contains(question)))
                .ToArray();

        public CustomsGroup(IEnumerable<CustomsDeclarationForm> forms)
        {
            Forms = forms.ToArray();
        }
    }

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
