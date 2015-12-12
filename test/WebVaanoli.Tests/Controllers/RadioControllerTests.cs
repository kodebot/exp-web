using AutoMapper;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.ViewFeatures;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Shouldly;
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
            var viewResult = result as ViewResult;
            viewResult.ShouldNotBe(null);
            viewResult.ViewName.ShouldBe(null); // Indicates default view name
            var indexViewModel = viewResult.ViewData.Model as IndexViewModel;
            indexViewModel.ShouldNotBe(null);
            indexViewModel.Radios.ShouldBe(manyRadios);
            
            // Fixture Teardown
        }

        
        [Fact]
        public void DetailWithInvalidIdShouldReturnBadRequest()
        {
            // Fixture Setup
            var invalidId = 0;
            
            var sut = _fixture.Create<RadioController>();
            
            // Exercise Sut
            var result = sut.Details(invalidId);

            // Verify Outcome
            var badRequest = result as BadRequestResult;
            badRequest.ShouldNotBe(null);
            
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
            var result = sut.Details(nonExistentId);

            // Verify Outcome
            var notFoundResult = result as HttpNotFoundResult;
            notFoundResult.ShouldNotBe(null);

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
            var result = sut.Details(anyId);

            // Verify Outcome
            var viewResult = result as ViewResult;
            viewResult.ShouldNotBe(null);
            viewResult.ViewName.ShouldBe(null); // Indicates default view name
            var detailViewModel = viewResult.ViewData.Model as DetailViewModel;
            detailViewModel.ShouldNotBe(null);
            detailViewModel.Id.ShouldBe(anyRadio.Id);

            // Fixture Teardown
        }
    }
}
