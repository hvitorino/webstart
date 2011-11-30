using System;
using System.Web;
using NHibernate.Context;
using Patterns.Persistencia.Configuracao.NHibernate;

namespace Patterns.Web.Configuracao.NHibernate
{
    public class SessionLifeCycle : IHttpModule
    {
        #region IHttpModule Members

        public void Init(HttpApplication context)
        {
            context.EndRequest += ContextEndRequest;
        }

        public void Dispose()
        {
        }

        #endregion

        private static void ContextEndRequest(object sender, EventArgs e)
        {
            var session = CurrentSessionContext.Unbind(SessionProvider.Factory);

            if (session == null)
                return;

            try
            {
                session.Flush();
                session.Transaction.Commit();
            }
            catch (Exception)
            {
                session.Transaction.Rollback();

                throw;
            }
            finally
            {
                session.Close();
            }
        }
    }
}