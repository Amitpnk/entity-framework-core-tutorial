using Microsoft.EntityFrameworkCore.Migrations;

namespace MilitaryApp.Data.Migrations
{
    public partial class modification_addSqlView_Func_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"create function dbo.funJoinColumnInfo  
                    (
                       @name nvarchar(50),
                    )
                    returns nvarchar(100)
                    as
                    begin return (select @name)  
                    end ");
            migrationBuilder.Sql(
                @"CREATE OR ALTER VIEW dbo.getMilitary
                    AS 
                    SELECT * from military
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.getMilitary");
            migrationBuilder.Sql("DROP FUNCTION dbo.funJoinColumnInfo")
        }
    }
}
