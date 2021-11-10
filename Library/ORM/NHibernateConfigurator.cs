// <copyright file="NHibernateConfigurator.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace ORM
{
    using System.Reflection;
    using FluentNHibernate.Cfg;
    using FluentNHibernate.Cfg.Db;
    using NHibernate;
    using NHibernate.Cfg;
    using NHibernate.Tool.hbm2ddl;

    /// <summary>
    /// Класс-помощник для настройки NHibernate.
    /// </summary>
    public static class NHibernateConfigurator
    {
        private static FluentConfiguration fluentConfiguration;

        /// <summary>
        /// Генерирует фабрику сессий (<see cref="ISessionFactory"/>).
        /// </summary>
        /// <param name="assembly"> Целевая сборка. </param>
        /// <param name="showSql"> Показывать генерируемый SQL-код. </param>
        /// <returns> Фабрику сессий (<see cref="ISessionFactory"/>). </returns>
        public static ISessionFactory GetSessionFactory(Assembly assembly = null, bool showSql = false)
        {
            return GetConfiguration(assembly ?? Assembly.GetExecutingAssembly(), showSql).BuildSessionFactory();
        }

        private static FluentConfiguration GetConfiguration(Assembly assembly, bool showSql = false)
        {
            if (fluentConfiguration is null)
            {
                var databaseConfiguration = MsSqlConfiguration.MsSql2012.ConnectionString(
                    x => x
                        .Server(@"LAPTOP-2ALR8J1J\SQLEXPRESS")
                        .Database("Library")
                        .TrustedConnection());

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

        /// <summary>
        /// Метод, порождающий таблицы (если их не было в схеме) по конфигурации.
        /// </summary>
        /// <remarks> Необходимо только для создания схемы БД из ничего. </remarks>
        /// <param name="configuration"> Конфигурация ORM, содержащая правила отображения. </param>
        private static void BuildSchema(Configuration configuration)
        {
            new SchemaExport(configuration).Execute(true, true, false);
        }
    }
}
