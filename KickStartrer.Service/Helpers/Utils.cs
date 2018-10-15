using System;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace KickStartrer.Service.Helpers
{
    public class Utils
    {
        /// <summary>
        ///     Returns a string containing all errormessages for the specified exception and its inner exceptions
        /// </summary>
        public static string GetErrorMessage(Exception ex, bool includeStacktrace)
        {
            var sb = new StringBuilder();
            GetErrorMessage(ex, includeStacktrace, ref sb);
            return sb.ToString();
        }

        /// <summary>
        ///     Returns a string containing all type- message and stacktrace info for the specified exception and its inner
        ///     exceptions
        /// </summary>
        public static string GetErrorMessage(Exception ex)
        {
            var sb = new StringBuilder();
            GetErrorMessage(ex, true, ref sb);
            return sb.ToString();
        }

        /// <summary>
        ///     Converts IFormFile to bytearray
        /// </summary>
        public static byte[] ConvertToBytes(IFormFile image)
        {
            var reader = new BinaryReader(image.OpenReadStream());
            if (image.Length > 0) return reader.ReadBytes((int) image.Length);
            return null;
        }

        /// <summary>
        ///     Loops through all inner Exceptions and assembles the error text in a stringbuilder
        /// </summary>
        private static void GetErrorMessage(Exception ex, bool includeStacktrace, ref StringBuilder errorText)
        {
            if (ex != null)
            {
                if (includeStacktrace)
                    errorText.Append(
                        $"EXCEPTION TYPE: {ex.GetType()}\nERRORMESSAGE: {ex.Message}\nSTACKTRACE: {ex.StackTrace}");
                else
                    errorText.Append(ex.Message);

                if (ex.InnerException != null)
                {
                    errorText.Append(Environment.NewLine);
                    GetErrorMessage(ex.InnerException, includeStacktrace, ref errorText);
                }
            }
        }
    }
}