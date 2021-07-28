using System;

namespace GraphQLSampleAPI.Wrappers
{
    public class ApiResponse<T> : BaseApiResponse<T>
    {
        public ApiResponse(string message)
        {
            Message = message;
            Succeeded = false;
        }
        public ApiResponse(T data, string message)
        {
            Data = data;
            Message = message;
            Succeeded = true;
        }
    }
}