using System.Collections;
using System.Collections.Generic;

namespace Patterns.Core
{
    public class Pessoa : Entidade
    {
        public virtual string Nome { get; set; }
        public virtual Endereco Endereco { get; set; }
        public virtual IList<Contato> Contatos { get; set; }

        public virtual void NovoTelefone(string telefone)
        {
            var contato = new Contato { Referencia = telefone, Tipo = Contato.TipoContato.Telefone };

            if(Contatos == null)
                Contatos = new List<Contato>();

            Contatos.Add(contato);
        }

        public virtual void NovoEmail(string email)
        {
            var contato = new Contato { Referencia = email, Tipo = Contato.TipoContato.Email };

            if (Contatos == null)
                Contatos = new List<Contato>();

            Contatos.Add(contato);
        }
    }
}
