using System.Net;


namespace OnlineStore.SharedClasses
{
    public class RemoteCallResult
    {
        public bool Succeeded { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string ErrorMessage { get; set; }

        public static RemoteCallResult Ok
        {
            get
            {
                return new RemoteCallResult
                {
                    StatusCode = HttpStatusCode.OK,
                    Succeeded = true
                };
            }
        }

        public static RemoteCallResult<T> Success<T>(T data)
        {
            return new RemoteCallResult<T>
            {
                StatusCode = HttpStatusCode.OK,
                Result = data,
                Succeeded = true
            };
        }

        public static RemoteCallResult<T> Fail<T>(string message)
        {
            return new RemoteCallResult<T>
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Succeeded = false,
                ErrorMessage = message
            };
        }

        public static RemoteCallResult<T> Fail<T>(string message, T data)
        {
            return new RemoteCallResult<T>
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Succeeded = false,
                ErrorMessage = message,
                Result = data
            };
        }

        public static RemoteCallResult Fail(string message)
        {
            return new RemoteCallResult
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Succeeded = false,
                ErrorMessage = message
            };
        }
    }

    public class RemoteCallResult<T> : RemoteCallResult
    {
        public T Result { get; set; }
        public int Count { get; set; }
    }
}
