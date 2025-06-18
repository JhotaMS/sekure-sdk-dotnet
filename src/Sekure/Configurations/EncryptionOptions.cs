namespace Sekure.Configurations;

public class EncryptionOptions
{
    private const string ENCRYPTION = "Encryption";
    public string Key { get; set; }
    public string Iv { get; set; }

    public class FACT
    {
        public string SECTION_NAME = ENCRYPTION;
    }
}
