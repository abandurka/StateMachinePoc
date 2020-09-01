using System;
using System.Threading.Tasks;
using Autofac;
using StateMachinePoc.Store;

namespace StateMachinePoc.StateMachine.States
{
    public class ReceivedState : IState
    {
        private InboundMessage _inboundMessage;
        private readonly IMappingRepository _mappingRepository;
        private readonly ILifetimeScope _container;

        public ReceivedState(ILifetimeScope container)
        {
            Console.WriteLine("ReceivedState created");
            _mappingRepository = container.Resolve<IMappingRepository>();
            _container = container;
        }

        public ReceivedState WithParameters(InboundMessage inboundMessage)
        {
            Console.WriteLine("ReceivedState initialised");
            _inboundMessage = inboundMessage;
            return this;
        }
        
        public bool IsFinishState => false;
        
        public async Task<IState> GetNextStateAsync()
        {
            Console.WriteLine("ReceivedState started");
            var mappings = await _mappingRepository.GetAsync(_inboundMessage.AccountId, _inboundMessage.EntityId);
            return mappings == null
                ? _container.Resolve<NotExistsInDbState>().WithParameters(_inboundMessage) as IState
                : _container.Resolve<ExistsInDbState>().WithParameters(mappings, _inboundMessage);
        }
    }
}