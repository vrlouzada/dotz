namespace DOTZ.Domain.Helper
{
    public class AppSettings
    {

        public const string SETTINGS = "AppSettings";

        /// <summary>
        /// Chave secreta para uso do Token
        /// </summary>
        public string Secret { get; set; }
    }
}
