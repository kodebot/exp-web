using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using System;
using System.Linq.Expressions;
using WebVaanoli.Data.Interfaces;
using WebVaanoli.Domain;
using Xunit;

namespace WebVaanoli.Data.Tests
{
    public class StreamQualityRepositoryTests
    {
        private readonly IFixture _fixture;
        public StreamQualityRepositoryTests()
        {
            _fixture = new Fixture()
                .Customize(new AutoMoqCustomization());
        }

        [Fact]
        public void AddShouldAddStreamQualityCorrectly()
        {
            // Fixture Setup
            var anyStreamQuality = _fixture.Create<StreamQuality>();

            var mockFirebaseRepository = _fixture.Freeze<Mock<IFirebaseRepository<StreamQuality>>>();
            mockFirebaseRepository.Setup(mock => mock.Add(anyStreamQuality))
                .Verifiable();

            var sut = _fixture.Create<StreamQualityRepository>();

            // Exercise Sut
            sut.Add(anyStreamQuality);

            // Verify Outcome
            mockFirebaseRepository.VerifyAll();

            // Fixture Teardown
        }

        [Fact]
        public void FindShouldReturnStreamQualityCorrectly()
        {
            // Fixture Setup
            var anyId = _fixture.Create<string>();

            var mockFirebaseRepository = _fixture.Freeze<Mock<IFirebaseRepository<StreamQuality>>>();
            mockFirebaseRepository.Setup(mock => mock.Find(anyId))
                .Verifiable();

            var sut = _fixture.Create<StreamQualityRepository>();

            // Exercise Sut
            sut.Find(anyId);

            // Verify Outcome
            mockFirebaseRepository.VerifyAll();

            // Fixture Teardown
        }

        [Fact]
        public void FindAllShouldReturnStreamQualitysCorrectly()
        {
            // Fixture Setup
            Expression<Func<StreamQuality, bool>> anyFilter = item => item.Id == "0";

            var mockFirebaseRepository = _fixture.Freeze<Mock<IFirebaseRepository<StreamQuality>>>();
            mockFirebaseRepository.Setup(mock => mock.FindAll(anyFilter))
                .Verifiable();

            var sut = _fixture.Create<StreamQualityRepository>();

            // Exercise Sut
            sut.FindAll(anyFilter);

            // Verify Outcome
            mockFirebaseRepository.VerifyAll();

            // Fixture Teardown
        }

        [Fact]
        public void SaveShouldSaveStreamQualityCorrectly()
        {
            // Fixture Setup
            var anyStreamQuality = _fixture.Create<StreamQuality>();

            var mockFirebaseRepository = _fixture.Freeze<Mock<IFirebaseRepository<StreamQuality>>>();
            mockFirebaseRepository.Setup(mock => mock.Save(anyStreamQuality))
                .Verifiable();

            var sut = _fixture.Create<StreamQualityRepository>();

            // Exercise Sut
            sut.Save(anyStreamQuality);

            // Verify Outcome
            mockFirebaseRepository.VerifyAll();

            // Fixture Teardown
        }


    }
}
