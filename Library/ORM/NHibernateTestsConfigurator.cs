// <copyright file="NHibernateTestsConfigurator.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

using System;
using FluentNHibernate.Cfg.Db;

namespace ORM
{
    using System.Reflection;
    using FluentNHibernate.Cfg;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;

    /// <summary>
    /// 
    /// </summary>
    class NHibernateTestsConfigurator
    {
        /// <summary>
        /// 
        /// </summary>
        private static FluentConfiguration fluentConfiguration;

        private static Configuration config;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="showSql"></param>
        /// <returns></returns>
        public static ISessionFactory GetSessionFactory(Assembly assembly = null, bool showSql = false)
        {
            return GetConfiguration(assembly ?? Assembly.GetExecutingAssembly(), showSql).BuildSessionFactory();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="showSql"></param>
        /// <returns></returns>
        private static FluentConfiguration GetConfiguration(Assembly assembly, bool showSql = false)
        {
            if (fluentConfiguration is null)
            {
                var databaseConfiguration = SQLiteConfiguration.Standard.InMemory();

                if (showSql)
                {
                    databaseConfiguration = databaseConfiguration.ShowSql().FormatSql();
                }

                fluentConfiguration = Fluently.Configure()
                    .Database(databaseConfiguration)
                    .Mappings(m => m.FluentMappings.AddFromAssembly(assembly))
                    .ExposeConfiguration(BuildSchema);
            }

            return fluentConfiguration;
        }

        public static void BuildSchema(Configuration configuration)
        {
            var session = GetSessionFactory().OpenSession();
            new SchemaExport(configuration)
                .Execute(true, true, false, session.Connection, Console.Out);
        }
    }
}
