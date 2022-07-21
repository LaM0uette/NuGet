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
    /// Convert <see cref="int"/> to <see cref="bool"/>
    /// </summary>
    /// <param name="value">A <see cref="int"/> containing the value to convert</param>
    /// <returns>Return true or false</returns>
    /// <example><code>var v = 1.ParseToBool();</code>=> Return True<br/></example>
    /// <example><code>var v = 0.ParseToBool();</code>=> Return False</example>
    public static bool ParseToBool(this int value) => Convert.ToBoolean(value);
    
    /// <summary>
    /// Convert <see cref="string"/> to <see cref="bool"/>
    /// </summary>
    /// <param name="value">A <see cref="string"/> containing the value to convert</param>
    /// <returns>Return true or false (if the <see cref="string"/> is not convertible to <see cref="bool"/>, the default value is false)</returns>
    /// <example><code>var v = "true".ParseToBool();</code>=> Return True<br/></example>
    /// <example><code>var v = "Hey".ParseToBool();</code>=> Return False</example>
    public static bool ParseToBool(this string value) => bool.TryParse(value, out _);

    #endregion
    
    public static bool ParseToChar(this string str) => char.TryParse(str, out _);
}