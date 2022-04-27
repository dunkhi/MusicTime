using Microsoft.AspNet.Identity.EntityFramework;
using MusicTime.Domain;
using MusicTime.Domain.View_Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicTime.Data
{
  public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
  {
    public ApplicationDbContext()
        : base("MusicTimeAuthContext", throwIfV1Schema: false)
    {
    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      // Change the name of the table to be Users instead of AspNetUsers
      //modelBuilder.Entity<IdentityUser>()
      //    .ToTable("Users");
      //modelBuilder.Entity<ApplicationUser>()
      //    .ToTable("Users");
    }

    public DbSet<Album> Albums { get; set; }
    public DbSet<Artist> Artists { get; set; }
    public DbSet<Band> Bands { get; set; }
    public DbSet<Concert> Concerts { get; set; }
    public DbSet<Venue> Venues { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<CustomerOrder> CustomerOrders { get; set; }
    public DbSet<Ticket> Tickets { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Region> Regions { get; set; }
    //public DbSet<CustomerEditViewModel> CustomerEditViewModels { get; set; }
    public DbSet<EmailAddress> EmailAddresses { get; set; }
    public DbSet<PostalAddress> PostalAddresses { get; set; }
    public DbSet<AddressType> AddressTypes { get; set; }

    public static ApplicationDbContext Create()
    {
      return new ApplicationDbContext();
    }
  }
}
