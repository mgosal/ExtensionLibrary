namespace ExtensionLibrary
{
    /// <summary>
    /// This class contain extension functions for string objects
    /// </summary>
    public static class LeftExtension
    {
        /// <summary>
        /// Returns characters from left of specified length
        /// </summary>
        /// <param name="value">String value</param>
        /// <param name="length">Max number of charaters to return</param>
        /// <returns>Returns string from left</returns>
        public static string Left(this string value, int length)
        {
            return value != null && value.Length > length ? value.Substring(0, length) : value;
        }
    }
}