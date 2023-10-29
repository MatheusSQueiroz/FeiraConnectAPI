namespace FeiraConnect.Model
{
    public class UserLogin
    {
        public long Id { get; set; }

        public string Nome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Senha { get; set; } = string.Empty;

        public string Telefone { get; set; } = string.Empty;

        public string Token { get; set; } = string.Empty;
    }
}
