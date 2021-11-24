// <copyright file="BookRepository.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>
using Domain;
using NHibernate;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace ORM.Repositories
{
    /// <summary>
    /// Репозиторий для Книги.
    /// </summary>
    public class BookRepository : IRepository<Book>
    {
        private ISession session;

        public BookRepository(ISession session) 
        {
            this.session = session
                ?? throw new ArgumentNullException(nameof(session));
        }

        /// <inheritdoc/>
        public IQueryable<Book> Filter(Expression<Func<Book, bool>> predicate)
        {
            return this.GetAll().Where(predicate);
        }


        /// <inheritdoc/>
        public Book Find(Expression<Func<Book, bool>> predicate)
        {
            return this.GetAll().FirstOrDefault(predicate);
        }

        public Book Get(int id)
        {
            return this.session.Get<Book>(id);
        }

        /// <inheritdoc/>
        public IQueryable<Book> GetAll()
        {
            return this.session.Query<Book>();
        }
    }
}
