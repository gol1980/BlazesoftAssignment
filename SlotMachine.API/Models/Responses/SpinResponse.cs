namespace SlotMachine.API.Models.Responses
{
    public class SpinResponse
    {
        public int[] SpinResult { get; set; }
        public int WinAmount { get; set; }
        public int Balance { get; set; }
    }
}
