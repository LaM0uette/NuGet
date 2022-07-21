namespace Parser;

public static class Parse
{
    #region Bool

    /// <summary>
    /// Convert <see cref="sbyte"/> to <see cref="bool"/>
    /// </summary>
    /// <param name="value">A <see cref="sbyte"/> containing the value to convert</param>
    /// <returns>Return true or false</returns>
    /// <example><code>var v = 1.ParseToBool();</code>=> Return True<br/></example>
    /// <example><code>var v = 0.ParseToBool();</code>=> Return False</example>
    public static bool ParseToBool(this sbyte value) => Convert.ToBoolean(value);
    
    /// <summary>
    /// Convert <see cref="byte"/> to <see cref="bool"/>
    /// </summary>
    /// <param name="value">A <see cref="byte"/> containing the value to convert</param>
    /// <returns>Return true or false</returns>
    /// <example><code>var v = 1.ParseToBool();</code>=> Return True<br/></example>
    /// <example><code>var v = 0.ParseToBool();</code>=> Return False</example>
    public static bool ParseToBool(this byte value) => Convert.ToBoolean(value);

    /// <summary>
    /// Convert <see cref="short"/> to <see cref="bool"/>
    /// </summary>
    /// <param name="value">A <see cref="short"/> containing the value to convert</param>
    /// <returns>Return true or false</returns>
    /// <example><code>var v = 1.ParseToBool();</code>=> Return True<br/></example>
    /// <example><code>var v = 0.ParseToBool();</code>=> Return False</example>
    public static bool ParseToBool(this short value) => Convert.ToBoolean(value);
    
    /// <summary>
    /// Convert <see cref="ushort"/> to <see cref="bool"/>
    /// </summary>
    /// <param name="value">A <see cref="ushort"/> containing the value to convert</param>
    /// <returns>Return true or false</returns>
    /// <example><code>var v = 1.ParseToBool();</code>=> Return True<br/></example>
    /// <example><code>var v = 0.ParseToBool();</code>=> Return False</example>
    public static bool ParseToBool(this ushort value) => Convert.ToBoolean(value);
    
    /// <summary>
    /// Convert <see cref="int"/> to <see cref="bool"/>
    /// </summary>
    /// <param name="value">A <see cref="int"/> containing the value to convert</param>
    /// <returns>Return true or false</returns>
    /// <example><code>var v = 1.ParseToBool();</code>=> Return True<br/></example>
    /// <example><code>var v = 0.ParseToBool();</code>=> Return False</example>
    public static bool ParseToBool(this int value) => Convert.ToBoolean(value);
    
    /// <summary>
    /// Convert <see cref="uint"/> to <see cref="bool"/>
    /// </summary>
    /// <param name="value">A <see cref="uint"/> containing the value to convert</param>
    /// <returns>Return true or false</returns>
    /// <example><code>var v = 1.ParseToBool();</code>=> Return True<br/></example>
    /// <example><code>var v = 0.ParseToBool();</code>=> Return False</example>
    public static bool ParseToBool(this uint value) => Convert.ToBoolean(value);
    
    /// <summary>
    /// Convert <see cref="long"/> to <see cref="bool"/>
    /// </summary>
    /// <param name="value">A <see cref="long"/> containing the value to convert</param>
    /// <returns>Return true or false</returns>
    /// <example><code>var v = 1.ParseToBool();</code>=> Return True<br/></example>
    /// <example><code>var v = 0.ParseToBool();</code>=> Return False</example>
    public static bool ParseToBool(this long value) => Convert.ToBoolean(value);
    
    /// <summary>
    /// Convert <see cref="ulong"/> to <see cref="bool"/>
    /// </summary>
    /// <param name="value">A <see cref="ulong"/> containing the value to convert</param>
    /// <returns>Return true or false</returns>
    /// <example><code>var v = 1.ParseToBool();</code>=> Return True<br/></example>
    /// <example><code>var v = 0.ParseToBool();</code>=> Return False</example>
    public static bool ParseToBool(this ulong value) => Convert.ToBoolean(value);
    
    /// <summary>
    /// Convert <see cref="string"/> to <see cref="bool"/>
    /// </summary>
    /// <param name="value">A <see cref="string"/> containing the value to convert</param>
    /// <returns>Return true or false (if the <see cref="string"/> is not convertible to <see cref="bool"/>, the default value is false)</returns>
    /// <example><code>var v = "true".ParseToBool();</code>=> Return True<br/></example>
    /// <example><code>var v = "Hey".ParseToBool();</code>=> Return False</example>
    public static bool ParseToBool(this string value) => bool.TryParse(value, out _);

    #endregion

    //
    
    #region String

    /// <summary>
    /// Convert <see cref="bool"/> to <see cref="string"/>
    /// </summary>
    /// <param name="value">A <see cref="bool"/> containing the value to convert</param>
    /// <param name="toLower">A <see cref="bool"/> to enable converting <see cref="string"/> to lower<br/>(default value is false)</param>
    /// <returns>Return a <see cref="string"/> value</returns>
    /// <example><code>var v = true.ParseToString(toLower: true);</code>=> Return "True"<br/></example>
    /// <example><code>var v = true.ParseToString();</code>=> Return "true"</example>
    public static string ParseToString(this bool value, bool toLower = false) => toLower ? value.ToString().ToLower() : value.ToString();
    
    /// <summary>
    /// Convert <see cref="char"/> to <see cref="string"/>
    /// </summary>
    /// <param name="value">A <see cref="char"/> containing the value to convert</param>
    /// <param name="toLower">A <see cref="bool"/> to enable converting <see cref="string"/> to lower<br/>(default value is false)</param>
    /// <returns>Return a <see cref="string"/> value</returns>
    /// <example><code>var v = 'É'.ParseToString(toLower: true);</code>=> Return "É"<br/></example>
    /// <example><code>var v = 'É'.ParseToString();</code>=> Return "é"</example>
    public static string ParseToString(this char value, bool toLower = false) => toLower ? value.ToString().ToLower() : value.ToString();

    #endregion
}