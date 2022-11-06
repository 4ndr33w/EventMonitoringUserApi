namespace UsersAPI.Models.Dto
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; } = true;

        public List<string> ErrorMessages { get; set; }
        public object Result { get; set; }

        public string DisplayMessage { get; set; } = "";
    }
}
