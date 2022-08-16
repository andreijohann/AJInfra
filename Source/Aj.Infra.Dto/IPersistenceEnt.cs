namespace Aj.Infra.Dto
{
    public interface IPersistenceEnt<TId>
    {
        TId Id { get; set; }
    }
}
