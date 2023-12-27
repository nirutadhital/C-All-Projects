namespace ShoppingWebApi.Model
{
    public class ApiResponse
    {
        public string Code {  get; set; }
        public string Message { get; set; }
        public Object? ResponseData {  get; set; }

    }
    public enum ApiResponseType
    {
        Success,    
        NotFound,
        Failure
    }
}
