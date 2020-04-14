using Microsoft.EntityFrameworkCore;
using MilitaryApp.Data;
using MilitaryApp.Domain;
using System;
using System.Collections.Generic;
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

            //GetMilitary("Before Add: ");
            //AddMilitary();
            //GetMilitary("After Add: ");

            //InsertMulitipleMilitary();
            //InsertVariousType();
            //RetrieveAndUpdateMilitary();
            RetrieveAndUpdateMulitpleMilitary();
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
            //context.Militaries.AddRange(militaries);
                
            context.Militaries.AddRange(military1, military2, military3, military4);
            context.SaveChanges();
        }

        private static void InsertVariousType()
        {
            // For inserting to military table
            var militarys = new Military { Name = "Military 5 with king 1" };
            var kings = new King { KingName = "King1" };
            context.AddRange(militarys,kings);
            context.SaveChanges();
        }

        private static void RetrieveAndUpdateMilitary()
        {
            var militaries = context.Militaries.FirstOrDefault();
            militaries.Name += "Naik";
            context.SaveChanges();
        }

        private static void RetrieveAndUpdateMulitpleMilitary()
        {
            var militaries = context.Militaries.Skip(0).Take(3).ToList();
            militaries.ForEach(m => m.Name += " update ");

            // Incase for adding any new record
            context.Militaries.Add(new Military { Name= "Military added"})
            context.SaveChanges();
        }

        private static void DeleteMilitary()
        {
            var militaries = context.Militaries.Find(1);

            context.Militaries.Remove(militaries);
            context.SaveChanges();
        }
    }
}
