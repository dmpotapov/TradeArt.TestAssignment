using System;

namespace TradeArt.Lib.Services
{
    public interface IStringInvertor
    {
        string Invert(string source);
    }

    public class StringInvertor : IStringInvertor
    {
        /// <summary>
        /// Inverts the string given as a parameter
        /// </summary>
        /// <param name="source">A string to invert</param>
        /// <returns>Inverted string</returns>
        public string Invert(string source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var arr = source.ToCharArray();
            Array.Reverse(arr);

            return new string(arr);
        }
    }
}
