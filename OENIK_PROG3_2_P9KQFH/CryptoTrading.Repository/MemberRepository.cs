// <copyright file="MemberRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CryptoTrading.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using CryptoTrading.Data;
    using Microsoft.EntityFrameworkCore;
    using Models;

    /// <summary>
    /// member repo.
    /// </summary>
    public class MemberRepository : DBRepository<Member>, IMemberRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberRepository"/> class.
        /// ctor.
        /// </summary>
        /// <param name="dbContext"></param>
        public MemberRepository(CTDDataBase dbContext)
            : base(dbContext)
        {
        }

        /// <summary>
        /// get one member.
        /// </summary>
        /// <param name="shortName"></param>
        /// <returns>asd.</returns>
        public override Member GetOne(string shortName)
        {
            return this.GetAll().SingleOrDefault(x => x.UserName == shortName);
        }
    }
}
