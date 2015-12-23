using AutoMapper;
using Moq;
using Ploeh.AutoFixture;

namespace WebVaanoli.Tests.TestHelpers
{
    public static class FixtureExtensions
    {
        public static void Map<TDestination>(this IFixture fixture, object source, TDestination destination)
        {
            var mockMappingEngine = fixture.Freeze<Mock<IMappingEngine>>();
            mockMappingEngine.Setup(mock => mock.Map<TDestination>(source))
                .Returns(destination);
        }
    }
}
