using FluentMigrator;

namespace Infrastructure.Migrations.Versions
{
    //use forward only migration bebause we are not using the down method
    [Migration(1,"Create table to save the user's information")]
    public class Version00000001 : VersionBase
    {
        public override void Up()
        {
            //create table users
            CreateTable("Users")
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Email").AsString(255).NotNullable()
                .WithColumn("Password").AsString(2000).NotNullable();
        }
    }
}
