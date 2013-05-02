using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System
{
    public static class HtmlStringUtils
    {

        public static String ToUrl(this string strThis) {
            return StringToUrl(strThis);
        }

        public static String Capitalize(this string strThis) {
            if (string.IsNullOrEmpty(strThis)) {
                return string.Empty;
            }
            char[] a = strThis.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);

        }

        public static String HtmlDecode(this string strThis) {
            if (String.IsNullOrEmpty(strThis)) { return null; }

            Regex regEx = new Regex("<.*?>", RegexOptions.Compiled);
            strThis = regEx.Replace(strThis, "");

            return strThis;
        }

        public static String HtmlDecodeString(string strThis) {
            if (String.IsNullOrEmpty(strThis)) { return null; }

            Regex regEx = new Regex("<.*?>", RegexOptions.Compiled);
            strThis = regEx.Replace(strThis, "");

            return strThis;
        }

        public static String CleanString(String myString) {

            if (String.IsNullOrEmpty(myString)) { return String.Empty; }

            myString = myString.Replace((char)13, ' ');
            myString = myString.Replace((char)10, ' ');
            myString = myString.Replace('\'', ' ');
            return myString;
        }


        ///////////////////////////////////////////////////////////////////////////////////
        // FUNCIONES INTERNAS
        //////////////////////////////////////////////////////////////////////////////

        private static String StringToUrl(String str) {

            if (String.IsNullOrEmpty(str)) { return null; }

            String result = str;
            Regex replace_a_Accents = new Regex("[á|à|ä|â|Á|À|Ä|Â]", RegexOptions.Compiled);
            Regex replace_e_Accents = new Regex("[é|è|ë|ê|É|È|Ë|Ê]", RegexOptions.Compiled);
            Regex replace_i_Accents = new Regex("[í|ì|ï|î|Í|Ì|Ï|Î]", RegexOptions.Compiled);
            Regex replace_o_Accents = new Regex("[ó|ò|ö|ô|Ó|Ò|Ö|Ô]", RegexOptions.Compiled);
            Regex replace_u_Accents = new Regex("[ú|ù|ü|û|Ú|Ù|Ü|Û]", RegexOptions.Compiled);
            Regex replace_n = new Regex("[ñ|Ñ]", RegexOptions.Compiled);
            Regex replace_caracters = new Regex("[^a-zA-z0-9]", RegexOptions.Compiled);

            result = replace_a_Accents.Replace(result, "a");
            result = replace_e_Accents.Replace(result, "e");
            result = replace_i_Accents.Replace(result, "i");
            result = replace_o_Accents.Replace(result, "o");
            result = replace_u_Accents.Replace(result, "u");
            result = replace_n.Replace(result, "n");
            result = replace_caracters.Replace(result, "-");

            return result.ToLower();
        }

    }
}
