using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PwndaGames.PandaFoot.Util
{
    public static class AbbrevationUtility
    {

        private static readonly SortedDictionary<double, string> abbrevations = new SortedDictionary<double, string>
        {
             {1000,"K"},
             {1000000, "M" },
             {1000000000, "B" },
             {1000000000000,"T"}
        };

        public static string AbbreviateNumber(double number)
        {
            for (int i = abbrevations.Count - 1; i >= 0; i--)
            {
                KeyValuePair<double, string> pair = abbrevations.ElementAt(i);
                if (Mathf.Abs((float)number) >= pair.Key)
                {
                    int roundedNumber = Mathf.FloorToInt((float)number / (float)pair.Key);
                    return roundedNumber.ToString() + pair.Value;
                }
            }
            return number.ToString();
        }
    }
}
