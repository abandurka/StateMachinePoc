using System;
using System.Threading.Tasks;

namespace StateMachinePoc.StateMachine.States
{
    public class ErrorState: IState
    {
        public bool IsFinishState => true;

        public Task<IState> GetNextStateAsync()
        {
            throw new System.NotImplementedException();
        }

        public ErrorState WithParameters(string message)
        {
            Console.WriteLine("Error state reached with message: " + message);
            return this;
        }
    }
}