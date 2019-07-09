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
    public class GenreRepositoryTests
    {
        private readonly IFixture _fixture;
        public GenreRepositoryTests()
        {
            _fixture = new Fixture()
                .Customize(new AutoMoqCustomization());
        }

        [Fact]
        public void AddShouldAddGenreCorrectly()
        {
            // Fixture Setup
            var anyGenre = _fixture.Create<Genre>();

            var mockFirebaseRepository = _fixture.Freeze<Mock<IFirebaseRepository<Genre>>>();
            mockFirebaseRepository.Setup(mock => mock.Add(anyGenre))
                .Verifiable();

            var sut = _fixture.Create<GenreRepository>();

            // Exercise Sut
            sut.Add(anyGenre);

            // Verify Outcome
            mockFirebaseRepository.VerifyAll();

            // Fixture Teardown
        }

        [Fact]
        public void FindShouldReturnGenreCorrectly()
        {
            // Fixture Setup
            var anyId = _fixture.Create<string>();

            var mockFirebaseRepository = _fixture.Freeze<Mock<IFirebaseRepository<Genre>>>();
            mockFirebaseRepository.Setup(mock => mock.Find(anyId))
                .Verifiable();

            var sut = _fixture.Create<GenreRepository>();

            // Exercise Sut
            sut.Find(anyId);

            // Verify Outcome
            mockFirebaseRepository.VerifyAll();

            // Fixture Teardown
        }

        [Fact]
        public void FindAllShouldReturnGenresCorrectly()
        {
            // Fixture Setup
            Expression<Func<Genre, bool>> anyFilter = item => item.Id == "0";

            var mockFirebaseRepository = _fixture.Freeze<Mock<IFirebaseRepository<Genre>>>();
            mockFirebaseRepository.Setup(mock => mock.FindAll(anyFilter))
                .Verifiable();

            var sut = _fixture.Create<GenreRepository>();

            // Exercise Sut
            sut.FindAll(anyFilter);

            // Verify Outcome
            mockFirebaseRepository.VerifyAll();

            // Fixture Teardown
        }

        [Fact]
        public void SaveShouldSaveGenreCorrectly()
        {
            // Fixture Setup
            var anyGenre = _fixture.Create<Genre>();

            var mockFirebaseRepository = _fixture.Freeze<Mock<IFirebaseRepository<Genre>>>();
            mockFirebaseRepository.Setup(mock => mock.Save(anyGenre))
                .Verifiable();

            var sut = _fixture.Create<GenreRepository>();

            // Exercise Sut
            sut.Save(anyGenre);

            // Verify Outcome
            mockFirebaseRepository.VerifyAll();

            // Fixture Teardown
        }


    }
}
