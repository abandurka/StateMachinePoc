using System;
using System.Threading.Tasks;

namespace StateMachinePoc.Clients
{
    public class ExternalSystemClientStub : IExternalSystemClient
    {
        private int _accountId = default;
        private int _entityId = default;

        public void Setup(int accountId = default, int entityId = default)
        {
            _entityId = entityId;
            _accountId = accountId;
        }
        
        public Task CreateAsync(int accountId, int entityId, object body)
        {
            if (accountId == _accountId && entityId == _entityId)
            {
                Console.WriteLine($"Created entity {entityId} for account {accountId}");
                return Task.CompletedTask;
            }
            
            throw new ArgumentException("Wow, error happen, does not created");
        }

        public Task UpdateAsync(int accountId, int entityId, object body)
        {
            if (accountId == _accountId && entityId == _entityId)
            {
                Console.WriteLine($"Updated entity {entityId} for account {accountId}");
                return Task.CompletedTask;
            }
            
            throw new ArgumentException("Wow, error happen, does not updated");
        }

        public Task DeleteAsync(int accountId, int entityId, object body)
        {
            if (accountId == _accountId && entityId == _entityId)
            {
                Console.WriteLine($"Deleted entity {entityId} for account {accountId}");
                return Task.CompletedTask;
            }
            
            throw new ArgumentException("Wow, error happen, does not deleted");
        }
    }
}