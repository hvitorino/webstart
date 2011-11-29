// Type: NHibernate.ISessionFactory
// Assembly: NHibernate, Version=3.1.0.4000, Culture=neutral, PublicKeyToken=aa95f207798dfdb4
// Assembly location: D:\git\fortes\patterns\dependencias\nhibernate\NHibernate.dll

using NHibernate.Engine;
using NHibernate.Metadata;
using NHibernate.Stat;
using System;
using System.Collections.Generic;
using System.Data;

namespace NHibernate
{
    public interface ISessionFactory : IDisposable
    {
        IStatistics Statistics { get; }
        bool IsClosed { get; }
        ICollection<string> DefinedFilterNames { get; }
        ISession OpenSession(IDbConnection conn);
        ISession OpenSession(IInterceptor sessionLocalInterceptor);
        ISession OpenSession(IDbConnection conn, IInterceptor sessionLocalInterceptor);
        ISession OpenSession();
        IClassMetadata GetClassMetadata(Type persistentClass);
        IClassMetadata GetClassMetadata(string entityName);
        ICollectionMetadata GetCollectionMetadata(string roleName);
        IDictionary<string, IClassMetadata> GetAllClassMetadata();
        IDictionary<string, ICollectionMetadata> GetAllCollectionMetadata();
        void Close();
        void Evict(Type persistentClass);
        void Evict(Type persistentClass, object id);
        void EvictEntity(string entityName);
        void EvictEntity(string entityName, object id);
        void EvictCollection(string roleName);
        void EvictCollection(string roleName, object id);
        void EvictQueries();
        void EvictQueries(string cacheRegion);
        IStatelessSession OpenStatelessSession();
        IStatelessSession OpenStatelessSession(IDbConnection connection);
        FilterDefinition GetFilterDefinition(string filterName);
        ISession GetCurrentSession();
    }
}
