namespace Aj.Infra.Dto
{
    public class UnauthorizedUserDto : ErrorDto
    {
        public UnauthorizedUserDto()
        {
            Message = "User does not have permission to perform this action.";
            Context = "security";
        }
    }
}
