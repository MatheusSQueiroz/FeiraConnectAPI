namespace FeiraConnect.Security
{
    public class Settings
    {
        private static string secret = "6775a44458cc015db1d788e47c433b8bd4b7bde1c0038462d69f9cdddf87f563";

        public static string Secret { get => secret; set => secret = value; }
    }
}
