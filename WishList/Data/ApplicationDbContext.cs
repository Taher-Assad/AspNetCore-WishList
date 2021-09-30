using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using WishList.Models;

namespace WishList.Data
{
    public class ApplicationDbContext : DbContext
    {
		public DbSet<Item> Items { set; get; }
		public ApplicationDbContext(DbContextOptions options) : base(options) {}
	}
}
