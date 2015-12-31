using FireSharp.Interfaces;
using FireSharp.Response;
using Moq;
using Ploeh.AutoFixture;
using Ploeh.AutoFixture.AutoMoq;
using Ploeh.SemanticComparison;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using WebVaanoli.Data.Interfaces;
using WebVaanoli.Data.Tests.TestHelpers;
using WebVaanoli.Domain;
using Xunit;

namespace WebVaanoli.Data.Tests
{
    public class GenreRepositoryTests
    {
        private const int Many = 3;
        private readonly IFixture _fixture;
        public GenreRepositoryTests()
        {
            _fixture = new Fixture()
                .Customize(new AutoMoqCustomization());
        }

        [Fact]
        public void AddShouldThrowWhenGenreIsNotProvided()
        {
            // Fixture Setup
            Genre invalidGenre = null;
            var sut = _fixture.Create<GenreRepository>();

            // Exercise Sut
            // Verify Outcome
            Should.Throw<ArgumentNullException>(() => sut.Add(invalidGenre));

            // Fixture Teardown
        }

        [Fact]
        public void AddShouldCorrectlyAddTheProvidedGenre()
        {
            // Fixture Setup
            var anyGenre = _fixture.Create<Genre>();
            var anyNewId = _fixture.Create<int>();

            var mockFirebaseClient = FreezeFirebaseClient();
            var pushResponse = FirebaseClientTestHelper.CreatePushResponse(anyGenre);
            mockFirebaseClient.Setup(mock => mock.Push<Genre>("/", anyGenre))
                .Returns(pushResponse);
            anyGenre.Id = pushResponse.Result.Name;
            mockFirebaseClient.Setup(mock => mock.Set($"/{anyGenre.Id}/", anyGenre))
            .Returns(FirebaseClientTestHelper.CreateSetResponse(anyGenre));

            var sut = _fixture.Create<GenreRepository>();

            // Exercise Sut
            var result = sut.Add(anyGenre);

            // Verify Outcome
            result.ShouldBe(anyGenre.Id);

            // Fixture Teardown
        }

        [Fact]
        public void FindShouldReturnCorrectGenre()
        {
            // Fixture Setup
            var anyId = _fixture.Create<string>();
            var anyGenre = _fixture.Create<Genre>();

            var mockFirebaseClient = FreezeFirebaseClient();
            mockFirebaseClient.Setup(mock => mock.Get($"/{anyId}/"))
                .Returns(FirebaseClientTestHelper.CreateResponse(anyGenre));

            var sut = _fixture.Create<GenreRepository>();

            // Exercise Sut
            var result = sut.Find(anyId);

            // Verify Outcome
            var expected = new Likeness<Genre, Genre>(anyGenre);
            expected.Equals(result).ShouldBeTrue();

            // Fixture Teardown
        }

        [Fact]
        public void FindAllWithNoFilterShouldReturnAllGenres()
        {
            // Fixture Setup
            var manyGenre = _fixture.CreateMany<Genre>(Many).ToList();

            var mockFirebaseClient = FreezeFirebaseClient();
            mockFirebaseClient.Setup(mock => mock.Get("/"))
                .Returns(FirebaseClientTestHelper.CreateResponse(manyGenre));

            var sut = _fixture.Create<GenreRepository>();

            // Exercise Sut
            var result = sut.FindAll();

            // Verify Outcome
            var expectedResult = new Likeness<List<Genre>, List<Genre>>(manyGenre);
            expectedResult.Equals(result.ToList()).ShouldBeTrue();
            
            // Fixture Teardown
        }

        #region TestHelpers
        private Mock<IFirebaseClient> FreezeFirebaseClient()
        {
            var mockVaanoliDataContext = _fixture.Freeze<Mock<IVaanoliDataContext>>();
            var mockFirebaseClient = _fixture.Freeze<Mock<IFirebaseClient>>();
            mockVaanoliDataContext.Setup(mock => mock.Genres).Returns(mockFirebaseClient.Object);
            return mockFirebaseClient;
        }
        #endregion
    }
}
