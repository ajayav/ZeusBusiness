namespace ZeusBusiness.Abstraction.Infrastructure.Encryption
{
    public interface ICrypto
    {
        public string Decrypt(string cipherText);
        public string Encrypt(string plainText);
    }
}
