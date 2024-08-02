using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Entities.Migrations
{
    /// <inheritdoc />
    public partial class GetPersons_StoredProcedure : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllPersons = @"
            CREATE PROCEDURE [dbo].[GetAllPersons]
            AS BEGIN
                Select * from [dbo].[Persons]            
            END
            ";
            //This will execute and create the stored procedure in the database
            migrationBuilder.Sql(sp_GetAllPersons);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string sp_GetAllPersons = @"
            DROP PROCEDURE [dbo].[GetAllPersons]
            ";
            //This will execute and drop the stored procedure in the database
            migrationBuilder.Sql(sp_GetAllPersons);
        }
    }
}
