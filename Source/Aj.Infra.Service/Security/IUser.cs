namespace Aj.Infra.Service.Security
{
    /// <summary>
    /// Interface that represents a minimal set of information about the application user
    /// </summary>
    public interface IUser
    {
        long Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Organization { get; set; }
        string IpAddress { get; set; }
    }
}
