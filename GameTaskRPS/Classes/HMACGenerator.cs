using System.Security.Cryptography;
using System.Text;

namespace GameTaskRPS.Classes
{
    class HMACGenerator
    {
        public string HMAC_key { get; }
        public string HMAC { get; }

        public HMACGenerator(string message, int keySize = 32)
        {
            HMAC_key = GenerateHMACKey();
            HMAC = GenerateHMAC(HMAC_key, message);
        }

        private string GenerateHMAC(string HMAC_key, string message)
        {
            return ByteToHex(Hashing(Encoding.UTF8.GetBytes(HMAC_key + message)));
        }

        private string GenerateHMACKey(int keySize = 32)
        {
            return ByteToHex(Hashing(GenerateKey(keySize)));
        }

        private byte[] GenerateKey(int keySize = 32)
        {
            var key = new byte[keySize];
            RandomNumberGenerator.Create().GetBytes(key);
            return key;
        }

        private byte[] Hashing(byte[] key)
        {
            using (var hmac = new HMACSHA256(key))
            {
                key = hmac.ComputeHash(key);
            }
            
            return key;
        }

        private string ByteToHex(byte[] hash)
        {
            return BitConverter.ToString(hash).Replace("-","");
        }
    }
}
