using System.Drawing;
using Pastel;

namespace Logger
{
    public static class Test
    {
        private static string SetRgb(this string input, int red, int green, int blue)
        {
            return input.Pastel(Color.FromArgb(red, green, blue));
        }

        private static string SetRgbBg(this string input, int red, int green, int blue)
        {
            return input.PastelBg(Color.FromArgb(red, green, blue));
        }

        //
        public static string Blue(this string input) => input.SetRgb(108, 214, 245);
        public static string Green(this string input) => input.SetRgb(44, 168, 65);
        public static string Red(this string input) => input.SetRgb(235, 66, 71);
        public static string Pink(this string input) => input.SetRgb(204, 57, 199);
        
        public static string BgGreen(this string input) => input.SetRgb(240, 240, 240).SetRgbBg(44, 168, 65);
        public static string BgRed(this string input) => input.SetRgb(240, 240, 240).SetRgbBg(235, 66, 71);
    }

    public class Log
    {
        //
        // Variables
        private string FilePath { get; }

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
            public const string Base = "|███|";
            
            public const string Ok = "[OKK]:";
            public const string Nok = "[NOK]:";
            public const string Info = "[INF]:";
            public const string Param = "[PRM]:";
            
            public const string Val = "[VAL]:";
            public const string Err = "[ERR]:";
            public const string Crash = "[CRA]:";
        }

        //
        // Constructor
        public Log(string dir = "", string log = "Log")
        {
            var directory = dir == "" ? Directory.GetCurrentDirectory() : dir;
            var folderName = Path.Join(directory, "logs");
            var fileName = log + $"_{GetTimestamp(DateTime.Now)}.log";

            Directory.CreateDirectory(folderName);
            FilePath = Path.Join(folderName, fileName);
        }

        //
        // Functions
        private static string GetTimestamp(DateTime value)
        {
            return value.ToString("yyyy-MM-dd__HH-mm-ss");
        }

        private void WriteLog(string msg)
        {
            using var w = File.AppendText(FilePath);
            w.WriteLine(msg);
        }

        private void CheckTypeLog(string msgFormat = "", string logFormat = "", TypeLog typeLog = TypeLog.All, int mode = 0)
        {
            if (mode == 0)
            {
                if (typeLog != TypeLog.Log) Console.WriteLine(msgFormat);
            }
            else
            {
                if (typeLog != TypeLog.Log) Console.Write(msgFormat);
            }
            
            if (typeLog != TypeLog.Cmd) WriteLog(logFormat);
        }

        //
        // Loging
        public void Ok(string msg, TypeLog typeLog = TypeLog.All)
        {
            var msgFormat = $"{$"{PrefixLog.Base} {PrefixLog.Ok}".Green()} {$"{msg}".Green()}";
            var logFormat = $"[{DateTime.Now.ToLongTimeString()}] - {PrefixLog.Ok} {msg}";

            CheckTypeLog(msgFormat, logFormat, typeLog);
        }

        public void Nok(string msg, TypeLog typeLog = TypeLog.All)
        {
            var msgFormat = $"{$"{PrefixLog.Base} {PrefixLog.Nok}".Red()} {$"{msg}".Red()}";
            var logFormat = $"[{DateTime.Now.ToLongTimeString()}] - {PrefixLog.Nok} {msg}";

            CheckTypeLog(msgFormat, logFormat, typeLog);
        }

        public void Info(string msg, TypeLog typeLog = TypeLog.All)
        {
            var msgFormat = $"{$"{PrefixLog.Base} {PrefixLog.Info}".Blue()} {msg.Blue()}";
            var logFormat = $"[{DateTime.Now.ToLongTimeString()}] - {PrefixLog.Info} {msg}";

            CheckTypeLog(msgFormat, logFormat, typeLog);
        }

        public void Param(string msg, TypeLog typeLog = TypeLog.All)
        {
            var msgFormat = $"{$"{PrefixLog.Base} {PrefixLog.Param}".Pink()} {$"{msg}".Pink()}";
            var logFormat = $"[{DateTime.Now.ToLongTimeString()}] - {PrefixLog.Param} {msg}";

            CheckTypeLog(msgFormat, logFormat, typeLog);
        }
        
        public void Val(string msg, TypeLog typeLog = TypeLog.All)
        {
            var msgFormat = $"{$"{PrefixLog.Base}".Green()} {$"{PrefixLog.Val[..5]}".BgGreen()}{$": {msg}".Green()}";
            var logFormat = $"[{DateTime.Now.ToLongTimeString()}] - {PrefixLog.Val} {msg}";

            CheckTypeLog(msgFormat, logFormat, typeLog);
        }
        
        public void Err(string msg, TypeLog typeLog = TypeLog.All)
        {
            var msgFormat = $"{$"{PrefixLog.Base}".Red()} {$"{PrefixLog.Err[..5]}".BgRed()}{$": {msg}".Red()}";
            var logFormat = $"[{DateTime.Now.ToLongTimeString()}] - {PrefixLog.Err} {msg}";

            CheckTypeLog(msgFormat, logFormat, typeLog);
        }
        
        public void Crash(string msg, TypeLog typeLog = TypeLog.All)
        {
            var msgFormat = $"{$"{PrefixLog.Base}".Red()} {$"{PrefixLog.Crash[..5]}".BgRed()}{$": {msg}".Red()}";
            var logFormat = $"[{DateTime.Now.ToLongTimeString()}] - {PrefixLog.Crash} {msg}";

            CheckTypeLog(msgFormat, logFormat, typeLog);
        }
        
        //
        public void Progress(string msg, int v1, int v2, TypeLog typeLog = TypeLog.Cmd)
        {
            var msgFormat = $"\r{$": {msg}".Blue()} {$"{v1}".Green()}{$"/".Blue()}{$"{v2}".Green()}";

            CheckTypeLog(msgFormat, typeLog: typeLog);
        }
    }
}
