using System.Security.Cryptography;

namespace URLShortener.API.Services
{
    public class ShortCodeGenerator
    {
        private const string Characters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

        private const int CodeLength = 7;

        public string GenerateCode()
        {
            var code = new char[CodeLength];

            for (int i = 0; i < CodeLength; i++)
            {
                int index = RandomNumberGenerator.GetInt32(Characters.Length);
                code[i] = Characters[index];
            }

            return new string(code);
        }
    }
}