using AutoMapper;
using Moq;
using MyFirstApi.DTO;
using MyFirstApi.Helpers;
using MyFirstApi.Repositories;
using MyFirstApi.Services;
using NUnit.Framework;
using System.Threading.Tasks;

namespace MyFirstApi.Tests
{
    public class AppUserServiceTests
    {
        private Mock<IAppUserRepository> mockRepo;
        private MapperConfiguration config;

        [SetUp]
        public void Setup()
        {
            
           
        }

        [TestCase(1)]
        [TestCase(5)]
        [TestCase(12)]
        public async Task WhenGetMemberAsyncCalled_UserIsMappedToMemberDtoAsync(int id)
        {
            // ARRANGE
            mockRepo = new Mock<IAppUserRepository>();

            // Initialize AutoMapper for Unit Tests
            var config = new MapperConfiguration(x => x.AddProfile<AutoMapperProfile>());

            // Inject fake dependencies and AutoMapper
            var service = new AppUserService(mockRepo.Object, config.CreateMapper());

            // Mock a dependency so we can pass it into the constructor
            AppUser fakeUser = new AppUser
            {
                City = "FakeTown",
                CountryOfOrigin = "FakeCountry",
                Gender = "Fake",
                Interests = "Fake it",
                Name = "Faker McGee",
                DateOfBirth = new System.DateTime(1969, 4, 20)
            };

            // Fake the return value of a Mock dependency
            mockRepo.Setup(x => x.GetUser(It.IsAny<int>())).ReturnsAsync(fakeUser);
           

            // ACT
            MemberDto result = await service.GetMemberAsync(id);

            // ASSERT
            Assert.NotNull(result);
            Assert.AreEqual("FakeTown", result.City);
        }
    }
}