namespace Logger
{
    public class Log
    {
        //
        // Variables
        private string FilePath { get; }

        //
        // Class
        public enum TypeLog
        {
            All = 0,
            Cmd = 1,
            Log = 2,
        }

        //
        // Functions
        private static string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy-MM-dd__HH-mm-ss");
        }

        public Log(string dir = "", string log = "Log")
        {
            var directory = dir == "" ? Directory.GetCurrentDirectory() : dir;
            var folderName = Path.Join(directory, "logs");
            var fileName = log + $"_{GetTimestamp(DateTime.Now)}.log";

            Directory.CreateDirectory(folderName);
            FilePath = Path.Join(folderName ,fileName);
        }

        private void WriteLog(string msg)
        {
            using var w = File.AppendText(FilePath);
            {
                w.WriteLine(msg);
            }
        }

        //
        // Loging
        public void Base(string msg)
        {
            Console.WriteLine("Logged : {0}", msg);

            using (var w = File.AppendText(FilePath))
            {
                w.Write("\r\nLog Entry : ");
                w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
                w.WriteLine("  :{0}", msg);
                w.WriteLine("-----------------------------------------------");
            }
        }

        public void Info(string msg, TypeLog typeLog = TypeLog.All)
        {
            if (typeLog != TypeLog.Log)
            {
                Console.WriteLine("Logged : {0}", msg);
            }

            var msgFormat = $"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()} : {msg}";

            if (typeLog != TypeLog.Cmd) WriteLog(msgFormat);
        }
    }
}