using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VPaHMI_lab5.Models
{
    public class RegexMatcher
    {
        public string[] GetMatches(string pattern, string input)
        {
            Regex rg = new(pattern);
            return rg.Matches(input)
                .Cast<Match>()
                .Select(m => m.Value)
                .ToArray();
        }
    }
}