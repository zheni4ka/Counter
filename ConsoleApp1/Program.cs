namespace ConsoleApp1
{
    internal class Program
    {
        public static class AnalysisFolder
        {
            public static int LetterCount = 0;
            public static int DigitCount = 0;
            public static int WordsCount = 0;
        }

        static void Main(string[] args)
        {
            string[] files = Directory.GetFiles("C:\\Users\\mka.STEP.000\\source\\repos\\ConsoleApp1\\ConsoleApp1", "*.txt");
            Thread[] threads = new Thread[files.Length];

            for(int i = 0; i < files.Length; i++)
            {
                threads[i] = new Thread(TextAnalyse);
                threads[i].Start(File.ReadAllText(files[i]));
            }

            for(int i = 0;i < threads.Length;i++) 
            {
                threads[i].Join();
            }

            Console.WriteLine($"Count of letters: {AnalysisFolder.LetterCount}");
            Console.WriteLine($"Count of digits: {AnalysisFolder.DigitCount}");
            Console.WriteLine($"Count of words: {AnalysisFolder.WordsCount}");
        }

        private static void TextAnalyse(object state)
        {
            string a = (string)state;
            
            AnalysisFolder.LetterCount += a.Where(x => char.IsLetter(x)).Count();
            AnalysisFolder.DigitCount += a.Where(x => char.IsDigit(x)).Count();
            AnalysisFolder.WordsCount += a.Where(x => x == ' ').Count();
            
        }

    }
}