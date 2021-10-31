using System;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.CosmosRepository;

namespace RepairR.Infrastructure.Extensions;

public static class RepositoryExtensions
{
    public static async ValueTask<T?> GetOrNullAsync<T>(this IRepository<T> repository, string id,
        string? partitionKey = null, CancellationToken token = default)
        where T : class, IItem
    {
        if (string.IsNullOrWhiteSpace(id))
        {
            throw new ArgumentNullException(nameof(id));
        }

        try
        {
            return await repository.GetAsync(id, partitionKey, token).AsTask()!;
        }
        catch (CosmosException e) when (e.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }
    }
}