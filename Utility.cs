

using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using ICSharpCode.SharpZipLib.BZip2;
using System.Text;

namespace Util
{
    /// <summary>
    /// Just a bunch of utility functions for reuse
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Transform a bzip2 compressed base64 string to a list
        /// of integers seperated by a seperator
        /// </summary>
        /// <param name="encoded"></param>
        /// <param name="separator"></param>
        /// <returns>Decompressed and decode list of integers </returns>
        public static IEnumerable<int> DecodeBase64(string encoded, char separator)
        {
            return DecodeBase64AsStr(encoded, separator)
                .Select(x => int.Parse(x))
                .ToList();
        }

        /// <summary>
        /// Transform a bzip2 compressed base64 string to a list
        /// of strings seperated by a seperator
        /// </summary>
        /// <param name="encoded"></param>
        /// <param name="separator"></param>
        /// <returns>Decompressed and decode list of strings </returns>

        public static IEnumerable<String> DecodeBase64AsStr(string encoded, char separator)
        {
            var data = Decompress( Convert.FromBase64String(encoded));
            return data.Split(separator).ToList();
        }

        public static string ReplaceAtIndex(this string text, int index, char c)
        {
            var stringBuilder = new StringBuilder(text);
            stringBuilder[index] = c;
            return stringBuilder.ToString();
        }


        /// <summary>
        /// Byte array Bzip Decompression to a string
        /// </summary>
        /// <param name="data"></param>
        /// <returns>A decompressed string</returns>
        private static string Decompress(byte[] data)
        {
            using MemoryStream inStream = new MemoryStream(data);
            using var outStream = new MemoryStream();
            try
            {
                BZip2.Decompress(inStream, outStream, false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            outStream.Seek(0, SeekOrigin.Begin);
            StreamReader reader = new StreamReader(outStream);
            var t = reader.ReadToEnd();
            return t;
        }
    }
}
