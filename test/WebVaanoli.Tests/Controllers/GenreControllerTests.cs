using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using WebVaanoli.Controllers;
using WebVaanoli.Data;
using WebVaanoli.Domain;
using WebVaanoli.Tests.TestHelpers;
using WebVaanoli.ViewModels.Genre;
using Xunit;
using Shouldly;
using System.Linq;
using AutoMapper;
using Microsoft.AspNet.Mvc.ModelBinding;
using System.Collections.Generic;

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

        [Fact]
        public void DetailWithInvalidIdShouldReturnBadRequest()
        {
            // Fixture Setup
            int invalidId = 0;
            var sut = _fixture.Create<GenreController>();

            // Exercise Sut
            var result = sut.Detail(invalidId);

            // Verify Outcome
            result.ShouldBeHttpBadRequest();

            // Fixture Teardown
        }

        [Fact]
        public void DetailWithNonExistingIdShouldReturnHttpNotFound()
        {
            // Fixture Setup
            var nonExistingId = _fixture.Create<int>();
            var mockGenreRepository = _fixture.Freeze<Mock<IGenreRepository>>();
            mockGenreRepository
                .Setup(mock => mock.Find(It.Is<int>(val => val == nonExistingId)))
                .Returns(() => null);

            var sut = _fixture.Create<GenreController>();

            // Exercise Sut
            var result = sut.Detail(nonExistingId);

            // Verify Outcome
            result.ShouldBeHttpNotFound();

            // Fixture Teardown
        }

        [Fact]
        public void DetailShouldReturnViewWithCorrectViewModel()
        {
            // Fixture Setup
            var anyId = _fixture.Create<int>();
            var anyGenre = _fixture.Create<Genre>();
            var anyDetailViewModel = _fixture.Create<DetailViewModel>();

            var mockGenreRepository = _fixture.Freeze<Mock<IGenreRepository>>();
            mockGenreRepository
                .Setup(mock => mock.Find(It.Is<int>(val => val == anyId)))
                .Returns(anyGenre);

            var mockMappingEngine = _fixture.Freeze<Mock<IMappingEngine>>();
            mockMappingEngine.Setup(mock => mock.Map<DetailViewModel>(It.IsAny<Genre>()))
            .Returns(anyDetailViewModel);

            var sut = _fixture.Create<GenreController>();

            // Exercise Sut
            var result = sut.Detail(anyId);

            // Verify Outcome
            result.ShouldBeViewResultWithModelSatisfyingAllConditions<DetailViewModel>(
                actions: viewModel => viewModel.ShouldBe(anyDetailViewModel));

            // Fixture Teardown
        }

        [Fact]
        public void EditWithInvalidIdShouldReturnBadRequest()
        {
            // Fixture Setup
            int invalidId = 0;
            var sut = _fixture.Create<GenreController>();

            // Exercise Sut
            var result = sut.Edit(invalidId);

            // Verify Outcome
            result.ShouldBeHttpBadRequest();

            // Fixture Teardown
        }

        [Fact]
        public void EditWithNonExistingIdShouldReturnHttpNotFound()
        {
            // Fixture Setup
            var nonExistingId = _fixture.Create<int>();
            var mockGenreRepository = _fixture.Freeze<Mock<IGenreRepository>>();
            mockGenreRepository
                .Setup(mock => mock.Find(It.Is<int>(val => val == nonExistingId)))
                .Returns(() => null);

            var sut = _fixture.Create<GenreController>();

            // Exercise Sut
            var result = sut.Edit(nonExistingId);

            // Verify Outcome
            result.ShouldBeHttpNotFound();

            // Fixture Teardown
        }

        [Fact]
        public void EditShouldReturnViewWithCorrectViewModel()
        {
            // Fixture Setup
            var anyId = _fixture.Create<int>();
            var anyGenre = _fixture.Create<Genre>();
            var anyEditorViewModel = _fixture.Create<EditorViewModel>();

            var mockGenreRepository = _fixture.Freeze<Mock<IGenreRepository>>();
            mockGenreRepository
                .Setup(mock => mock.Find(It.Is<int>(val => val == anyId)))
                .Returns(anyGenre);

            var mockMappingEngine = _fixture.Freeze<Mock<IMappingEngine>>();
            mockMappingEngine.Setup(mock => mock.Map<EditorViewModel>(It.IsAny<Genre>()))
            .Returns(anyEditorViewModel);

            var sut = _fixture.Create<GenreController>();

            // Exercise Sut
            var result = sut.Edit(anyId);

            // Verify Outcome
            result.ShouldBeViewResultWithModelSatisfyingAllConditions<EditorViewModel>(
                "editor",
                actions: viewModel => viewModel.ShouldBe(anyEditorViewModel));

            // Fixture Teardown
        }

        [Fact]
        public void AddShouldReturnViewWithCorrectViewModel()
        {
            // Fixture Setup
            var sut = _fixture.Create<GenreController>();

            // Exercise Sut
            var result = sut.Add();

            // Verify Outcome
            result.ShouldBeViewResultWithModel<EditorViewModel>("editor");

            // Fixture Teardown
        }

        [Fact]
        public void SaveWithInvalidViewModelShouldReturnEditorViewWithSameInvlaidViewModel()
        {
            // Fixture Setup
            var invalidEditorViewModel = _fixture.Create<EditorViewModel>();
            var sut = _fixture.Create<GenreController>();
            sut.ModelState.AddModelError("Id", "Some Error");

            // Exercise Sut
            var result = sut.Save(invalidEditorViewModel);

            // Verify Outcome
            result.ShouldBeViewResultWithModelSatisfyingAllConditions<EditorViewModel>(
                "editor",
                actions: viewModel => viewModel.ShouldBe(invalidEditorViewModel));

            // Fixture Teardown
        }

        [Fact]
        public void SaveWithViewModelIdZeroShouldAddNewGenreSuccessfullyAndReturnToDetailsView()
        {
            // Fixture Setup
            var anyGenre = _fixture.Build<Genre>()
                .With(genre => genre.Id, 0)
                .Create();

            var anyNewId = _fixture.Create<int>();

            var anyEditorViewModel = _fixture.Create<EditorViewModel>();

            _fixture.Map(anyEditorViewModel, anyGenre);

            var mockGenreRepository = _fixture.Freeze<Mock<IGenreRepository>>();
            mockGenreRepository
                .Setup(mock => mock.Add(It.Is<Genre>(val => val == anyGenre)))
                .Returns(anyNewId)
                .Verifiable();

            var sut = _fixture.Create<GenreController>();

            // Exercise Sut
            var result = sut.Save(anyEditorViewModel);

            // Verify Outcome
            mockGenreRepository.VerifyAll();
            result.ShouldBeRedirectToActionResult(actionName: "Detail", routeValues: new Dictionary<string, object>() { ["id"] = anyNewId });
            
            // Fixture Teardown
        }
    }
}
