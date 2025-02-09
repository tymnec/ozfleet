namespace OZFleet.Core.Interfaces
{
    public interface IFleetRepository
    {
        Task AddFleetAsync(Fleet fleet);
        Task RemoveFleetAsync(int fleetId);
        Task<Fleet> GetFleetByIdAsync(int fleetId);
        Task<IEnumerable<Fleet>> GetAllFleetsAsync();
    }
}
