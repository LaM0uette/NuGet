using System.Runtime.InteropServices;
using System.Drawing;
using Pastel;

namespace Logger;

#region Static

public static class Func
{
    /// <summary>
    /// Generate and return timestamp
    /// </summary>
    /// <returns><see cref="string"/> -> yyyy-MM-dd__HH-mm-ss</returns>
    /// <example>2022-07-18__11-37-20</example>
    public static string GetTimestamp() => DateTime.Now.ToString("yyyy-MM-dd__HH-mm-ss");
}

public static class Rgb
{
    #region Functions

    /// <summary>
    /// Change foreground color of string in the console
    /// </summary>
    /// <param name="input">The string to color</param>
    /// <param name="red">Red value - [0-255]</param>
    /// <param name="green">Green value - [0-255]</param>
    /// <param name="blue">Blue value - [0-255]</param>
    /// <returns><see cref="string"></see> with foreground color</returns>
    private static string SetForegroundRgb(this string input, int red, int green, int blue) =>
        input.Pastel(Color.FromArgb(red, green, blue));
    
    /// <summary>
    /// Change background color of string in the console
    /// </summary>
    /// <param name="input">The string to color</param>
    /// <param name="red">Red value - [0-255]</param>
    /// <param name="green">Green value - [0-255]</param>
    /// <param name="blue">Blue value - [0-255]</param>
    /// <returns><see cref="string"></see> with background color</returns>
    private static string SetBackgroundRgb(this string input, int red, int green, int blue) =>
        input.PastelBg(Color.FromArgb(red, green, blue));

    #endregion
    
    //

    #region Foreground colors

    public static string Blue(this string input) => input.SetForegroundRgb(108, 214, 245);
    public static string Gray(this string input) => input.SetForegroundRgb(80, 80, 80);
    public static string Green(this string input) => input.SetForegroundRgb(44, 168, 65);
    public static string Red(this string input) => input.SetForegroundRgb(235, 66, 71);
    public static string Pink(this string input) => input.SetForegroundRgb(204, 57, 199);

    #endregion
    
    //

    #region Background colors

    public static string BgGreen(this string input) => 
        input.SetForegroundRgb(240, 240, 240).SetBackgroundRgb(44, 168, 65);
    public static string BgRed(this string input) => 
        input.SetForegroundRgb(240, 240, 240).SetBackgroundRgb(235, 66, 71);
    public static string BgPink(this string input) => 
        input.SetForegroundRgb(240, 240, 240).SetBackgroundRgb(204, 57, 199);

    #endregion
}

public static class Draw
{
    #region Class

    private static class Constants
    {
        public const string Author = "Auteur  ";
        public const string Version = "Version ";
    }

    #endregion
    
    //

    #region Func

    private static void MillisecondSleep(this int time)
    {
        Thread.Sleep(time);
    }
    
    private static void SecondSleep(this int time)
    {
        Thread.Sleep(time*1000);
    }

    #endregion
    
    //

    #region Init

    public static void DrawStart(this Log log, string logo, string author, string version)
    {
        if (log.SilentMode) return;
        
        log.VoidGreen(logo);
        log.Description($"\t{Constants.Author}", author);
        log.Description($"\t{Constants.Version}", version);
        log.Space();
        
        1.SecondSleep();
    }
    
    public static void DrawEnd(this Log log, string author, string version)
    {
        if (log.SilentMode) return;
        
        log.SeparatorLight();
        log.Description($"{Constants.Author}", author);
        log.Description($"{Constants.Version}", version);
        log.DoubleSpace();
        
        1.SecondSleep();
    }

    #endregion
    
    //
    
    public static void DrawParam(this Log log, string msg, params string[] args)
    {
        if (log.SilentMode) return;

        var msgArgs = "";

        var i = 0;
        foreach (var arg in args)
        {
            msgArgs += i == 0 ? $" {arg}" : $"  [{arg}]";
            i++;
        }
        
        log.Param($"{msg}:", msgArgs);
        300.MillisecondSleep();
    }
}

#endregion

//

public class Log
{
    #region Statements

    /// <summary>
    /// Log file path
    /// </summary>
    private string FilePath { get; }

    /// <summary>
    /// Default log type
    /// </summary>
    private TypeLog DefaultTypeLog { get; }
    
    /// <summary>
    /// Default silent mode
    /// </summary>
    public bool SilentMode { get; }

    /// <summary>
    /// Different log types
    /// </summary>
    /// <example>
    /// <see cref="All"></see> => Print in console and write in log file<br/>
    /// <see cref="Cmd"></see> => Only print in console<br/>
    /// <see cref="Log"></see> => Only write in log file<br/>
    /// </example>
    public enum TypeLog
    {
        All,
        Cmd,
        Log,
    }

    /// <summary>
    /// Prefix of different log types
    /// </summary>
    /// <example><see cref="Ok"></see> => [OKK]:<br/>
    /// <see cref="Nok"></see> => [NOK]:
    /// </example>
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
        public const string SepLight = "+++++++++++++++++++++++++++++++++";
    }
    
    /// <summary>
    /// Create an instance of Log
    /// </summary>
    /// <param name="dir">Log file path</param>
    /// <param name="name">Log file name</param>
    /// <param name="typeLog">Log type</param>
    /// <param name="silentMode">Silent mode</param>
    /// <remarks>
    /// <see cref="dir"> - Default => <code>Directory.GetCurrentDirectory()</code></see><br/>
    /// <see cref="name"> - Default => "Log"</see><br/>
    /// <see cref="typeLog"> - Default => TypeLog.All</see><br/>
    /// <see cref="silentMode"> - Default => false</see><br/>
    /// </remarks>
    /// <example><code>var log = new Log(dir: "C:\\Users\\XD5965", name:"Log")</code></example>
    public Log([Optional] string dir, string name = "Log", TypeLog typeLog = TypeLog.All, bool silentMode = false)
    {
        var directory = dir == "" ? Directory.GetCurrentDirectory() : dir;
        var folderName = Path.Join(directory, "logs");
        var fileName = name + $"_{Func.GetTimestamp()}.log";

        Directory.CreateDirectory(folderName);
        FilePath = Path.Join(folderName, fileName);
        DefaultTypeLog = typeLog;
        SilentMode = silentMode;
    }
    
    #endregion

    //

    #region Functions

    /// <summary>
    /// Write txt in log file
    /// </summary>
    /// <param name="msg">Message to add to the log file</param>
    private void WriteLog(string msg)
    {
        using var w = File.AppendText(FilePath);
        w.WriteLine(msg);
    }

    /// <summary>
    /// Check types of log and print/write log
    /// </summary>
    /// <param name="msgFormat">String message formated for console</param>
    /// <param name="logFormat">String message formated for log file</param>
    /// <param name="typeLog"><see cref="TypeLog"></see> => Type of log</param>
    /// <param name="mode">Mode of print log in console<br/>0 for WriteLine<br/>1 for Write</param>
    private void CheckTypeLog([Optional] string msgFormat, [Optional] string logFormat, TypeLog? typeLog, int mode = 0)
    {
        typeLog ??= DefaultTypeLog;
        
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

    #endregion

    //

    #region Logging

    public void Ok(string msg, [Optional] TypeLog? typeLog)
    {
        var msgFormat = $"{$"{PrefixLog.Base} {PrefixLog.Ok}".Green()} {$"{msg}".Green()}";
        var logFormat = $"[{DateTime.Now.ToLongTimeString()}] - {PrefixLog.Ok} {msg}";

        CheckTypeLog(msgFormat, logFormat, typeLog);
    }

    public void Nok(string msg, [Optional] TypeLog? typeLog)
    {
        var msgFormat = $"{$"{PrefixLog.Base} {PrefixLog.Nok}".Red()} {$"{msg}".Red()}";
        var logFormat = $"[{DateTime.Now.ToLongTimeString()}] - {PrefixLog.Nok} {msg}";

        CheckTypeLog(msgFormat, logFormat, typeLog);
    }

    public void Info(string msg, [Optional] TypeLog? typeLog)
    {
        var msgFormat = $"{$"{PrefixLog.Base} {PrefixLog.Info}".Blue()} {msg.Blue()}";
        var logFormat = $"[{DateTime.Now.ToLongTimeString()}] - {PrefixLog.Info} {msg}";

        CheckTypeLog(msgFormat, logFormat, typeLog);
    }

    public void Param(string msg, [Optional] string value, [Optional] TypeLog? typeLog)
    {
        var msgFormat = $"{$"{PrefixLog.Base} {PrefixLog.Param}".Pink()} {$"{msg}".Pink()}{$"{value}".Blue()}";
        var logFormat = $"[{DateTime.Now.ToLongTimeString()}] - {PrefixLog.Param} {msg}{value}";

        CheckTypeLog(msgFormat, logFormat, typeLog);
    }
    
    public void Val(string msg, [Optional] string value, [Optional] TypeLog? typeLog)
    {
        var msgFormat = $"{$"{PrefixLog.Base}".Green()} {$"{PrefixLog.Val[..5]}".BgGreen()}{$": {msg}".Green()}{$"{value}".Blue()}";
        var logFormat = $"[{DateTime.Now.ToLongTimeString()}] - {PrefixLog.Val} {msg}{value}";

        CheckTypeLog(msgFormat, logFormat, typeLog);
    }
    
    public void Err(string msg, [Optional] TypeLog? typeLog)
    {
        var msgFormat = $"{$"{PrefixLog.Base}".Red()} {$"{PrefixLog.Err[..5]}".BgRed()}{$": {msg}".Red()}";
        var logFormat = $"[{DateTime.Now.ToLongTimeString()}] - {PrefixLog.Err} {msg}";

        CheckTypeLog(msgFormat, logFormat, typeLog);
    }
    
    public void Crash(string msg, [Optional] TypeLog? typeLog)
    {
        var msgFormat = $"{$"{PrefixLog.Base}".Red()} {$"{PrefixLog.Crash[..5]}".BgRed()}{$": {msg}".Red()}";
        var logFormat = $"[{DateTime.Now.ToLongTimeString()}] - {PrefixLog.Crash} {msg}";

        CheckTypeLog(msgFormat, logFormat, typeLog);
    }
    
    //
    
    public void Progress(string msg, int v1, int v2, TypeLog? typeLog = TypeLog.Cmd)
    {
        var msgFormat = $"\r{$"{msg}".Blue()} {$"{v1}".Green()}{"/".Blue()}{$"{v2}".Green()}";

        CheckTypeLog(msgFormat, typeLog: typeLog, mode: 1);
    }
    
    public void Void([Optional] string msg, [Optional] TypeLog? typeLog)
    {
        CheckTypeLog(msg, msg, typeLog);
    }
    
    public void VoidBlue([Optional] string msg, [Optional] TypeLog? typeLog)
    {
        var msgFormat = $"{msg}".Blue();

        CheckTypeLog(msgFormat, msg, typeLog);
    }
    
    public void VoidGreen([Optional] string msg, [Optional] TypeLog? typeLog)
    {
        var msgFormat = $"{msg}".Green();

        CheckTypeLog(msgFormat, msg, typeLog);
    }
    
    public void VoidRed([Optional] string msg, [Optional] TypeLog? typeLog)
    {
        var msgFormat = $"{msg}".Red();

        CheckTypeLog(msgFormat, msg, typeLog);
    }
    
    public void VoidPink([Optional] string msg, [Optional] TypeLog? typeLog)
    {
        var msgFormat = $"{msg}".Pink();

        CheckTypeLog(msgFormat, msg, typeLog);
    }
    
    public void Separator([Optional] string msg, [Optional] TypeLog? typeLog)
    {
        var msgFormat = $"\n\n{$"{PrefixLog.Sep}".Gray()} {$"{msg}".Green()} {$"{PrefixLog.Sep}".Gray()}";
        var logFormat = $"\n\n{PrefixLog.Sep} {msg} {PrefixLog.Sep}";

        CheckTypeLog(msgFormat, logFormat, typeLog);
    }
    
    public void SeparatorLight([Optional] string msg, [Optional] TypeLog? typeLog)
    {
        var msgFormat = $"\n\n{$"{PrefixLog.SepLight}".Gray()} {$"{msg}".Green()}";
        var logFormat = $"\n\n{PrefixLog.SepLight} {msg}";

        CheckTypeLog(msgFormat, logFormat, typeLog);
    }
    
    public void Space([Optional] TypeLog? typeLog)
    {
        CheckTypeLog("", "", typeLog);
    }
    
    public void DoubleSpace([Optional] TypeLog? typeLog)
    {
        CheckTypeLog("\n", "\n", typeLog);
    }
    
    //
    
    public void Category(string msg, [Optional] TypeLog? typeLog)
    {
        var msgFormat = $"{msg}:".BgPink();

        CheckTypeLog(msgFormat, msg, typeLog);
    }
    
    public void SubCategory(string title, string msg, [Optional] TypeLog? typeLog)
    {
        var msgFormat = $"   {$"{title}".Pink()}: {$"{msg}".Green()}";
        var logFormat = $"   {title}: {msg}";

        CheckTypeLog(msgFormat, logFormat, typeLog);
    }
    
    public void Description(string title, string msg, [Optional] TypeLog? typeLog)
    {
        var msgFormat = $"{title}: {$"{msg}".Green()}";
        var logFormat = $"{title}: {msg}";

        CheckTypeLog(msgFormat, logFormat, typeLog);
    }

    #endregion
}

public class Dump
{
    #region Statements

    /// <summary>
    /// Dump file path
    /// </summary>
    private string FilePath { get; }

    /// <summary>
    /// Create an instance of Dump
    /// </summary>
    /// <param name="dir">Dump file path</param>
    /// <param name="name">Dump file name</param>
    /// <remarks>
    /// <see cref="dir"> - Default => <code>Directory.GetCurrentDirectory()</code></see><br/>
    /// <see cref="name"> - Default => "Dump"</see><br/>
    /// </remarks>
    /// <example><code>var dump = new Dump(dir: "C:\\Users\\XD5965", name:"Dump")</code></example>
    public Dump(string dir = "", string name = "Dump")
    {
        var directory = dir == "" ? Directory.GetCurrentDirectory() : dir;
        var folderName = Path.Join(directory, "dumps");
        var fileName = name + $"_{Func.GetTimestamp()}.csv";

        Directory.CreateDirectory(folderName);
        FilePath = Path.Join(folderName, fileName);
    }

    #endregion

    //

    #region Functions

    private void WriteDump(string data)
    {
        using var w = File.AppendText(FilePath);
        w.WriteLine(data);
    }

    #endregion
    
    //

    #region Dumpings

    public void String(string data) => WriteDump(data);
    
    public void StringArray(string[] data) => WriteDump(string.Join(";", data));
    
    public void StringList(IEnumerable<string> data) => WriteDump(string.Join(";", data));

    #endregion
}
