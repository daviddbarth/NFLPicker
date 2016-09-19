namespace NFLPicker.Errors
{
    public class Error : Entity
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
    }
}
