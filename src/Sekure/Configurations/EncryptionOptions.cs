namespace Sekure.Configurations;

public class EncryptionOptions
{
    private const string ENCRYPTION = "Encryption";
    public string Key { get; set; }
    public string Iv { get; set; }
    public bool Active { get; set; }

    public static class FACT
    {
        public readonly static string SECTION_NAME = ENCRYPTION;
    }
}
