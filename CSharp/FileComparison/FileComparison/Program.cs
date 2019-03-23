namespace FileComparison
{
    class Comparer
    {
        protected JsonReader reader;

        public static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            var comparer = new Comparer();

            var FilePathOne = args[0];

            var FilePathTwo = args[1];

            comparer.reader = new JsonReader();
        }
    }
}
