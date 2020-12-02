

using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using ICSharpCode.SharpZipLib.BZip2;

namespace Util
{
    public static class Utility
    {
        public static IEnumerable<int> DecodeBase64(string encoded, char separator)
        {
            return DecodeBase64AsStr(encoded, separator)
                .Select(x => int.Parse(x))
                .ToList();
        }

        public static IEnumerable<String> DecodeBase64AsStr(string encoded, char separator)
        {
            var data = Decompress( Convert.FromBase64String(encoded));
            return data.Split(separator).ToList();
        }

        public static string Decompress(byte[] data)
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
