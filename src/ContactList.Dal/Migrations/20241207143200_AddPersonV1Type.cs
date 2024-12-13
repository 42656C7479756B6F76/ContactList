using FluentMigrator;

namespace ContactList.Dal.Migrations;

[Migration(20241207143200, TransactionBehavior.None)]
public class AddPersonV1Type : Migration
{
    public override void Up()
    {
        const string sql = @"
DO $$
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM pg_type WHERE typname = 'persons_v1') THEN
            CREATE TYPE persons_v1 as
            (
                  id         bigint
                , first_name text
                , last_name  text
                , created_at timestamp with time zone
            );
        END IF;
    END
$$;";

        Execute.Sql(sql);
    }

    public override void Down()
    {
        const string sql = @"
DO $$
    BEGIN
        DROP TYPE IF EXISTS persons_v1;
    END
$$;";

        Execute.Sql(sql);
    }
}