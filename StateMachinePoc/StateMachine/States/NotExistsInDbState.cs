using System;
using System.Threading.Tasks;
using Autofac;
using StateMachinePoc.Clients;

namespace StateMachinePoc.StateMachine.States
{
    public class NotExistsInDbState: IState
    {
        public bool IsFinishState => false;

        private InboundMessage _inboundMessage;
        private readonly ILifetimeScope _container;
        private readonly IExternalSystemClient _client;
        
        public NotExistsInDbState(ILifetimeScope container)
        {
            _container = container;
            _client = container.Resolve<IExternalSystemClient>();
        }

        public async Task<IState> GetNextStateAsync()
        {
            try
            {
                await _client.CreateAsync(_inboundMessage.AccountId, _inboundMessage.EntityId, _inboundMessage);
                return _container.Resolve<CreatedState>();
            }
            catch (ArgumentException e)
            {
                return _container.Resolve<ErrorState>().WithParameters(e.Message);
            }  
        }

        public NotExistsInDbState WithParameters(InboundMessage inboundMessage)
        {
            _inboundMessage = inboundMessage;
            return this;
        }
    }
}