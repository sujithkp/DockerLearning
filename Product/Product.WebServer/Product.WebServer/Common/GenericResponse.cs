﻿namespace Product.WebServer.Common
{
    public class GenericResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
