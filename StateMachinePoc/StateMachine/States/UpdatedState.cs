using System.Threading.Tasks;

namespace StateMachinePoc.StateMachine.States
{
    public class UpdatedState: IState
    {        
        public bool IsFinishState => true;

        public Task<IState> GetNextStateAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}