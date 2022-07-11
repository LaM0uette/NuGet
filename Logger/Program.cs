﻿using System.Drawing;
using Pastel;

namespace Logger
{
    public static class Test
    {
        private static string SetRgb(this string input, int red, int green, int blue)
        {
            return input.Pastel(Color.FromArgb(red, green, blue));
        }

        //
        public static string Blue(this string input) => input.SetRgb(108, 214, 245);
        public static string Green(this string input) => input.SetRgb(136, 235, 100);
        public static string Red(this string input) => input.SetRgb(235, 66, 71);
        public static string Pink(this string input) => input.SetRgb(235, 61, 125);
        public static string Purple(this string input) => input.SetRgb(186, 124, 230);
        public static string Yellow(this string input) => input.SetRgb(227, 224, 76);
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
            FilePath = Path.Join(folderName, fileName);
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
            var msgFormat = $"{$"{PrefixLog.Info}".Blue()} : {$"{msg}".Green()}";
            var logFormat = $"[{DateTime.Now.ToLongTimeString()}] - {PrefixLog.Info} : {msg}";

            if (typeLog != TypeLog.Log) WriteLine(msgFormat);
            if (typeLog != TypeLog.Cmd) WriteLog(logFormat);
        }
    }
}