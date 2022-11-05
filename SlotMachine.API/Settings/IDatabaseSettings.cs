namespace SlotMachine.API.Settings
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        CollectionNames CollectionNames { get; set; }
    }
}