namespace CommonTasks;

/// <summary>
/// Windows common tasks
/// </summary>
public static class TskWindows
{
    /// <summary>
    /// Get user session GUID
    /// </summary>
    /// <returns><see cref="string"></see></returns>
    /// <example>XD5965</example>
    public static string GetGuid() => Environment.UserName;
}

public static class TskDateTime
{
    /// <summary>
    /// Generate and return timestamp
    /// </summary>
    /// <returns><see cref="string"></see> -> yyyy-MM-dd__HH-mm-ss</returns>
    /// <example>2022-07-18__11-37-20</example>
    public static string GetTimestamp() => DateTime.Now.ToString("yyyy-MM-dd__HH-mm-ss");
}