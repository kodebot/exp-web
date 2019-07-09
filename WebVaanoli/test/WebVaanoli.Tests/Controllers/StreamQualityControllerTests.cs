using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using WebVaanoli.Controllers;
using WebVaanoli.Domain;
using WebVaanoli.Tests.TestHelpers;
using WebVaanoli.ViewModels.StreamQuality;
using Xunit;
using Shouldly;
using System.Linq;
using AutoMapper;
using System.Collections.Generic;
using System;
using WebVaanoli.Data.Interfaces;

namespace WebVaanoli.Tests.Controllers
{
    public class StreamQualityControllerTests
    {
        private const int Many = 3;
        private readonly IFixture _fixture;

        public StreamQualityControllerTests()
        {
            _fixture = new Fixture()
                .Customize(new AutoMoqCustomization())
                .Customize(new MvcCustomization());
        }

        [Fact]
        public void IndexShouldReturnDefaultViewModelWithCorrectIndexViewModel()
        {
            // Fixture Setup
            var manyStreamQualities = _fixture.CreateMany<StreamQuality>(Many);

            var mockStreamQualityRepository = _fixture.Freeze<Mock<IStreamQualityRepository>>();
            mockStreamQualityRepository.Setup(mock => mock.FindAll(null)).Returns(manyStreamQualities.AsQueryable());

            var sut = _fixture.Create<StreamQualityController>();

            // Exercise System
            var result = sut.Index();

            // Verify Outcome
            result.ShouldBeViewResultWithModelSatisfyingAllConditions<IndexViewModel>(
                actions: viewModel => viewModel.StreamQualities.ShouldBe(manyStreamQualities));

            // Fixture Teardown
        }

        [Fact]
        public void DetailWithInvalidIdShouldReturnBadRequest()
        {
            // Fixture Setup
            string invalidId = String.Empty;
            var sut = _fixture.Create<StreamQualityController>();

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
            var nonExistingId = _fixture.Create<string>();
            var mockStreamQualityRepository = _fixture.Freeze<Mock<IStreamQualityRepository>>();
            mockStreamQualityRepository
                .Setup(mock => mock.Find(It.Is<string>(val => val == nonExistingId)))
                .Returns(() => null);

            var sut = _fixture.Create<StreamQualityController>();

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
            var anyId = _fixture.Create<string>();
            var anyStreamQuality = _fixture.Create<StreamQuality>();
            var anyDetailViewModel = _fixture.Create<DetailViewModel>();

            var mockStreamQualityRepository = _fixture.Freeze<Mock<IStreamQualityRepository>>();
            mockStreamQualityRepository
                .Setup(mock => mock.Find(It.Is<string>(val => val == anyId)))
                .Returns(anyStreamQuality);

            var mockMappingEngine = _fixture.Freeze<Mock<IMappingEngine>>();
            mockMappingEngine.Setup(mock => mock.Map<DetailViewModel>(It.IsAny<StreamQuality>()))
            .Returns(anyDetailViewModel);

            var sut = _fixture.Create<StreamQualityController>();

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
            string invalidId = String.Empty;
            var sut = _fixture.Create<StreamQualityController>();

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
            var nonExistingId = _fixture.Create<string>();
            var mockStreamQualityRepository = _fixture.Freeze<Mock<IStreamQualityRepository>>();
            mockStreamQualityRepository
                .Setup(mock => mock.Find(It.Is<string>(val => val == nonExistingId)))
                .Returns(() => null);

            var sut = _fixture.Create<StreamQualityController>();

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
            var anyId = _fixture.Create<string>();
            var anyStreamQuality = _fixture.Create<StreamQuality>();
            var anyEditorViewModel = _fixture.Create<EditorViewModel>();

            var mockStreamQualityRepository = _fixture.Freeze<Mock<IStreamQualityRepository>>();
            mockStreamQualityRepository
                .Setup(mock => mock.Find(It.Is<string>(val => val == anyId)))
                .Returns(anyStreamQuality);

            var mockMappingEngine = _fixture.Freeze<Mock<IMappingEngine>>();
            mockMappingEngine.Setup(mock => mock.Map<EditorViewModel>(It.IsAny<StreamQuality>()))
            .Returns(anyEditorViewModel);

            var sut = _fixture.Create<StreamQualityController>();

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
            var sut = _fixture.Create<StreamQualityController>();

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
            var sut = _fixture.Create<StreamQualityController>();
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
        public void SaveWithEmptyIdShouldAddNewStreamQualitySuccessfullyAndReturnToDetailsView()
        {
            // Fixture Setup
            var anyStreamQuality = _fixture.Build<StreamQuality>()
                .With(streamQuality => streamQuality.Id, String.Empty)
                .Create();

            var anyNewId = _fixture.Create<string>();

            var anyEditorViewModel = _fixture.Create<EditorViewModel>();

            _fixture.Map(anyEditorViewModel, anyStreamQuality);

            var mockStreamQualityRepository = _fixture.Freeze<Mock<IStreamQualityRepository>>();
            mockStreamQualityRepository
                .Setup(mock => mock.Add(It.Is<StreamQuality>(val => val == anyStreamQuality)))
                .Returns(anyNewId)
                .Verifiable();

            var sut = _fixture.Create<StreamQualityController>();

            // Exercise Sut
            var result = sut.Save(anyEditorViewModel);

            // Verify Outcome
            mockStreamQualityRepository.VerifyAll();
            result.ShouldBeRedirectToActionResult(actionName: "Detail", routeValues: new Dictionary<string, object>() { ["id"] = anyNewId });

            // Fixture Teardown
        }

        [Fact]
        public void SaveWithEmptyIdThrowingExceptionShouldReturnEditorViewWithError()
        {
            // Fixture Setup
            var anyStreamQuality = _fixture.Build<StreamQuality>()
                .With(streamQuality => streamQuality.Id, String.Empty)
                .Create();

            var anyNewId = _fixture.Create<string>();

            var anyEditorViewModel = _fixture.Create<EditorViewModel>();

            _fixture.Map(anyEditorViewModel, anyStreamQuality);

            var mockStreamQualityRepository = _fixture.Freeze<Mock<IStreamQualityRepository>>();
            mockStreamQualityRepository
                .Setup(mock => mock.Add(It.Is<StreamQuality>(val => val == anyStreamQuality)))
                .Throws(new Exception())
                .Verifiable();

            var sut = _fixture.Create<StreamQualityController>();

            // Exercise Sut
            var result = sut.Save(anyEditorViewModel);

            // Verify Outcome
            mockStreamQualityRepository.VerifyAll();
            result.ShouldBeViewResultWithModelSatisfyingAllConditions<EditorViewModel>(
                "editor",
                actions: viewModel => viewModel.ShouldBe(anyEditorViewModel));
            sut.ModelState.IsValid.ShouldBe(false);
            // Fixture Teardown
        }

        [Fact]
        public void SaveWithExistingIdShouldUpdateStreamQualitySuccessfullyAndReturnToDetailsView()
        {
            // Fixture Setup
            var anyStreamQuality = _fixture.Create<StreamQuality>();

            var anyEditorViewModel = _fixture.Create<EditorViewModel>();

            _fixture.Map(anyEditorViewModel, anyStreamQuality);

            var mockStreamQualityRepository = _fixture.Freeze<Mock<IStreamQualityRepository>>();
            mockStreamQualityRepository
                .Setup(mock => mock.Save(It.Is<StreamQuality>(val => val == anyStreamQuality)))
                .Verifiable();

            var sut = _fixture.Create<StreamQualityController>();

            // Exercise Sut
            var result = sut.Save(anyEditorViewModel);

            // Verify Outcome
            mockStreamQualityRepository.VerifyAll();
            result.ShouldBeRedirectToActionResult(actionName: "Detail", routeValues: new Dictionary<string, object>() { ["id"] = anyStreamQuality.Id });

            // Fixture Teardown
        }

        [Fact]
        public void SaveWithExistingIdThrowingExceptionShouldReturnEditorViewWithError()
        {
            // Fixture Setup
            var anyStreamQuality = _fixture.Create<StreamQuality>();

            var anyEditorViewModel = _fixture.Create<EditorViewModel>();

            _fixture.Map(anyEditorViewModel, anyStreamQuality);

            var mockStreamQualityRepository = _fixture.Freeze<Mock<IStreamQualityRepository>>();
            mockStreamQualityRepository
                .Setup(mock => mock.Save(It.Is<StreamQuality>(val => val == anyStreamQuality)))
                .Throws(new Exception())
                .Verifiable();

            var sut = _fixture.Create<StreamQualityController>();

            // Exercise Sut
            var result = sut.Save(anyEditorViewModel);

            // Verify Outcome
            mockStreamQualityRepository.VerifyAll();
            result.ShouldBeViewResultWithModelSatisfyingAllConditions<EditorViewModel>(
                "editor",
                actions: viewModel => viewModel.ShouldBe(anyEditorViewModel));

            // Fixture Teardown
        }
    }
}
