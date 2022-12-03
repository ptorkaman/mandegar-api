namespace Mandegar.Utilities.Models
{
    public class EmailOptionVM
    {
        public string Host { get; set; }
        public int Port { get; set; } = 25;
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsHTML { get; set; } = true;
        public bool IsSSL { get; set; } = true;
        public string Password { get; set; }
        public string UserName { get; internal set; }
    }
}
