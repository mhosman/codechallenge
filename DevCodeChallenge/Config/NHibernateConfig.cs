using DevCodeChallenge.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;

namespace DevCodeChallenge.Config
{
    public class NHibernateConfig
    {
        public static ISessionFactory CreateSessionFactory()
        {
            var connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySQLConnectionString"].ConnectionString;

            return Fluently.Configure()
                .Database(MySQLConfiguration.Standard.ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PurchaseMap>())
                .ExposeConfiguration(cfg => cfg.SetProperty(Environment.Dialect, "NHibernate.Dialect.MySQLDialect"))
                .ExposeConfiguration(cfg => cfg.SetProperty(Environment.ShowSql, "true"))
                .BuildSessionFactory();
        }
    }
}