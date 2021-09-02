namespace InverseFizzBuzzGame
{
    public interface IInverseFizzBuzz
    {
        /// <summary>
        /// Returns a textual representation of the shortest numerical sequence that matches the 'FizzBuzz' textual representation
        /// </summary>
        /// <param name="sequence">The input string</param>
        /// <returns></returns>
        string FindShortSequence(string sequence);
    }
}