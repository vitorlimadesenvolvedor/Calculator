using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTOs
{

    public class GenericResponse
    {
        public GenericResponse(bool success, string message, object data = null)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; }
        public string Message { get; }
        public object Data { get; }

    }
}
