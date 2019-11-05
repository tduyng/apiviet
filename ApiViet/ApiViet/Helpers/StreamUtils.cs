using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiViet.Helpers
{
    /// <summary>
    ///     Inspired by the source on github
    ///     https://github.com/KennanChan/RevitFileUtility
    /// </summary>
    internal static class StreamUtils
    {
        internal static string StreamToString(Stream stream, Encoding encoding)
        {
            return encoding.GetString(StreamToBytes(stream));
        }

        internal static byte[] StreamToBytes(Stream stream)
        {
            stream.Seek(0, SeekOrigin.Begin);
            var bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            return bytes;
        }
    }
}
