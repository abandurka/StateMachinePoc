using System;

namespace StateMachinePoc.StateMachine
{
    public class InboundMessage
    {
        public InboundMessage(int accountId, int entityId)
        {
            AccountId = accountId;
            EntityId = entityId;
        }

        public int AccountId { get; }
        public int EntityId { get; }
    }
}