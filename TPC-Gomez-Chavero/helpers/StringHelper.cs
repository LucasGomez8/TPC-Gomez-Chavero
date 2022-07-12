namespace helpers
{
    public static class StringHelper
    {
        const string TICKET_PREFIX = "000000000000";
        public static string upperStartChar(string str)
        {
            if (str.Length == 0) return str;
            return str.Substring(0, 1).ToUpper() + str.Substring(1).ToLower();
        }

        public static string upperStartCharInAllWords(string str, char separator, string ignore)
        {
            string[] array = str.Split(separator);
            string newString = "";
            foreach (string it in array)
            {
                if (newString.Length != 0)
                {
                    newString += separator;
                }

                if (it != ignore)
                {
                    newString += upperStartChar(it);
                }
                else
                {
                    newString += it;
                }
            }
            return newString;
        }

        public static string completeTicketNumbers(long id, int type)
        {
            string siglas = type == 1 ? "FO-" : "FD-";
            string strID = id.ToString();
            string idAdded = TICKET_PREFIX.Insert(TICKET_PREFIX.Length - strID.Length, strID);
            string removeExtraNumbers = idAdded.Remove(TICKET_PREFIX.Length);
            return siglas + removeExtraNumbers.Insert(4, "-");
        }

        public static long removeTicketNumbers(string ticket)
        {
            string removeSeparator = ticket.Replace("-", "");
            return long.Parse(removeSeparator);
        }
    }
}
