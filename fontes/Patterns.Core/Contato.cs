namespace Patterns.Core
{
    public class Contato : Entidade
    {
        public enum TipoContato
        {
            Email,
            Telefone
        }

        public virtual TipoContato Tipo { get; set; }
        public virtual string Referencia { get; set; }
    }
}