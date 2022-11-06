namespace SlotMachine.API.Models.Requests
{
    public class AddAmountRequest
    {
        public int PlayerId { get; set; }
        public int Amount { get; set; }
    }
}
