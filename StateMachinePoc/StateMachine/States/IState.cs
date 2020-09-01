using System.Threading.Tasks;

namespace StateMachinePoc.StateMachine.States
{
    public interface IState
    {
        bool IsFinishState { get; }
        Task<IState> GetNextStateAsync();
    }
}