namespace SecretMadonna.TestPrj.MvcUI.Vos
{
    public class ErrorVo
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
