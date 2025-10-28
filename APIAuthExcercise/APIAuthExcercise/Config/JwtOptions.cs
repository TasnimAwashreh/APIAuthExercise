namespace API_AuthExcercise.API.Config
{
    public class JwtOptions
    {
        public const string Section = "JwtToken";

        public string Key { get; set; }
        public string ExpireTime { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
