﻿
namespace App_Api.Business
{
    public class Response<T> where T : class
    {
        public string Message { get; set; }

        public ResultStatus Status { get; set; }

        public T Result { get; set; }
    }
}
