﻿using System.Drawing;
using Pastel;

namespace Logger
{
    #region [Class] - Functions
    
    public static class Func
    {
        /// <summary>
        /// Permet de générer et retourner un timestamp
        /// </summary>
        /// <returns>Retourne un timestamp de type string</returns>
        public static string GetTimestamp() => DateTime.Now.ToString("yyyy-MM-dd__HH-mm-ss");
    }

    #endregion
    
    //
    
    public static class Rgb
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
        public static string Gray(this string input) => input.SetRgb(80, 80, 80);
        public static string Green(this string input) => input.SetRgb(44, 168, 65);
        public static string Red(this string input) => input.SetRgb(235, 66, 71);
        public static string Pink(this string input) => input.SetRgb(204, 57, 199);
        
        public static string BgGreen(this string input) => input.SetRgb(240, 240, 240).SetRgbBg(44, 168, 65);
        public static string BgRed(this string input) => input.SetRgb(240, 240, 240).SetRgbBg(235, 66, 71);
        public static string BgPink(this string input) => input.SetRgb(240, 240, 240).SetRgbBg(204, 57, 199);
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
            
            public const string Sep = "■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■";
        }

        //
        // Constructor
        public Log(string dir = "", string name = "Log")
        {
            var directory = dir == "" ? Directory.GetCurrentDirectory() : dir;
            var folderName = Path.Join(directory, "logs");
            var fileName = name + $"_{Func.GetTimestamp()}.log";

            Directory.CreateDirectory(folderName);
            FilePath = Path.Join(folderName, fileName);
        }

        //
        // Functions
        private void WriteLog(string msg)
        {
            using var w = File.AppendText(FilePath);
            w.WriteLine(msg);
        }

        private void CheckTypeLog(string msgFormat = "", string logFormat = "", TypeLog typeLog = TypeLog.All, int mode = 0)
        {
            switch (mode)
            {
                case 0:
                    if (typeLog != TypeLog.Log) Console.WriteLine(msgFormat);
                    break;
                case 1:
                    if (typeLog != TypeLog.Log) Console.Write(msgFormat);
                    break;
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

        public void Param(string msg, string value = "", TypeLog typeLog = TypeLog.All)
        {
            var msgFormat = $"{$"{PrefixLog.Base} {PrefixLog.Param}".Pink()} {$"{msg}".Pink()}{$"{value}".Blue()}";
            var logFormat = $"[{DateTime.Now.ToLongTimeString()}] - {PrefixLog.Param} {msg}{value}";

            CheckTypeLog(msgFormat, logFormat, typeLog);
        }
        
        public void Val(string msg, string value = "", TypeLog typeLog = TypeLog.All)
        {
            var msgFormat = $"{$"{PrefixLog.Base}".Green()} {$"{PrefixLog.Val[..5]}".BgGreen()}{$": {msg}".Green()}{$"{value}".Blue()}";
            var logFormat = $"[{DateTime.Now.ToLongTimeString()}] - {PrefixLog.Val} {msg}{value}";

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
            var msgFormat = $"\r{$"{msg}".Blue()} {$"{v1}".Green()}{"/".Blue()}{$"{v2}".Green()}";

            CheckTypeLog(msgFormat, typeLog: typeLog, mode: 1);
        }
        
        public void Void(string msg, TypeLog typeLog = TypeLog.All)
        {
            CheckTypeLog(msg, msg, typeLog);
        }
        
        public void VoidBlue(string msg, TypeLog typeLog = TypeLog.All)
        {
            var msgFormat = $"{msg}".Blue();

            CheckTypeLog(msgFormat, msg, typeLog);
        }
        
        public void VoidGreen(string msg, TypeLog typeLog = TypeLog.All)
        {
            var msgFormat = $"{msg}".Green();

            CheckTypeLog(msgFormat, msg, typeLog);
        }
        
        public void VoidRed(string msg, TypeLog typeLog = TypeLog.All)
        {
            var msgFormat = $"{msg}".Red();

            CheckTypeLog(msgFormat, msg, typeLog);
        }
        
        public void VoidPink(string msg, TypeLog typeLog = TypeLog.All)
        {
            var msgFormat = $"{msg}".Pink();

            CheckTypeLog(msgFormat, msg, typeLog);
        }
        
        public void Separator(string msg, TypeLog typeLog = TypeLog.All)
        {
            var msgFormat = $"\n\n{$"{PrefixLog.Sep}".Gray()} {$"{msg}".Green()} {$"{PrefixLog.Sep}".Gray()}";
            var logFormat = $"\n\n{PrefixLog.Sep} {msg} {PrefixLog.Sep}";

            CheckTypeLog(msgFormat, logFormat, typeLog);
        }
        
        //
        public void Category(string msg, TypeLog typeLog = TypeLog.All)
        {
            var msgFormat = $"{msg}:".BgPink();

            CheckTypeLog(msgFormat, msg, typeLog);
        }
        
        public void SubCategory(string title, string msg, TypeLog typeLog = TypeLog.All)
        {
            var msgFormat = $"   {$"{title}".Pink()}: {$"{msg}".Green()}";
            var logFormat = $"   {title}: {msg}";

            CheckTypeLog(msgFormat, logFormat, typeLog);
        }
        
        public void Description(string title, string msg, TypeLog typeLog = TypeLog.All)
        {
            var msgFormat = $"{title}: {$"{msg}".Green()}";
            var logFormat = $"{title}: {msg}";

            CheckTypeLog(msgFormat, logFormat, typeLog);
        }
    }
    
    public class Dump
    {
        //
        // Variables
        private string FilePath { get; }

        //
        // Constructor
        public Dump(string dir = "", string name = "Dump")
        {
            var directory = dir == "" ? Directory.GetCurrentDirectory() : dir;
            var folderName = Path.Join(directory, "dumps");
            var fileName = name + $"_{Func.GetTimestamp()}.csv";

            Directory.CreateDirectory(folderName);
            FilePath = Path.Join(folderName, fileName);
        }

        //
        // Functions
        private void WriteDump(string data)
        {
            using var w = File.AppendText(FilePath);
            w.WriteLine(data);
        }
        
        //
        // Dumps
        public void String(string data) => WriteDump(data);
        
        public void StringArray(string[] data) => WriteDump(string.Join(";", data));
        
        public void StringList(IEnumerable<string> data) => WriteDump(string.Join(";", data));
    }
}

//[Class] - 