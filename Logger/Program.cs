using System.Drawing;
using Pastel;

namespace Logger
{
    public static class Test
    {
        public static string SetRgb(this string input)
        {
            return input.Pastel(Color.FromArgb(255, 0, 0));
        }
        
        public static string Red(this string input)
        {
            return input.Pastel(Color.FromArgb(255, 0, 0));
        }
        
        public static string Green(this string input)
        {
            return input.Pastel(Color.FromArgb(0, 255, 0));
        }
    }
    
    public class Log
    {
        //
        // Variables
        private string FilePath { get; }
        
        //
        // Colors
        

        //
        // Class
        public enum TypeLog
        {
            All,
            Cmd,
            Log,
        }
        
        private static class PrefixLog
        {
            public const string Ok = "[== OK ==]";
            public const string Nok = "[== NOK ==]";
            public const string Err = "[== ERR ==]";
            public const string Info = "[== INFO ==]";
            public const string Crash = "[== CRASH ==]";
        }
        
        //
        // Constructor
        public Log(string dir = "", string log = "Log")
        {
            var directory = dir == "" ? Directory.GetCurrentDirectory() : dir;
            var folderName = Path.Join(directory, "logs");
            var fileName = log + $"_{GetTimestamp(DateTime.Now)}.log";

            Directory.CreateDirectory(folderName);
            FilePath = Path.Join(folderName ,fileName);
        }

        //
        // Functions
        private static string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy-MM-dd__HH-mm-ss");
        }

        private static void WriteLine(string msg)
        {
            Console.WriteLine(msg);
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
        public void Info(string msg, TypeLog typeLog = TypeLog.All)
        {
            var msgFormat = $"{PrefixLog.Info} : {msg}".Green();
            var logFormat = $"[{DateTime.Now.ToLongTimeString()}] - {msgFormat}";
            
            if (typeLog != TypeLog.Log) WriteLine(msgFormat);
            if (typeLog != TypeLog.Cmd) WriteLog(logFormat);
        }
    }
}