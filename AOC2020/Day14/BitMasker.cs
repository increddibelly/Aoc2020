using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Day14
{
    public class BitMasker
    {
        readonly Dictionary<int, long> _data = new Dictionary<int, long>();
        Mask _mask;
        private readonly string[] _input;

        public BitMasker(string[] input)
        {
            _input = input;
        }

        protected long this[int index]
        {
            get { 
                return _data.ContainsKey(index) ? _data[index] : 0;
            }
            set
            {
                if (_data.ContainsKey(index))
                {
                    _data[index] = value;
                }
                else
                {
                    _data.Add(index, value);
                }
            }
        }

        public void SetValue(string input)
        {
            var numbers = input.Replace("mem[", "").Replace("]", "").Split(" = ");
            var addr = int.Parse(numbers[0]);
            var value = long.Parse(numbers[1]);

            _data[addr] = _mask.Apply(value);
        }

        public void SetMask(string input)
        {
            _mask = new Mask(input);
        }

        public long Sum => _data.Values.Sum();

        public long Run()
        {
            foreach (var line in _input)
            {
                if (line.StartsWith("mask"))
                {
                    SetMask(line);
                }
                else
                {
                    SetValue(line);
                }
            }
            return Sum;
        }
    }

    public class Mask
    {
        private readonly string _mask;
        public bool Verbose { get; set; } = false;

        public Mask(string mask)
        {
            _mask = mask.Replace("mask = ", "");
        }

        public long Apply(long input)
        {
            // value:  000000000000000000000000000000001011 (decimal 11)
            // mask:   XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
            // result: 000000000000000000000000000001001001 (decimal 73)
            
            var inputBits = Convert.ToString(input, 2).ToCharArray();
            
            var output = new StringBuilder(_mask.Replace("X","0"));

            for(var readIndex=inputBits.Length-1; readIndex >=0; readIndex--)
            {
                var maskOffset = _mask.Length - inputBits.Length;
                var writeIndex = maskOffset + readIndex;
                switch (_mask[writeIndex])
                {
                    case '1': output[writeIndex] = '1'; break;
                    case '0': output[writeIndex] = '0'; break;
                    case 'X': output[writeIndex] = inputBits[readIndex]; break;
                }
            }

            var result = Convert.ToInt64(output.ToString(), 2);

            if (Verbose)
            {
                Debug.WriteLine(string.Format("value:  {0, 64}", inputBits.ToString()));
                Debug.WriteLine(string.Format("mask:   {0, 64}", _mask.ToString()));
                Debug.WriteLine(string.Format("result: {0, 64}", result.ToString()));
            }

            return result;
        }

        //public List<int> ApplyV2(long addr)
        //{
        //    // value:  000000000000000000000000000000001011 (decimal 11)
        //    // mask:   XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X
        //    // result: 000000000000000000000000000001001001 (decimal 73)

        //    var inputBits = Convert.ToString(addr, 2).ToCharArray();

        //    var maskedAddr = new StringBuilder(_mask.Replace("X", "0"));
        //    var floating = new List<long>();
        //    for (var readIndex = inputBits.Length - 1; readIndex >= 0; readIndex--)
        //    {
        //        var maskOffset = _mask.Length - inputBits.Length;
        //        var writeIndex = maskOffset + readIndex;
        //        switch (_mask[writeIndex])
        //        {
        //            case '1': maskedAddr[writeIndex] = '1'; break;
        //            case '0': maskedAddr[writeIndex] = maskedAddr[writeIndex]; break;
        //            case 'X': floating.Add(writeIndex); break;
        //        }
        //    }

        //    if (!floating.Any())
        //    {
        //        return new List<int> { Convert.ToInt32(maskedAddr.ToString(), 2) };
        //    }

        //    var addresses = new Dictionary<int, StringBuilder>();
        //    var init = maskedAddr.ToString();
        //    // 2 4 8 16 32 64 128 256
        //    for (var listItem = 0; listItem < Math.Pow(2, floating.Count); listItem++)
        //    {
        //        var builder = new StringBuilder(init);
        //        addresses.Add(listItem, builder);
        //    }
        //    foreach (var f in floating) {

        //    }

        //    var result = Convert.ToInt64(maskedAddr.ToString(), 2);

        //    if (Verbose)
        //    {
        //        Debug.WriteLine(string.Format("value:  {0, 64}", inputBits.ToString()));
        //        Debug.WriteLine(string.Format("mask:   {0, 64}", _mask.ToString()));
        //        Debug.WriteLine(string.Format("result: {0, 64}", result.ToString()));
        //    }

        //    return result;
        //}
    }
}
