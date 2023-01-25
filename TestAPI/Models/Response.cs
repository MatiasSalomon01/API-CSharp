namespace TestAPI.Models
{
    public class Response
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public Response(int status, String msg, DateTime date) { 
            Status = status;
            Message = msg;
            Date = date;
        }
    }
}
