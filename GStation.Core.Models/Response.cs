﻿namespace GStation.Core.Models
{
    public class Response<T>
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string MessageError { get; set; }
    }
}
