namespace MediatR.AspNet {
    public class ApplicationErrorDetails {
        public string Code { get; set; }
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
