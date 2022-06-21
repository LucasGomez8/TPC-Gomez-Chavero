namespace helpers
{
    public static class StringHelper
    {
        public static string upperStartChar(string str)
        {
            if (str.Length == 0) return str;
            return str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
        }
    }
}
