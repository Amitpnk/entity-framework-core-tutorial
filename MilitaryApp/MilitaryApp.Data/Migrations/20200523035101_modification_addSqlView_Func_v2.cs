using Microsoft.EntityFrameworkCore.Migrations;

namespace MilitaryApp.Data.Migrations
{
    public partial class modification_addSqlView_Func_v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"create function fun_JoinColumnInfo  
                    (
                       @name nvarchar(50),
                    )
                    returns nvarchar(100)
                    as
                    begin return (select @name)  
                    end ");
            migrationBuilder.Sql(
                @"CREATE OR ALTER VIEW dbo.getBattle
                    AS 
                    SELECT * from military
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
