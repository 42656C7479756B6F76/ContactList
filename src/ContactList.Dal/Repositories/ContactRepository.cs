using ContactList.Dal.Exceptions;
using ContactList.Dal.Models.Contact;
using ContactList.Dal.Models.Person;
using ContactList.Dal.Repositories.Interfaces;
using ContactList.Dal.Settings;
using ContactList.Domain;
using Dapper;
using Microsoft.Extensions.Options;
using Npgsql;

namespace ContactList.Dal.Repositories;

public class ContactRepository : PostgresRepository, IContactRepository
{
    public ContactRepository(IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
    }

    public async Task<long[]> Add(ContactEntityV1[] contacts, CancellationToken token)
    {
        await using var connection = await GetConnection();

        // TODO
        if (!await IsPersonExist(connection, contacts.First().PersonId))
            throw new DependentItemNotFoundException("Person", contacts.First().PersonId);
        
        const string sqlQuery = @"
insert into contacts
(
   name
 , phone_number
 , person_id
 , created_at
)
select
    name
  , phone_number
  , person_id
  , created_at
from UNNEST(@Contacts)
returning id;
";

        var ids = await connection.QueryAsync<long>(
            new CommandDefinition(
                sqlQuery,
                new
                {
                    Contacts = contacts
                },
                cancellationToken: token));

        return ids
            .ToArray();
    }

    public async Task<ContactEntityV1[]> GetPersonContacts(PersonGetContactsModel query, CancellationToken token)
    {
        const string baseSql = @"
select id
     , name
     , phone_number
     , person_id
     , created_at
from contacts
where person_id = @PersonId
";
        var cmd = new CommandDefinition(baseSql,
            new
            {
                query.PersonId
            },
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token);

        await using var connection = await GetConnection();

        var result = await connection.QueryAsync<ContactEntityV1>(cmd);
        if (result is null)
            throw new ItemNotFoundException("Contact", query.PersonId);

        return result.ToArray();
    }

    public async Task<ContactEntityV1> Update(ContactUpdateModel query, CancellationToken token)
    {
        await using var connection = await GetConnection();

        if (!await IsPersonExist(connection, query.PersonId))
            throw new DependentItemNotFoundException("Person", query.PersonId);

        const string sqlQuery = @"
update contacts
set
    name = @Name
  , phone_number = @PhoneNumber
  , person_id = @PersonId
where
    id = @Id
returning id, name, phone_number, person_id, created_at;
";
        var cmd = new CommandDefinition(sqlQuery,
            new
            {
                query.Id,
                query.Name,
                query.PhoneNumber,
                query.PersonId
            },
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token);

        var result = await connection.QueryFirstOrDefaultAsync<ContactEntityV1>(cmd);

        if (result is null)
            throw new ItemNotFoundException("Contact", query.Id);

        return result;
    }

    public async Task<bool> Delete(ContactDeleteModel query, CancellationToken token)
    {
        const string sqlQuery = @"
delete from contacts
where id = @ContactId 
";

        var cmd = new CommandDefinition(sqlQuery,
            new
            {
                query.ContactId
            },
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token);

        await using var connection = await GetConnection();
        return await connection.ExecuteAsync(cmd) > 0;
    }

    private static async Task<bool> IsPersonExist(NpgsqlConnection connection, long personId)
    {
        const string checkPersonSql = @"
select count(1)
from persons
where id = @PersonId
";
        var personExistsCmd = new CommandDefinition(checkPersonSql,
            new
            {
                PersonId = personId
            });

        return await connection.ExecuteScalarAsync<bool>(personExistsCmd);
    }
}