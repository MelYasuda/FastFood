using System;
namespace FastFood
{
    public sealed class Logger
    {
        private static readonly Logger _logger = new Logger();

        private Logger()
        {
        }

        public static Logger GetLogger()
        {
            return _logger;
        }



        public void WriteMessage(dynamic lines)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt", true);
            file.WriteLine(lines);

            file.Close();
        }
    }
}
