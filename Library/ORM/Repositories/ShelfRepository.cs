// <copyright file="ShelfRepository.cs" company="Васильева Марина Алексеевна">
// Copyright (c) Васильева Марина Алексеевна. All rights reserved.
// </copyright>

namespace ORM.Repositories
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using Domain;
using NHibernate;

    public class ShelfRepository : IRepository<Shelf>
    {
        private ISession session;

        public ShelfRepository(ISession session)
        {
            this.session = session
                ?? throw new ArgumentNullException(nameof(session));
        }

        public IQueryable<Shelf> Filter(Expression<Func<Shelf, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Shelf Find(Expression<Func<Shelf, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Shelf Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Shelf> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool Save(Shelf entity)
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
