using Microsoft.EntityFrameworkCore;
using MilitaryApp.Data;
using MilitaryApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace ConsoleApp
{
    class Program
    {
        private static MilitaryContext _context = new MilitaryContext();
        static void Main(string[] args)
        {
            // Ensure DB is ready else Create NEW Database
            _context.Database.EnsureCreated();

            //GetMilitary("Before Add: ");
            //AddMilitary();
            //GetMilitary("After Add: ");

            //InsertMulitipleMilitary();
            //InsertVariousType();
            //RetrieveAndUpdateMilitary();
            //RetrieveAndUpdateMulitpleMilitary();

            //InsertNewMilitaryWithQuote();
            //AddQuoteToExistingMilitary();
            EagerLoadMilitaryWithQuotes();
        }

        private static void GetMilitary(string text)
        {
            // Get all data from Military table
            var militarys = _context.Militaries.ToList();

            Console.WriteLine($"{text}: Military Count is {militarys.Count}");

            foreach (var military in militarys)
            {
                Console.WriteLine(military.Name);
            }
        }

        private static void AddMilitary()
        {
            // For inserting to military table
            var militarys = new Military { Name = "Amit" };
            _context.Militaries.Add(militarys);
            _context.SaveChanges();
        }


        private static void InsertMulitipleMilitary()
        {
            // Atleast 4 operations is needed for bulk operations 
            var military1 = new Military { Name = "Military 1" };
            var military2 = new Military { Name = "Military 2" };
            var military3 = new Military { Name = "Military 3" };
            var military4 = new Military { Name = "Military 4" };

            // alterante way
            //var militaries = new List<Military>();
            //militaries.Add(military1);
            //militaries.Add(military2);
            //_context.Militaries.AddRange(militaries);

            _context.Militaries.AddRange(military1, military2, military3, military4);
            _context.SaveChanges();
        }

        private static void InsertVariousType()
        {
            // For inserting to military table
            var militarys = new Military { Name = "Military 5 with king 1" };
            var kings = new King { KingName = "King1" };
            _context.AddRange(militarys, kings);
            _context.SaveChanges();
        }

        private static void RetrieveAndUpdateMilitary()
        {
            var militaries = _context.Militaries.FirstOrDefault();
            militaries.Name += "Naik";
            _context.SaveChanges();
        }

        private static void RetrieveAndUpdateMulitpleMilitary()
        {
            var militaries = _context.Militaries.Skip(0).Take(3).ToList();
            militaries.ForEach(m => m.Name += " update ");

            // Incase for adding any new record
            _context.Militaries.Add(new Military { Name = "Military added" });
            _context.SaveChanges();
        }

        private static void DeleteMilitary()
        {
            var militaries = _context.Militaries.Find(1);

            _context.Militaries.Remove(militaries);
            _context.SaveChanges();
        }

        private static void InsertNewMilitaryWithQuote()
        {
            var military = new Military
            {
                Name = "Marathas",
                Quotes = new List<Quote>
                {
                    new Quote {Text ="To save country"}
                }
            };
            _context.Militaries.Add(military);
            _context.SaveChanges();
        }

        private static void AddQuoteToExistingMilitary()
        {
            //var military = _context.Militaries.Find(15);
            //military.Quotes.Add(new Quote
            //{
            //    Text = "Added: To save nation"
            //});
            //using (var newContext = new MilitaryContext())
            //{
            //    newContext.Militaries.Attach(military);
            //    newContext.SaveChanges();
            //}

            // Or

            var quote = new Quote
            {
                Text = "other way",
                MilitaryId = 15
            };
            using (var newContext = new MilitaryContext())
            {
                newContext.Quotes.Add(quote);
                newContext.SaveChanges();
            }
        }

        private static void EagerLoadMilitaryWithQuotes()
        {
            // left join
            var militaryQuotes = _context.Militaries
                .Include(s => s.Quotes).ToList();

            var militaryQuotes4 = _context.Militaries
                .Include(s => s.Quotes)
                .Include(s => s.King).ToList();

        }

        private static void FilteringWithRelatedData()
        {
            var military = _context.Militaries
                .Where(s => s.Quotes.Any(q => q.Text.Contains("Happy")))
                .ToList();
        }

        private static void QuerySQLView()
        {
            var military = _context.viewMilitary.FirstOrDefault();
        }
    }

}
