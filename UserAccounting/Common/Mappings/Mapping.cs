using AutoMapper;

namespace UserAccounting.Common.Mappings
{
    public static class Mapping
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod!.IsPublic || p.GetMethod!.IsAssembly;
                cfg.AddProfile<AccountMappingProfile>();
            });
            var mapper = new Mapper(config);

            return mapper;
        });
        public static IMapper Mapper => Lazy.Value;
    }
}
