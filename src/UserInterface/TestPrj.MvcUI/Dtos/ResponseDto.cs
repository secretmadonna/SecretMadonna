namespace SecretMadonna.TestPrj.MvcUI.Dtos
{
    public class ResponseDto<Data>
    {
        public string ret { get; set; }
        public string msg { get; set; }
        public Data data { get; set; }
    }
}
