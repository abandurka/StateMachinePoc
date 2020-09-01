using System.Threading.Tasks;
using Autofac;
using StateMachinePoc.StateMachine.States;

namespace StateMachinePoc.StateMachine
{
    public class FeederStateMachine
    {
        public async Task StartAsync(ReceivedState startState)
        {
            var currentState = startState as IState;
            while (!currentState.IsFinishState)
            {
                currentState = await currentState.GetNextStateAsync();
            }
        }
    }
}