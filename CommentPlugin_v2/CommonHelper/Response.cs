namespace CommonHelper
{
    public class Response<T>
    {
        public T ResponseData { get; set; }
        public bool Success { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object OtherData { get; set; }
        public Response(bool success, int statusCode, string message, T data, object otherData = null)
        {
            Success = success;
            StatusCode = statusCode;
            Message = message;
            ResponseData = data;
            OtherData = otherData;
        }
        public static Response<T> CreateSuccessResponse(T data)
        {
            return new Response<T>(true, 200, "success !", data);
        }
        public static Response<T> CreateSuccessResponse(T data, object otherData)
        {
            return new Response<T>(true, 200, "success !", data, otherData);
        }
        public static Response<T> CreateErrorResponse(Exception exception = null,string message ="")
        {
            return new Response<T>(false, 
                500,
                string.IsNullOrEmpty(message) ? "Đã sảy ra lỗi vui lòng thử lại sau hoặc thông báo với quản trị viên!" : message, 
                default(T));
        }
        public static Response<T> CreateErrorResponse(int errorCode, string message = "")
        {
            return new Response<T>(false,
                errorCode,
                string.IsNullOrEmpty(message) ? "Đã sảy ra lỗi vui lòng thử lại sau hoặc thông báo với quản trị viên!" : message,
                default(T));
        }
    }
    public class GetListResponseModel<T>
    {
        public T Data { get; set; }
        public int TotalData { get; set; }
        public int PageCount { get; set; }
        public GetListResponseModel(int totalData, int pageSize)
        {
            TotalData = totalData;
            PageCount = (int)Math.Ceiling(Convert.ToDecimal(totalData) / Convert.ToDecimal(pageSize));
        }
    }
}