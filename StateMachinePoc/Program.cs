using System.Threading.Tasks;
using Autofac;
using StateMachinePoc.Clients;
using StateMachinePoc.StateMachine;
using StateMachinePoc.StateMachine.States;
using StateMachinePoc.Store;

namespace StateMachinePoc
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder
                .RegisterType<ExternalSystemClientStub>()
                .SingleInstance()
                .AsImplementedInterfaces()
                .AsSelf();
            
            builder
                .RegisterType<MappingRepositoryStub>()
                .SingleInstance()
                .AsImplementedInterfaces()
                .AsSelf();

            builder.RegisterType<CreatedState>();
            builder.RegisterType<ErrorState>();
            builder.RegisterType<ExistsInDbState>();
            builder.RegisterType<NotExistsInDbState>();
            builder.RegisterType<ReceivedState>();
            builder.RegisterType<UpdatedState>();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var startState = scope.Resolve<ReceivedState>();
                var db = scope.Resolve<MappingRepositoryStub>();
                db.Setup(1, 2);
                
                var client = scope.Resolve<ExternalSystemClientStub>();
                client.Setup(1, 4);
                var init = startState.WithParameters(new InboundMessage(1, 2));

                var stateMachine = new FeederStateMachine();
                await stateMachine.StartAsync(startState);
            }
        }
    }
}