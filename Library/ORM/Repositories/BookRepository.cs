// <copyright file="BookRepository.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>
namespace ORM.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Domain;
    using NHibernate;

    /// <summary>
    /// Репозиторий для Книги.
    /// </summary>
    public class BookRepository : IRepository<Book>
    {
        private ISession session;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <exception cref="ArgumentNullException"></exception>
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

        public Book Get(Guid id)
        {
            return this.session?.Get<Book>(id);
        }

        /// <inheritdoc/>
        public IQueryable<Book> GetAll()
        {
            return this.session?.Query<Book>();
        }

        /// <inheritdoc/>
        public bool Save(Book entity)
        {
            try
            {
                this.session?.Save(entity);
                this.session.Flush();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public Book GetByTitle(string title)
        {
            return this.GetAll().FirstOrDefault<Book>(x => x.Title == title);
        }

        public IQueryable<Book> FindBooksStartNameWith(string str)
        {
            return this.GetAll().Where(x => x.Title.StartsWith(str));
        }
    }
}
