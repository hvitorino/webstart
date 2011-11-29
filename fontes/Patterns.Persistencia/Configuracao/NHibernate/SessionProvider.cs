using NHibernate;
using NHibernate.Context;

namespace Patterns.Persistencia.Configuracao.NHibernate
{
    public static class SessionProvider
    {
        static SessionProvider()
        {
            var config = new FluentConfigurator();

            Factory = config.CreateSessionFactory();
        }

        public static ISessionFactory Factory
        { 
            get; private set; 
        }

        public static ISession CurrentSession
        {
            get
            {
                if (CurrentSessionContext.HasBind(Factory))
                    return Factory.GetCurrentSession();

                var session = Factory.OpenSession();

                CurrentSessionContext.Bind(session);
                session.BeginTransaction();

                return session;
            }
        }
    }
}