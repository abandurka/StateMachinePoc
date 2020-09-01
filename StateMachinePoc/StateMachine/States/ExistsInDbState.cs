using System;
using System.Threading.Tasks;
using Autofac;
using StateMachinePoc.Clients;
using StateMachinePoc.Store;

namespace StateMachinePoc.StateMachine.States
{
    public class ExistsInDbState: IState
    {
        private readonly IExternalSystemClient _client;
        private readonly ILifetimeScope _container;
        private Mapping _mappings;
        private InboundMessage _inboundMessage;
        public bool IsFinishState => false;

        public ExistsInDbState(ILifetimeScope container)
        {
            _client = container.Resolve<IExternalSystemClient>();
            _container = container;
        }

        public async Task<IState> GetNextStateAsync()
        {
            try
            {
                await _client.UpdateAsync(_mappings.AccountId, _mappings.MapKey, _inboundMessage);
                return _container.Resolve<UpdatedState>();
            }
            catch (ArgumentException e)
            {
                return _container.Resolve<ErrorState>().WithParameters(e.Message);
            }    
        }

        public ExistsInDbState WithParameters(Mapping mappings, InboundMessage inboundMessage)
        {
            _inboundMessage = inboundMessage;
            _mappings = mappings;
            return this;
        }
    }
}