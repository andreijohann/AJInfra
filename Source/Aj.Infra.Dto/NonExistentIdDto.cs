namespace Aj.Infra.Dto
{
    public class NonExistentIdDto : ErrorDto
    {
        public NonExistentIdDto()
        {
            Message = "Non-existent ID informed";
            Context = "id";
        }

        public NonExistentIdDto(string message, string context = "id")
        {
            Message = message;
            Context = context;
        }
    }
}
