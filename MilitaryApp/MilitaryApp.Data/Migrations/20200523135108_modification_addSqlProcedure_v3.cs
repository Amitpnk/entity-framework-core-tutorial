using Microsoft.EntityFrameworkCore.Migrations;

namespace MilitaryApp.Data.Migrations
{
    public partial class modification_addSqlProcedure_v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"create PROCEDURE dbo.uspGetMilitary
                @militaryId int
                AS
                    SELECT militaryId, name from military
                    WHERE militaryId = @militaryId
            ");
        }

        // Incase if you want to revoke migration
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.uspGetMilitary");
        }
    }
}
