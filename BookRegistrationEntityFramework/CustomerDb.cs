using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationEntityFramework
{
    static class CustomerDb
    {
        /// <summary>
        /// Returns all customers from the database
        /// </summary>
        /// <returns></returns>
        public static List<Customer> GetCustomers()
        {
            // Create instance of DB Context
            var db = new BookRegistrationEntities();

            // Use DB Context to retrieve all customers
            // Use LINQ (Language Integrated Query) ----- to query database.
            // ^ language instead of c# to communicate with database.

            // LINQ query syntax
            List<Customer> customers =
                (from c in db.Customer
                 //where c.LastName == "Ortiz"
                 //orderby c.LastName
                 select c).ToList();

            // LINQ method syntax - Same as above but slightly different syntax
            //List<Customer> customers =
            //    db.Customer
            //        .Where(c => c.LastName == "Ortiz")
            //        .OrderByDescending(c => c.LastName)
            //        .ToList();

            return customers;
        }

        /// <summary>
        /// Adds a customer. Returns the newly added customer with the CustomerId populated.
        /// </summary>
        /// <param name="c">The new customer to be added.</param>
        /// <returns></returns>
        public static Customer AddCustomer(Customer c)
        {
            using (var context = new BookRegistrationEntities())
            {
                context.Customer.Add(c);

                // Save changes must be called for insert/update/delete
                context.SaveChanges();
                // Return newly added customer with customer id populated.
                return c;
            }
        }
    }
}
