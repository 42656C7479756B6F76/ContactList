using ContactList.Dal.Exceptions;
using ContactList.Dal.Models.Person;
using ContactList.Dal.Repositories.Interfaces;
using ContactList.Dal.Settings;
using ContactList.Domain;
using Dapper;
using Microsoft.Extensions.Options;

namespace ContactList.Dal.Repositories;

public class PersonRepository : PostgresRepository, IPersonRepository
{
    public PersonRepository(IOptions<DalOptions> dalSettings) : base(dalSettings.Value)
    {
    }

    public async Task<long[]> Add(PersonEntityV1[] persons, CancellationToken token)
    {
        const string sqlQuery = @"
insert into persons
(
   first_name
 , last_name
 , created_at
)
select
    first_name
  , last_name
  , created_at
from UNNEST(@Persons)
returning id;
";

        await using var connection = await GetConnection();
        var ids = await connection.QueryAsync<long>(
            new CommandDefinition(
                sqlQuery,
                new
                {
                    Persons = persons
                },
                cancellationToken: token));

        return ids
            .ToArray();
    }

    public async Task<PersonEntityV1> Get(PersonGetModel query, CancellationToken token)
    {
        const string sqlQuery = @"
select id
     , first_name
     , last_name
     , created_at
from persons
where id = @PersonId
";

        var cmd = new CommandDefinition(
            sqlQuery,
            new
            {
                query.PersonId
            },
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token);

        await using var connection = await GetConnection();

        var result = await connection.QueryFirstOrDefaultAsync<PersonEntityV1>(cmd);

        if (result is null)
            throw new ItemNotFoundException("Person", query.PersonId);

        return result;
    }

    public async Task<PersonEntityV1> Update(PersonUpdateModel query, CancellationToken token)
    {
        const string sqlQuery = @"
update persons
set
    first_name = @FirstName
  , last_name = @LastName
where
    id = @Id
returning id, first_name, last_name, created_at;
";
        var cmd = new CommandDefinition(
            sqlQuery,
            new
            {
                query.Id,
                query.FirstName,
                query.LastName
            },
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token);

        await using var connection = await GetConnection();

        var result = await connection.QueryFirstOrDefaultAsync<PersonEntityV1>(cmd);

        if (result is null)
            throw new ItemNotFoundException("Person", query.Id);

        return result;
    }

    public async Task<bool> Delete(PersonDeleteModel query, CancellationToken token)
    {
        const string sqlQuery = @"
delete from persons
where id = @TaskId
";

        var cmd = new CommandDefinition(
            sqlQuery,
            new
            {
                TaskId = query.Id
            },
            commandTimeout: DefaultTimeoutInSeconds,
            cancellationToken: token);

        await using var connection = await GetConnection();
        return await connection.ExecuteAsync(cmd) > 0;
    }
}