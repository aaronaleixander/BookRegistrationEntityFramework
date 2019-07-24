using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRegistrationEntityFramework
{
    /// <summary>
    /// Contains helper methods to manipulate books in the database.
    /// </summary>
    static class BookDb
    {   
        /// <summary>
        /// Retrieves all books, sorted, and in alphabetical order by title(A-Z)
        /// </summary>
        /// <returns></returns>
        public static List<Book> GetBooks()
        {
            // the using statement will force the compiler to create a try/finally
            // The finally will dispose of the db context.
            // SEARCH: using statement for documentation.
            using (var context = new BookRegistrationEntities())
            {
                // Can also reference LINQ Method Syntax. Example in CustomerDb.cs
                
                // LINQ query syntax (Database Queries)
                List<Book> books =
                    (from b in context.Book
                     orderby b.Title ascending
                     select b).ToList();
                return books;
                // you can also get rid of the variable name and just return the actual query.
            }
        }
    }
}
