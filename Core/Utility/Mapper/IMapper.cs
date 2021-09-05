namespace Core.Utility.Mapper
{
    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
    }
}