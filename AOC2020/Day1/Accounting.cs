
namespace Day1
{
    public class Accounting
    {
        public AccountingResult Find2020(int[] input)
        {
            foreach (var a in input)
            {
                foreach (var b in input)
                {
                    if (a + b == 2020)
                    {
                        return new AccountingResult
                        {
                            Factors = new[] { a, b }
                        };
                    }
                }
            }
            return null;
        }

        public AccountingResult Find2020_3(int[] input)
        {
            foreach (var c in input)
            {
                foreach (var a in input)
                {
                    foreach (var b in input)
                    {
                        if (a + b + c == 2020)
                        {
                            return new AccountingResult
                            {
                                Factors = new[] { a, b, c }
                            };
                        }
                    }
                }
            }
            return null;
        }
    }


    public class AccountingResult 
    {
        public int[] Factors { get; set; }
        public long Product {  get
            {
                var x = 1;
                foreach (var factor in Factors)
                {
                    x *= factor;
                }
                return x;
            }
        }
    }
}
