using RTATS.Application.Interfaces;


namespace RTATS.Infrastructure.Repositories;

public sealed class UnitOfWork : IUnitOfWork
{
    private Application.Interfaces.IRealtimeAirlineTrafficSystemRepository _realtimeAirlineTrafficSystem;


    // Initialize All Interfaces Here
    public IRealtimeAirlineTrafficSystemRepository RealtimeAirlineTrafficSystemRepository
    { get { var realtimeAirlineTrafficSystemRepo = _realtimeAirlineTrafficSystem == null;
        _realtimeAirlineTrafficSystem = realtimeAirlineTrafficSystemRepo ? new RealtimeAirlineTrafficSystemRepository() :
            _realtimeAirlineTrafficSystem; return _realtimeAirlineTrafficSystem; } }


}

