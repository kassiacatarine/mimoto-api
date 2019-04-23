using Mimoto.Domain.Common;
using MongoDB.Driver;

namespace Mimoto.Infrastructure.Data
{
    public interface IMimotoContext
    {
        IMongoCollection<User> Users { get; }
        IMongoCollection<App> Apps { get; }
    }
}