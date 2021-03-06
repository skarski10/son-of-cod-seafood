﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SonOfCod.Models
{
    public class SonOfACodDbContext : IdentityDbContext<User>
    {
        public SonOfACodDbContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<MailingList> MailingLists { get; set; }
        public virtual DbSet<NewsLetter> NewsLetters { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SonOfACod;integrated security=True;");
        }
    }
}
