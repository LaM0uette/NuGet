namespace Loger
{
    public class Logger
    {
        //
        // Variables
        private string Directory { get; }

        private string LogName { get; }
        
        private string FileName { get; }

        private string FilePath { get; }

        //
        // Functions
        private static string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy-MM-dd__HH-mm-ss");
        }
        
        public Logger(string dir = "", string log = "")
        {
            var timeStamp = GetTimestamp(DateTime.Now);
            
            Directory = dir == "" ? System.IO.Directory.GetCurrentDirectory() : dir;
            LogName = log == "" ? LogName = "Log" : log;
            FileName = LogName + $"_{timeStamp}.log";
            FilePath = Path.Join(Directory, FileName);
        }
        
        //
        // Loging
        public void Log(string message)
        {
            Console.WriteLine("Logged : {0}", message);

            using (var w = File.AppendText(FilePath))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                w.WriteLine("  :{0}", message);
                w.WriteLine("-----------------------------------------------");
            }
        }
    }
}
