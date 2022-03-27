using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;
using MyStore.Domain.Extensions;

namespace MyStore.Data
{
    public class ReportsRepository : IReportsRepository
    {
        private readonly StoreContext storeContext;

        public ReportsRepository(StoreContext storeContext)
        {
            this.storeContext = storeContext;
        }

        public List<Customer> GetCustomersWithNoOrders()
        {
            var query = storeContext.Customers
                .FromSqlRaw(@"SELECT c.custid, c.companyname,c.contactname, c.contacttitle,c.address,c.city,
                            c.region, c.postalcode, c.country, c.phone, c.fax 
                            FROM Customers c
                            LEFT JOIN Orders o ON c.custid = o.custid 
                            WHERE o.custid IS NULL");

            return query.ToList();
        }

        

        public List<CustomerContact> GetContacts()
        {
             
            var query = storeContext.CustomerContacts
                .FromSqlRaw(@"SELECT c.custid,c.address,c.city, c.country
                            FROM Customers c
                            LEFT JOIN Orders ON Orders.custid = c.custid
                            where Orders.custid IS NULL");

            var result = query.ToList();

            return query.ToList();
        }

        /*
         * CustomersOfAProduct - returneaza numarul de clienti distincti care au comandat un anumit produs si cantitatea totala comandata de acestia
         */
        public CustomersOfAProduct GetNbOfCustomers(int id)
        {
            var query = storeContext.CustomersOfAProduct
                .FromSqlRaw(@"SELECT p.productid ProductID, p.productname ProductName,  Count(DISTINCT o.custid) NumberOfCustomers, SUM(od.qty) TotalQtyOrdered
	                        FROM Customers c 
	                        LEFT JOIN Orders o ON c.custid=o.custid
	                        JOIN OrderDetails od on o.orderid = od.orderid
	                        JOIN Products p ON od.productid=p.productid
	                        WHERE od.productid = {0}
	                        GROUP BY p.productid, p.productname", id);

            return query.FirstOrDefault();
        }
    }

    public interface IReportsRepository
    {
        List<CustomerContact> GetContacts();
        List<Customer> GetCustomersWithNoOrders();
        CustomersOfAProduct GetNbOfCustomers(int id);
    }
}
