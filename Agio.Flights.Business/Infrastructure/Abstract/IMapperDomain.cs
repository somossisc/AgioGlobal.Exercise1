namespace Agio.Flights.Business.Infrastructure.Abstract
{
    public interface IMapperDomain
    {
        TDestination Map<TSource, TDestination>(TSource origin);
    }
}
