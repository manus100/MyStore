using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Extensions;

namespace MyStore.Domain.Entities   //tb sa fie acelasi cu namespace-ul pentru Entities
{
    public partial class StoreContext
    {
        public  DbSet<CustomerContact> CustomerContacts { get; set; }
        public DbSet<CustomersOfAProduct> CustomersOfAProduct { get; set; }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerContact>().HasNoKey();
            modelBuilder.Entity <CustomersOfAProduct>().HasNoKey();

        }
    }

   
}
