using System.Text.RegularExpressions;

namespace PetGreen.Domain.Models
{
    public static class Utils
    {
        /// <summary>
        /// Remove todos os caracteres especiais de um texto
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string RemoveMask(string value)
        {
            return Regex.Replace(value, "[^0-9a-zA-Z]+", "");
        }
    }
}
