using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TradeArt.Lib.Services
{
    public class SHA512HashGetter : IHashGetter
    {
        public async Task<string> GetByFileAsync(string path)
        {
            if (string.IsNullOrEmpty(path)) throw new ArgumentException(nameof(path));

            using var hashAlgorithm = SHA512.Create();
            using var stream = new FileStream(path, FileMode.Open);

            var hash = await hashAlgorithm.ComputeHashAsync(stream);

            var stringBuilder = new StringBuilder();

            foreach (var i in hash)
            {
                stringBuilder.Append(i.ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
