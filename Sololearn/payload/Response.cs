using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoloLearn.payload
{
    public class Response<T>
    {

        public bool Success { get; set; } = false;
        public T Data { get; set; }
        public IList<string> Errors { get; set; }

        //RESPONSE WITH bool (SUCCESS OR FAIL)
        private Response(bool success)
        {
            Success = success;
        }


        //SUCCESS RESPONSE WITH DATA
        private Response(T data, bool success)
        {
            Data = data;
            Success = success;
        }


        //ERROR RESPONSE WITH MESSAGE AND ERROR CODE
        private Response(string errorMsg)
        {
            Success = false;
            Errors = new List<string>();
        }

        //ERROR RESPONSE WITH ERROR DATA LIST
        private Response(IList<string> errors)
        {
            Success = false;
            Errors = errors;
        }

        public static Response<T> successResponse(T data)
        {
            return new Response<T>(data, true);
        }

        public static Response<T> successResponse()
        {
            return new Response<T>(true);
        }

        public static Response<T> errorResponse(string error)
        {
            return new Response<T>(error);
        }

        public static Response<T> errorResponse(IList<string> errors)
        {
            return new Response<T>(errors);
        }


    }

}
