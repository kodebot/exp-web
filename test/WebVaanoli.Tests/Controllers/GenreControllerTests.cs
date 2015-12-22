using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using System;
using WebVaanoli.Controllers;
using WebVaanoli.Data;
using WebVaanoli.Domain;
using WebVaanoli.Tests.TestHelpers;
using WebVaanoli.ViewModels.Genre;
using Xunit;
using Shouldly;
using System.Linq;

namespace WebVaanoli.Tests.Controllers
{
    public class GenreControllerTests
    {
        private const int _MANY = 3;
        private readonly IFixture _fixture;

        public GenreControllerTests()
        {
            _fixture = new Fixture()
                .Customize(new AutoMoqCustomization())
                .Customize(new MvcCustomization());
        }

        [Fact]
        public void IndexShouldReturnDefaultViewModelWithCorrectIndexViewModel()
        {
            // Fixture Setup
            var manyGenres = _fixture.CreateMany<Genre>(_MANY);

            var mockGenreRepository = _fixture.Freeze<Mock<IGenreRepository>>();
            mockGenreRepository.Setup(mock => mock.FindAll(null)).Returns(manyGenres.AsQueryable());

            var sut = _fixture.Create<GenreController>();

            // Exercise System
            var result = sut.Index();

            // Verify Outcome
            result.ShouldBeViewResultWithModelSatisfyingAllConditions<IndexViewModel>(
                actions: viewModel => viewModel.Genres.ShouldBe(manyGenres));

            // Fixture Teardown
        }


    }
}
