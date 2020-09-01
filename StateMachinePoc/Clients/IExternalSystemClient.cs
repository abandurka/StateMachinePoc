using System.Threading.Tasks;

namespace StateMachinePoc.Clients
{
    public interface IExternalSystemClient
    {
        Task CreateAsync(int accountId, int entityId, object body);
        Task UpdateAsync(int accountId, int entityId, object body);
        Task DeleteAsync(int accountId, int entityId, object body);
    }
}