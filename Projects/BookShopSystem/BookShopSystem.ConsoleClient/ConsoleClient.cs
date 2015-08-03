
using System;
using System.Data.Entity;
using System.Linq;

namespace BookShopSystem.ConsoleClient
{
    using BookShopSystem.Data;
    using BookShopSystem.Models;
    class ConsoleClient
    {
        static void Main()
        {
            var context = new BookShopContext();
            var booksCount = context.Books.Count();
            //1.	Get all books after the year 2000. Select only their titles.

            var booksAfter2000 = context.Books
                .Where(b => b.ReleaseDate >= new DateTime(2000, 1, 1))
                .Select(b => new
                {
                    title = b.Title
                }).ToList();
            //booksAfter2000.ForEach(Console.WriteLine);

            //2.	Get all authors with at least one book with release date before 1990. Select their first name and last name

            var authors = context.Authors
                .Where(a => a.Books
                    .Any(b => b.ReleaseDate <= new DateTime(1999, 1, 1)))
                .Select(a => new
                {
                    FirstName = a.FirstName,
                    LastName = a.LastName
                }).ToList();
            //foreach (var author in authors)
            //{
            //    Console.WriteLine("First Name: {0} " +
            //                      "Last Name: {1}", 
            //        author.FirstName,
            //        author.LastName);
            //}

            //3.	Get all authors, ordered by the number of their books (descending). Select their first name, last name and book count.
            var authorBooks = context.Authors
                .OrderByDescending(a=>a.Books.Count)
                .Select(a => new
                {
                    a.FirstName,
                    a.LastName,
                    a.Books.Count
                });
            //foreach (var authorBook in authorBooks)
            //{
            //    Console.WriteLine(authorBook);
            //}

        }
    }
}
