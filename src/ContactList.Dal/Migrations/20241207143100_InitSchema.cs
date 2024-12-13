using FluentMigrator;

namespace ContactList.Dal.Migrations;

[Migration(20241207143100, TransactionBehavior.None)]
public class InitSchema : Migration
{
    public override void Up()
    {
        Create.Table("persons")
            .WithColumn("id").AsInt64().PrimaryKey().Identity()
            .WithColumn("first_name").AsString().NotNullable()
            .WithColumn("last_name").AsString().NotNullable()
            .WithColumn("created_at").AsDateTimeOffset().NotNullable();
        
        Create.Table("contacts")
            .WithColumn("id").AsInt64().PrimaryKey().Identity()
            .WithColumn("name").AsString().NotNullable()
            .WithColumn("phone_number").AsString().NotNullable()
            .WithColumn("created_at").AsDateTimeOffset().NotNullable()
            .WithColumn("person_id").AsInt64().NotNullable()
            .ForeignKey("fk_contacts_persons_person_id", "persons", "id")
            .OnDeleteOrUpdate(System.Data.Rule.Cascade);
    }

    public override void Down()
    {
        Delete.Table("persons");
        Delete.Table("contacts");
    }
}