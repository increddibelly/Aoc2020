using System;
using System.Collections.Generic;
using System.Linq;

namespace Day06
{
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
}
