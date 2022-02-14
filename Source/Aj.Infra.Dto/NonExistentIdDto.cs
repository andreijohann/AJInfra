namespace Aj.Infra.Dto
{
    public class NonExistentIdDto : ErrorDto
    {
        public NonExistentIdDto()
        {
            Message = "Non-existent ID informed";
            Context = "id";
        }
    }
}
