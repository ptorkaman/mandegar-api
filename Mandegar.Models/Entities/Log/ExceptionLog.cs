using System;
using System.ComponentModel.DataAnnotations;

namespace Mandegar.Models.Entities.Log
{
    public class ExceptionLog
    {
        public ExceptionLog()
        {
            CreatedOn = DateTime.Now;
        }

        [Key]
        public long Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Request { get; set; }
        public string Message { get; set; }
        public string Exception { get; set; }
        public string Source { get; set; }
        public string StackTrace { get; set; }
        public string Url { get; set; }
    }
}
