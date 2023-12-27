namespace ShoppingWebApi.Model
{
    public class ResponseHandler
    {
        public static ApiResponse GetExceptionResponse(Exception exception)
        {
            ApiResponse response = new ApiResponse();
            response.Code = "1";
            response.ResponseData = exception.Message;
            return response;
        }
        public static ApiResponse GetApiResponse(ApiResponseType type, object? contract)
        {
            ApiResponse response;
            response = new ApiResponse { ResponseData = contract };
            switch (type)
            {
                case ApiResponseType.Success:
                    response.Code = "0";
                    response.Message = "Success";
                    break;
                case ApiResponseType.NotFound:
                    response.Code = "2";
                    response.Message = "No record available";
                    break;
            }
            return response;

        }
    }
}
