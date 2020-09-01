using System;
using System.Threading.Tasks;

namespace StateMachinePoc.Store
{
    class MappingRepositoryStub : IMappingRepository
    {
        private int _accountId;
        private int _entityId;

        public void Setup(int accountId = default, int entityId = default)
        {
            _accountId = accountId;
            _entityId = entityId;
        }
        
        public Task<Mapping> GetAsync(int accountId, int entityId)
        {
            if (accountId == _accountId && entityId == _entityId)
            {
                Console.WriteLine($"Mapping entity {entityId} exists for account {accountId}");
                return Task.FromResult(new Mapping(accountId, entityId, 4));
            }
            Console.WriteLine($"Mapping entity {entityId} in NOT exists for account {accountId}");
            return Task.FromResult<Mapping>(null);
        }
    }
}