namespace SlotMachine.API.Settings
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public CollectionNames CollectionNames { get; set; }
    }

    public class CollectionNames
    {
        public string Players { get; set; }
        public string Configuration { get; set; }
        public string Spins { get; set; }

    }
}
