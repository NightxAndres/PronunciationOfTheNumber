namespace PronunciationOfTheNumber.Models
{
    public class RequestNumber
    {
        public long number { get; set; }
    }

    public class ResponseNumber {
        public string pronunciation { get; set; }
    }

    public class AccessData
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
