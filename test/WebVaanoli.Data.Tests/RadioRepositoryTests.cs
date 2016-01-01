using FireSharp.Interfaces;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.SemanticComparison;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using WebVaanoli.Data.Interfaces;
using WebVaanoli.Data.Tests.TestHelpers;
using WebVaanoli.Domain;
using Xunit;

namespace WebVaanoli.Data.Tests
{
    public class RadioRepositoryTests
    {
        private readonly IFixture _fixture;
        public RadioRepositoryTests()
        {
            _fixture = new Fixture()
                .Customize(new AutoMoqCustomization());
        }

        [Fact]
        public void AddShouldAddRadioCorrectly()
        {
            // Fixture Setup
            var anyRadio = _fixture.Create<Radio>();

            var mockFirebaseRepository = _fixture.Freeze<Mock<IFirebaseRepository<Radio>>>();
            mockFirebaseRepository.Setup(mock => mock.Add(anyRadio))
                .Verifiable();

            var sut = _fixture.Create<RadioRepository>();

            // Exercise Sut
            sut.Add(anyRadio);

            // Verify Outcome
            mockFirebaseRepository.VerifyAll();

            // Fixture Teardown
        }

        [Fact]
        public void FindShouldReturnRadioCorrectly()
        {
            // Fixture Setup
            var anyId = _fixture.Create<string>();

            var mockFirebaseRepository = _fixture.Freeze<Mock<IFirebaseRepository<Radio>>>();
            mockFirebaseRepository.Setup(mock => mock.Find(anyId))
                .Verifiable();

            var sut = _fixture.Create<RadioRepository>();

            // Exercise Sut
            sut.Find(anyId);

            // Verify Outcome
            mockFirebaseRepository.VerifyAll();

            // Fixture Teardown
        }

        [Fact]
        public void FindAllShouldReturnRadiosCorrectly()
        {
            // Fixture Setup
            Expression<Func<Radio, bool>> anyFilter = item => item.Id == "0";

            var mockFirebaseRepository = _fixture.Freeze<Mock<IFirebaseRepository<Radio>>>();
            mockFirebaseRepository.Setup(mock => mock.FindAll(anyFilter))
                .Verifiable();

            var sut = _fixture.Create<RadioRepository>();

            // Exercise Sut
            sut.FindAll(anyFilter);

            // Verify Outcome
            mockFirebaseRepository.VerifyAll();

            // Fixture Teardown
        }

        [Fact]
        public void SaveShouldSaveRadioCorrectly()
        {
            // Fixture Setup
            var anyRadio = _fixture.Create<Radio>();

            var mockFirebaseRepository = _fixture.Freeze<Mock<IFirebaseRepository<Radio>>>();
            mockFirebaseRepository.Setup(mock => mock.Save(anyRadio))
                .Verifiable();

            var sut = _fixture.Create<RadioRepository>();

            // Exercise Sut
            sut.Save(anyRadio);

            // Verify Outcome
            mockFirebaseRepository.VerifyAll();

            // Fixture Teardown
        }


    }
}
