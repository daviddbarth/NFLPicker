using System.Text.RegularExpressions;

namespace NFLPicker.Utilities
{
    public static class Validators
    {
        public static bool IsValidBSONId(string id)
        {
            var bsonRegex = new Regex(@"^[a-f\d]{24}$");

            if (bsonRegex.IsMatch(id))
                return true;

            return false;
        }
    }
}
