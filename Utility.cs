

using System;
using System.Linq;
using System.Collections.Generic;

namespace Util
{
    public static class Utility
    {
        public static IEnumerable<int> DecodeBase64(string encoded, char separator)
        {
            return DecodeBase64AsStr(encoded, separator)
                .Select(x => Int32.Parse(x))
                .ToList();
        }

        public static IEnumerable<String> DecodeBase64AsStr(string encoded, char separator)
        {
            var data = Convert.FromBase64String(encoded);
            var base64Decoded = System.Text.Encoding.ASCII.GetString(data);
            return base64Decoded.Split(separator).ToList();
        }
    }

}
