namespace PanKunik.CleanArchitecture.BuildingBlocks;

public interface IDomainEvent
{
    public DateTime OccuredOn { get; }
}