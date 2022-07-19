namespace CommonTasks;

/// <summary>
/// Windows common tasks
/// </summary>
public static class Windows
{
    /// <summary>
    /// Get user session GUID
    /// </summary>
    /// <returns><see cref="string"></see></returns>
    /// <example>XD5965</example>
    public static string GetGuid() => Environment.UserName;
}
