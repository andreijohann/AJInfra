using Aj.Infra.Dto;

namespace Aj.Infra.Service.Security
{
    /// <summary>
    /// Interface that represents a minimal set of actions on the application user
    /// </summary>
    public interface IUserService
    {
        IUser GetCurrentUser();
        ResultDto hasPermission(IUser user, string sisObjectAction);
        ResultDto hasPermission(string sisObjectAction);
        ResultDto hasRole(IUser user, string sisRole);
        ResultDto hasRole(string sisRole);
    }
}
