using System;

namespace GraphQLSampleAPI.Wrappers
{
    public abstract class BaseApiResponse<T>
    {
        public string Message { get; set; }
        public T Data { get; set; }
        public bool Succeeded { get; set; }
    }
}