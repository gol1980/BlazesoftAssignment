namespace SlotMachine.API.Models.Requests
{
    public class SpinRequest
    {
        public int  PlayerId { get; set; }
        public int BetAmount { get; set; }
    }
}
