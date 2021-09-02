using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InverseFizzBuzzGame
{
    public class InverseFizzBuzz: IInverseFizzBuzz
    {
        private const string SEQUENCE_NOT_FOUND = "Sequence not found.";
        private const string SEPARATOR = ",";
        private const string FIZZ = "fizz";
        private const string BUZZ = "buzz";
        private const string FIZZ_BUZZ = "fizzbuzz";

        private const int DEFAULT_MAXIMUM = 100;

        private List<Tuple<char, int>> GenerateFizzBuzz(int maxItem)
        {
            var maximumValue = maxItem < DEFAULT_MAXIMUM ? maxItem : DEFAULT_MAXIMUM;

            return Enumerable.Range(1, maximumValue)
                            .Where(x => (x % 3 == 0) || (x % 5 == 0))
                            .Select(x => new Tuple<char, int>((x % 15 == 0) ? 'z' : (x % 5 == 0) ? 'b' : 'f', x))
                            .ToList();
        }

        public string FindShortSequence(string sequence)
        {
            // convert string "fizz,buzz,fizzbuzz" to "fbz"
            var searchString = sequence.ToLower().Replace(FIZZ_BUZZ, "z").Replace(FIZZ, "f").Replace(BUZZ, "b").Replace(" ", "").Replace(SEPARATOR, "");
            // generate fizzbuzz string in above format. 
            var fizzBuzz = GenerateFizzBuzz((searchString.Count(x=>x=='z')+1)*15 - 1);
            var fizzBuzzString = string.Concat(fizzBuzz.Select(x => x.Item1));
            var foundEntries = new List<int>();
            // find all entries of searchString in fizzBuzzString
            var foundIndex = fizzBuzzString.IndexOf(searchString);
            while (foundIndex >= 0)
            {
                foundEntries.Add(foundIndex);
                foundIndex = fizzBuzzString.IndexOf(searchString, foundIndex+1);
            }
            if (foundEntries.Count() == 0)
            {
                return SEQUENCE_NOT_FOUND;
            }
            // Search for shortest range
            var minLength = foundEntries.Min(x => fizzBuzz[x + searchString.Length - 1].Item2 - fizzBuzz[x].Item2);
            var minSequence = foundEntries.FirstOrDefault(x => (fizzBuzz[x + searchString.Length - 1].Item2 - fizzBuzz[x].Item2) == minLength);
            // return string of indexes 
            return string.Join(SEPARATOR, Enumerable.Range(fizzBuzz[minSequence].Item2, minLength+1).OrderBy(n => n).ToArray());
        }
    }
}
