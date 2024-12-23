namespace Entidades
{
    public class TransbankTo
    {
       
    }
    public class TransactionDataTo
    {
        public string buy_order { get; set; }
        public string session_id { get; set; }
        public int amount { get; set; }
        public string return_url { get; set; }
    }
    public class TransactionResponse
    {
        public string Token { get; set; }
        public string Url { get; set; }
        public bool Error { get; set; }
        public string ErrorMessage { get; set; }
    }
}
