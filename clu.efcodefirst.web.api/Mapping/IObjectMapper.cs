namespace clu.efcodefirst.web.api.Mapping
{
    public interface IObjectMapper
    {
        void Configure();

        TDestination Map<TDestination>(object input);

        TDestination Map<TSource, TDestination>(TSource input);

        TDestination Map<TSource, TDestination>(TSource input, TDestination destination);
    }
}
