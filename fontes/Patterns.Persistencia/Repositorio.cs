using System.Collections.Generic;
using NHibernate;
using NHibernate.Criterion;
using Patterns.Core;
using Patterns.Persistencia.Configuracao.NHibernate;

namespace Patterns.Persistencia
{
    public abstract class Repositorio<TEntidade> : IRepositorio<TEntidade>
        where TEntidade : Entidade
    {
        protected ISession NhSession
        {
            get { return SessionProvider.CurrentSession; }
        }

        public TEntidade Inclui(TEntidade entidade)
        {
            NhSession.SaveOrUpdate(entidade);
            NhSession.Flush();

            return entidade;
        }

        public TEntidade ComId(long id)
        {
            return NhSession.CreateCriteria<TEntidade>()
                .Add(Restrictions.Eq("Id", id))
                .UniqueResult<TEntidade>();
        }

        public void Exclui(long id)
        {
            var entidade = ComId(id);

            NhSession.Delete(entidade);
            NhSession.Flush();
        }

        public void Exclui(TEntidade entidade)
        {
            NhSession.Delete(entidade);
            NhSession.Flush();
        }

        public void Descarrega()
        {
            NhSession.Flush();
        }

        public long Total
        {
            get
            {
                ICriteria criteriaTotal = NhSession.CreateCriteria<Pessoa>();

                criteriaTotal
                    .SetProjection(Projections.Count("Id"));

                return criteriaTotal.UniqueResult<int>();
            }
        }

        public virtual IEnumerable<TEntidade> Lista()
        {
            return NhSession.CreateCriteria<TEntidade>().List<TEntidade>();
        }
    }
}
