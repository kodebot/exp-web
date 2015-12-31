using AutoMapper;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Shouldly;
using System;
using System.Linq;
using WebVaanoli.Controllers;
using WebVaanoli.Data.Interfaces;
using WebVaanoli.Domain;
using WebVaanoli.Tests.TestHelpers;
using WebVaanoli.ViewModels.Radio;
using Xunit;

namespace WebVaanoli.Tests.Controllers
{
    public class RadioControllerTests
    {
        private const int _MANY = 3;
        private readonly IFixture _fixture;
        public RadioControllerTests()
        {
            _fixture = new Fixture()
                .Customize(new AutoMoqCustomization())
                .Customize(new MvcCustomization());
        }

        [Fact]
        public void IndexShouldReturnTheDefaultViewWithCorrectViewModel()
        {
            // Fixture Setup
            var manyRadios = _fixture.CreateMany<Radio>(_MANY);
            var mockRadioRepository = _fixture.Freeze<Mock<IRadioRepository>>();
            mockRadioRepository.Setup(mock => mock.FindAll(null)).Returns(manyRadios.AsQueryable());

            var sut = _fixture.Create<RadioController>();

            // Exercise Sut
            var result = sut.Index();

            // Verify Outcome
            result.ShouldBeViewResultWithModelSatisfyingAllConditions<IndexViewModel>(
                actions: model => model.Radios.ShouldBe(manyRadios));

            // Fixture Teardown
        }


        [Fact]
        public void DetailWithInvalidIdShouldReturnBadRequest()
        {
            // Fixture Setup
            var invalidId = String.Empty;

            var sut = _fixture.Create<RadioController>();

            // Exercise Sut
            var result = sut.Detail(invalidId);

            // Verify Outcome
            result.ShouldBeHttpBadRequest();

            // Fixture Teardown
        }

        [Fact]
        public void DetailWithIdWhichDoesntExistShouldReturnNotFound()
        {
            // Fixture Setup
            var nonExistentId = _fixture.Create<string>();

            var mockRadioRepository = _fixture.Freeze<Mock<IRadioRepository>>();
            mockRadioRepository.Setup(mock => mock.Find(It.Is<string>(id => id == nonExistentId))).Returns(() => null);

            var sut = _fixture.Create<RadioController>();

            // Exercise Sut
            var result = sut.Detail(nonExistentId);

            // Verify Outcome
            result.ShouldBeHttpNotFound();

            // Fixture Teardown
        }

        [Fact]
        public void DetailWithValidIdShouldReturnDefaultViewWithCorrectDetailViewModel()
        {
            // Fixture Setup
            var anyId = _fixture.Create<string>();

            var anyRadio = _fixture.Build<Radio>()
                .With(item => item.Id, anyId)
                .Create();

            var anyDetailViewModel = _fixture.Create<DetailViewModel>();

            var mockRadioRepository = _fixture.Freeze<Mock<IRadioRepository>>();
            mockRadioRepository.Setup(mock => mock.Find(It.Is<string>(id => id == anyId))).Returns(anyRadio);

            var mockMappingEngine = _fixture.Freeze<Mock<IMappingEngine>>();
            mockMappingEngine.Setup(mock => mock.Map<DetailViewModel>(It.Is<Radio>(val => val == anyRadio)))
            .Returns(anyDetailViewModel);

            var sut = _fixture.Create<RadioController>();

            // Exercise Sut
            var result = sut.Detail(anyId);

            // Verify Outcome
            result.ShouldBeViewResultWithModelSatisfyingAllConditions<DetailViewModel>(
                actions: model => model.ShouldBe(anyDetailViewModel));

            // Fixture Teardown
        }

        [Fact]
        public void EditWithNonExistingIdShouldReturnNotFound()
        {
            // Fixture Setup
            var invalidId = _fixture.Create<string>();

            var mockRadioRepository = _fixture.Freeze<Mock<IRadioRepository>>();
            mockRadioRepository.Setup(mock => mock.Find(It.Is<string>(value => value == invalidId)))
                .Returns(() => null);

            var sut = _fixture.Create<RadioController>();

            // Exercise Sut
            var result = sut.Edit(invalidId);

            // Verify Outcome
            result.ShouldBeHttpNotFound();

            // Fixture Teardown
        }

        [Fact]
        public void EditWithInvalidIdShouldReturnNotFound()
        {
            // Fixture Setup
            var invalidId = String.Empty;

            var mockRadioRepository = _fixture.Freeze<Mock<IRadioRepository>>();
            mockRadioRepository.Setup(mock => mock.Find(It.Is<string>(value => value == invalidId)))
                .Returns(() => null);

            var sut = _fixture.Create<RadioController>();

            // Exercise Sut
            var result = sut.Edit(invalidId);

            // Verify Outcome
            result.ShouldBeHttpBadRequest();

            // Fixture Teardown
        }

        [Fact]
        public void EditShouldReturnEditorView()
        {

            // Fixture Setup
            var anyId = _fixture.Create<string>();
            var anyRadio = _fixture.Create<Radio>();
            var anyEditorViewModel = _fixture.Create<EditorViewModel>();

            var mockRadioRepository = _fixture.Freeze<Mock<IRadioRepository>>();
            mockRadioRepository
                .Setup(mock => mock.Find(It.Is<string>(val => val == anyId)))
                .Returns(anyRadio);

            var mockMappingEngine = _fixture.Freeze<Mock<IMappingEngine>>();
            mockMappingEngine.Setup(mock => mock.Map<EditorViewModel>(It.Is<Radio>(val => val == anyRadio)))
            .Returns(anyEditorViewModel);

            var sut = _fixture.Create<RadioController>();

            // Exercise Sut
            var result = sut.Edit(anyId);

            // Verify Outcome
            result.ShouldBeViewResultWithModelSatisfyingAllConditions<EditorViewModel>(
                "editor",
                viewModel => viewModel.ShouldBe(anyEditorViewModel));

            // Fixture Teardown
        }

        [Fact]
        public void AddShouldReturnEditorView()
        {
            // Fixture Setup
            var sut = _fixture.Create<RadioController>();

            // Exercise Sut
            var result = sut.Add();

            // Verify Outcome
            result.ShouldBeViewResultWithModel<EditorViewModel>("Editor");

            // Fixture Teardown
        }
    }
}
