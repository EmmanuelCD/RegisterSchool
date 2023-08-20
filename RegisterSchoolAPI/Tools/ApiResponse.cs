using System.Net;

namespace RegisterSchoolAPI.Tools
{
    public class ApiResponse
    {
        public HttpStatusCode StatusCode {  get; set; }
        public bool IsSuccess { get; set; } = true;
        public object Result { get; set; }
        public List<string> ErrorMessage { get; set; } 
    }
}
