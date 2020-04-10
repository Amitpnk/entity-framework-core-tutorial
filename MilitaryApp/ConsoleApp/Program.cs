using MilitaryApp.Data;
using MilitaryApp.Domain;
using System;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static MilitaryContext context = new MilitaryContext();
        static void Main(string[] args)
        {
            // Ensure DB is ready else Create NEW Database
            context.Database.EnsureCreated();

            GetMilitary("Before Add: ");
            AddMilitary();
            GetMilitary("After Add: ");
        }

        private static void GetMilitary(string text)
        {
            // Get all data from Military table
            var militarys = context.Militaries.ToList();

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
            context.Militaries.Add(militarys);
            context.SaveChanges();
        }
    }
}
