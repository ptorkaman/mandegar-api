﻿namespace Mandegar.Utilities.Models
{
    public class Result
    {
        public Result()
        {
            Success = false;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
