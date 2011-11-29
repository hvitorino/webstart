namespace Patterns.Core
{
    public class Endereco : IComponente
    {
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
    }
}
