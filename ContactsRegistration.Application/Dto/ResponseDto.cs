using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace ContactsRegistration.Application.Dto
{
    /// <summary>
    /// Dto to be use as a response base
    /// </summary>
    public class ResponseDto
    {
        public int StatusCode { get; set; } = (int)HttpStatusCode.OK;

        public string Message { get; set; }

        /// <summary>
        /// Returns a default success message
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static ResponseDto ResponseSuccess(string message = "OK")
            => new()
            {
                Message = message,
                StatusCode = (int)HttpStatusCode.OK
            };

        public static ResponseDto ResponseError(string errorMessage, int statusCode = (int)HttpStatusCode.InternalServerError)
            => new()
            {
                Message = errorMessage,
                StatusCode = statusCode
            };
    }
}
