// <copyright file="AuthorRepository.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace ORM.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Domain;
    using NHibernate;

    public class AuthorRepository : IRepository<Author>
    {
        private ISession session;

        public AuthorRepository(ISession session)
        {
            this.session = session
                ?? throw new ArgumentNullException(nameof(session));
        }

        public IQueryable<Author> Filter(Expression<Func<Author, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Author Find(Expression<Func<Author, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Author Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Author> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save(Author entity)
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
    }
}
