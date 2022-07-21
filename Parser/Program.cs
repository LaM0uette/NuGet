using System.Globalization;

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

    #region Int

    /// <summary>
    /// Convert <see cref="bool"/> to <see cref="int"/>
    /// </summary>
    /// <param name="value">A <see cref="bool"/> containing the value to convert</param>
    /// <returns>Return a <see cref="int"/> value (0 false, 1 true)</returns>
    /// <example><code>var v = false.ParseToInt();</code>=> Return 0</example>
    public static int ParseToInt(this bool value) => Convert.ToInt32(value);
    
    /// <summary>
    /// Convert <see cref="string"/> to <see cref="int"/>
    /// </summary>
    /// <param name="value">A <see cref="string"/> containing the value to convert</param>
    /// <returns>Return a <see cref="int"/> value (if is not convertible, the default value is 0)</returns>
    /// <example><code>var v = "50".ParseToInt();</code>=> Return 50<br/></example>
    /// <example><code>var v = "A".ParseToInt();</code>=> Return 0</example>
    public static int ParseToInt(this string value) => int.TryParse(value, out _) ? int.Parse(value) : 0;

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
    
    /// <summary>
    /// Convert <see cref="sbyte"/> to <see cref="string"/>
    /// </summary>
    /// <param name="value">A <see cref="sbyte"/> containing the value to convert</param>
    /// <returns>Return a <see cref="string"/> value</returns>
    /// <example><code>var v = 1.ParseToString();</code>=> Return "1"</example>
    public static string ParseToString(this sbyte value) => value.ToString();
    
    /// <summary>
    /// Convert <see cref="byte"/> to <see cref="string"/>
    /// </summary>
    /// <param name="value">A <see cref="byte"/> containing the value to convert</param>
    /// <returns>Return a <see cref="string"/> value</returns>
    /// <example><code>var v = 1.ParseToString();</code>=> Return "1"</example>
    public static string ParseToString(this byte value) => value.ToString();
    
    /// <summary>
    /// Convert <see cref="short"/> to <see cref="string"/>
    /// </summary>
    /// <param name="value">A <see cref="short"/> containing the value to convert</param>
    /// <returns>Return a <see cref="string"/> value</returns>
    /// <example><code>var v = 1.ParseToString();</code>=> Return "1"</example>
    public static string ParseToString(this short value) => value.ToString();
    
    /// <summary>
    /// Convert <see cref="ushort"/> to <see cref="string"/>
    /// </summary>
    /// <param name="value">A <see cref="ushort"/> containing the value to convert</param>
    /// <returns>Return a <see cref="string"/> value</returns>
    /// <example><code>var v = 1.ParseToString();</code>=> Return "1"</example>
    public static string ParseToString(this ushort value) => value.ToString();
    
    /// <summary>
    /// Convert <see cref="int"/> to <see cref="string"/>
    /// </summary>
    /// <param name="value">A <see cref="int"/> containing the value to convert</param>
    /// <returns>Return a <see cref="string"/> value</returns>
    /// <example><code>var v = 1.ParseToString();</code>=> Return "1"</example>
    public static string ParseToString(this int value) => value.ToString();
    
    /// <summary>
    /// Convert <see cref="uint"/> to <see cref="string"/>
    /// </summary>
    /// <param name="value">A <see cref="uint"/> containing the value to convert</param>
    /// <returns>Return a <see cref="string"/> value</returns>
    /// <example><code>var v = 1.ParseToString();</code>=> Return "1"</example>
    public static string ParseToString(this uint value) => value.ToString();
    
    /// <summary>
    /// Convert <see cref="long"/> to <see cref="string"/>
    /// </summary>
    /// <param name="value">A <see cref="long"/> containing the value to convert</param>
    /// <returns>Return a <see cref="string"/> value</returns>
    /// <example><code>var v = 1.ParseToString();</code>=> Return "1"</example>
    public static string ParseToString(this long value) => value.ToString();
    
    /// <summary>
    /// Convert <see cref="ulong"/> to <see cref="string"/>
    /// </summary>
    /// <param name="value">A <see cref="ulong"/> containing the value to convert</param>
    /// <returns>Return a <see cref="string"/> value</returns>
    /// <example><code>var v = 1.ParseToString();</code>=> Return "1"</example>
    public static string ParseToString(this ulong value) => value.ToString();
    
    /// <summary>
    /// Convert <see cref="float"/> to <see cref="string"/>
    /// </summary>
    /// <param name="value">A <see cref="float"/> containing the value to convert</param>
    /// <param name="invariant">A <see cref="bool"/> to enable invariant culture</param>
    /// <returns>Return a <see cref="string"/> value</returns>
    /// <example><code>var v = 1.ParseToString();</code>=> Return "1"</example>
    public static string ParseToString(this float value, bool invariant = true) 
        => invariant ? value.ToString(CultureInfo.InvariantCulture) : value.ToString(CultureInfo.CurrentCulture);
    
    /// <summary>
    /// Convert <see cref="double"/> to <see cref="string"/>
    /// </summary>
    /// <param name="value">A <see cref="double"/> containing the value to convert</param>
    /// <param name="invariant">A <see cref="bool"/> to enable invariant culture</param>
    /// <returns>Return a <see cref="string"/> value</returns>
    /// <example><code>var v = 1.ParseToString();</code>=> Return "1"</example>
    public static string ParseToString(this double value, bool invariant = true) 
        => invariant ? value.ToString(CultureInfo.InvariantCulture) : value.ToString(CultureInfo.CurrentCulture);
    
    /// <summary>
    /// Convert <see cref="decimal"/> to <see cref="string"/>
    /// </summary>
    /// <param name="value">A <see cref="decimal"/> containing the value to convert</param>
    /// <param name="invariant">A <see cref="bool"/> to enable invariant culture</param>
    /// <returns>Return a <see cref="string"/> value</returns>
    /// <example><code>var v = 1.ParseToString();</code>=> Return "1"</example>
    public static string ParseToString(this decimal value, bool invariant = true) 
        => invariant ? value.ToString(CultureInfo.InvariantCulture) : value.ToString(CultureInfo.CurrentCulture);

    #endregion
}