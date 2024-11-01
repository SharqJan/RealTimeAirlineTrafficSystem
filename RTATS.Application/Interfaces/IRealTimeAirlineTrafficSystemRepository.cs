using RTATS.Core.Entities;

namespace RTATS.Application.Interfaces;


public interface IRealtimeAirlineTrafficSystemRepository
{
    Task<long> AddRealTimeAirlineTrafficSystem(CancellationToken token, Pagination pagination);
}
