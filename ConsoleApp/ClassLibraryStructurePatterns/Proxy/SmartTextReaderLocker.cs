using System.Text.RegularExpressions;

namespace ClassLibraryStructurePatterns.Proxy
{
    public class SmartTextReaderLocker : ISmartTextReader
    {
        private ISmartTextReader _reader;
        private readonly string _pattern;

        public SmartTextReaderLocker(ISmartTextReader reader, string pattern)
        {
            _reader = reader;
            _pattern = pattern;
        }

        public char[][] ReadFile(string path)
        {
            if (Regex.IsMatch(path, _pattern))
            {
                Console.WriteLine("Access denied!");
                return new char[0][];
            }

            char[][] result = _reader.ReadFile(path);

            return result;
        }
    }
}
