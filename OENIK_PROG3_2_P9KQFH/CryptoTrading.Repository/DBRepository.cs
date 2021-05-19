// <copyright file="DBRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTrading.Repository
{
    using System.Collections.Generic;
    using System.Linq;
    using CryptoTrading.Data;
    using Microsoft.EntityFrameworkCore;

    /// <summary>
    /// Base repository.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class DBRepository<T> : IRepository<T>
        where T : class
    {
        private CTDDataBase dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="DBRepository{T}"/> class.
        /// Constructor.
        /// </summary>
        /// <param name="dbContext"></param>
        protected DBRepository(CTDDataBase dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <summary>
        /// Add an entity to the datasbase.
        /// </summary>
        /// <param name="entity"></param>
        public void Add(T entity)
        {
            this.dbContext.Set<T>().Add(entity);
            this.dbContext.SaveChanges();
        }

        /// <summary>
        /// Delete an entity to the database.
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(T entity)
        {
            this.dbContext.Remove(entity);
            this.dbContext.SaveChanges();
        }

        /// <summary>
        /// Get all T from database.
        /// </summary>
        /// <returns>asd.</returns>
        public IQueryable<T> GetAll()
        {
           return this.dbContext.Set<T>();
        }

        /// <summary>
        /// Get one.
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns>asd.</returns>
        public abstract T GetOne(string shortName);

        /// <summary>
        /// Update an entity to the database.
        /// </summary>
        /// <param name="entity"></param>
        public void Update(T entity)
        {
            this.dbContext.Set<T>().Attach(entity);
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
    }
}
