using AutoMapper;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ViewFeatures;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Shouldly;
using System;
using System.Linq;
using WebVaanoli.Controllers;
using WebVaanoli.Data;
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
            var invalidId = 0;

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
            int nonExistentId = _fixture.Create<int>();

            var mockRadioRepository = _fixture.Freeze<Mock<IRadioRepository>>();
            mockRadioRepository.Setup(mock => mock.Find(It.Is<int>(id => id == nonExistentId))).Returns(() => null);

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
            var anyId = _fixture.Create<int>();

            var anyRadio = _fixture.Build<Radio>()
                .With(item => item.Id, anyId)
                .Create();

            var mockRadioRepository = _fixture.Freeze<Mock<IRadioRepository>>();
            mockRadioRepository.Setup(mock => mock.Find(It.Is<int>(id => id == anyId))).Returns(anyRadio);

            Mapper.CreateMap(typeof(Radio), typeof(DetailViewModel));

            var sut = _fixture.Create<RadioController>();

            // Exercise Sut
            var result = sut.Detail(anyId);

            // Verify Outcome
            result.ShouldBeViewResultWithModelSatisfyingAllConditions<DetailViewModel>(
                actions: model => model.Id.ShouldBe(anyRadio.Id));

            // Fixture Teardown
        }

        [Fact]
        public void EditWithInvalidIdShouldReturnNotFound()
        {
            // Fixture Setup
            var invalidId = _fixture.Create<int>();

            var mockRadioRepository = _fixture.Freeze<Mock<IRadioRepository>>();
            mockRadioRepository.Setup(mock => mock.Find(It.Is<int>(value => value == invalidId)))
                .Returns(() => null);

            var sut = _fixture.Create<RadioController>();

            // Exercise Sut
            var result = sut.Edit(invalidId);

            // Verify Outcome
            result.ShouldBeHttpNotFound();

            // Fixture Teardown
        }

        [Fact]
        public void EditShouldReturnDefaultView()
        {

            // Fixture Setup

            // Exercise Sut

            // Verify Outcome

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
            result.ShouldBeViewResultWithViewName("Editor");

            // Fixture Teardown
        }
    }
}
