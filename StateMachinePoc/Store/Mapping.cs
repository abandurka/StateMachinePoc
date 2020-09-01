namespace StateMachinePoc.Store
{
    public class Mapping
    {
        public Mapping(int accountId, int entityId, int mapKey)
        {
            AccountId = accountId;
            EntityId = entityId;
            MapKey = mapKey;
        }

        public int AccountId { get; }
        public int EntityId { get; }
        public int MapKey { get; }

        public override string ToString()
        {
            return $"{AccountId} - {EntityId} - {MapKey}";
        }
    }
}