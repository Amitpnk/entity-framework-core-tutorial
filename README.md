# military-entityfreameworkcore
 
Step by step creating web api application 

## Table of Contents

- [Sending Feedback](#sending-feedback)
- [Folder Structure](#folder-structure)
-  [Sample application with each labs](#sample-application-with-each-steps)
    - [Step 1 - Create Application](#step-1---create-application)
    - [Step 2 - Adding EntityFramework via Nuget ](#step-2---adding-entityframework-via-nuget)
    - [Step 3 - Create Console App ]
    - [Step 4 - Adding migration]
     

## Sending Feedback

For feedback can drop mail to my email address amit.naik8103@gmail.com or you can create [issue](https://github.com/Amitpnk/angular-application/issues/new)

## Sample application with each steps

### Step 1 - Create Application

* Create Blank solution
* Class library .NET Standard
    * MilitaryApp.Domain
    * MilitaryApp.Data (Latest version on .Net standard - 2.1)

### Step 2 - Adding Nuget package manager

* Install Microsoft.EntityFrameworkCore.SqlServer to <b>MilitaryApp.Data</b> Class library <br/>
(As Microsoft.EntityFrameworkCore.SqlServer is dependent on Microsoft.EntityFrameworkCore.Relational and it is dependent on Microsoft.EntityFrameworkCore.Core, so we have add one Microsoft.EntityFrameworkCore.SqlServer nuget package manager)

and Add MilitaryContext.cs in <b>MilitaryApp.Data</b>

```C#
public class MilitaryContext : DbContext
{
    public DbSet<Military> Militaries { get; set; }
    public DbSet<Quote> Quotes { get; set; }
    public DbSet<King> Kings { get; set; }
}
```

Use EF Core Power Tool Extension for VS 2019

### Step 3 - Create Console App 

Create console app and make it as default project

```C#
class Program
    {
        static MilitaryContext context = new MilitaryContext();
        static void Main(string[] args)
        {
            context.Database.EnsureCreated();
            GetMilitary("Before Add: ");
            AddMilitary();
            GetMilitary("After Add: ");
        }

        private static void GetMilitary(string text)
        {
            var militarys = context.Militaries.ToList();
            Console.WriteLine($"{text}: Military Count is {militarys.Count}");

            foreach (var military in militarys)
            {
                Console.WriteLine(military.Name);
            }
        }

        private static void AddMilitary()
        {
            var militarys = new Military { Name = "Amit" };
            context.Militaries.Add(militarys);
            context.SaveChanges();
        }
    }

```

### Step 4 - Adding migration

* Install Microsoft.EntityFrameworkCore.Tools to <b>ConsoleApp</b> Application <br/>
* Make it Console application as default project
* In Package Manager console in MilitaryApp.Data , run below command
    * Add-Migration init
    * Update-Database


### Step 4 - Script migration for production DB

If we want to get SQL script

* In Package Manager console, run below command
    * script-migration

### Step 5 - Reverse engineering from existing database

* Class library .NET Standard as MilitaryApp.ReverseEnggData and reference this to ConsoleApp
* In Package Manager console in MilitaryApp.ReverseEnggData, run below command

```PS
scaffold-dbcontext -provider Microsoft.EntityFrameworkCore.SqlServer -connection "Data Source=(local)\SQLexpress;Initial Catalog=MilitaryDB;Integrated Security=True"
```

### Step 6 - Many to many relationship

```C#
public class MilitaryBattle
{
    public int MilitaryId { get; set; }
    public int BattleId { get; set; }
    public Military Military { get; set; }
    public Battle Battle { get; set; }
}

public class Military
{
    public Military()
    {
        Quotes = new List<Quote>();
        MilitaryBattles = new List<MilitaryBattle>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Quote> Quotes { get; set; }
    public King King { get; set; }
    public List<MilitaryBattle> MilitaryBattles { get; set; }
}

public class Battle
{
    public Battle()
    {
        MilitaryBattles = new List<MilitaryBattle>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<MilitaryBattle> MilitaryBattles { get; set; }
}
```

in MilitaryContext.cs
```C#
...

protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MilitaryBattle>().HasKey(m => new { m.MilitaryId, m.BattleId });
    }
```


### Step 6 - One to one relationship

```C#
public class Military
{
    ...
    public Horse Horse { get; set; }
}

public class Horse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int MilitaryId { get; set; }
}
```

### Step 7 - Visualising how EF Core model looks

* Install DGML editor in VS 2019 setup file (available in individual components)
* Install EF Core Power Tools via Extension
* Make multi target to netcoreapp3.1,netstandard2.0
* Add Microsoft.EntityFrameworkCore.Design lib via nuget package manager
* Create *.dgml file by right click on MilitaryApp.Data > EF Core Power Tools > Add DbContext Model diagram