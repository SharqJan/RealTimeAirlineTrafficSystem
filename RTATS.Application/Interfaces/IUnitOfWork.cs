namespace RTATS.Application.Interfaces;

public interface IUnitOfWork
    {
    //ICustomizationRepository CustomizationRepository { get; }
    IRealtimeAirlineTrafficSystemRepository RealtimeAirlineTrafficSystemRepository { get; }
}

