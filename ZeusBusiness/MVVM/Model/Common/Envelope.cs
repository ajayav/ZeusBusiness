namespace ZeusBusiness.MVVM.Model.Common
{
    public class Envelope<T>
    {
        public bool Success { get; set; }
        public string Response { get; set; }
        public T Data { get; set; }
        public string ExceptionMessage { get; set; }
        public Guid ErrorIdentifier { get; set; }
        public Envelope()
        {

        }
        public Envelope(bool success, string response)
        {
            this.Success = success;
            this.Response = response;
        }
        public Envelope(bool success, string response, T data) : this(success, response)
        {
            this.Data = data;
        }
        public Envelope(bool success, string response, Exception exception) : this(success, response)
        {
            this.ExceptionMessage = exception.Message;
        }
    }
}