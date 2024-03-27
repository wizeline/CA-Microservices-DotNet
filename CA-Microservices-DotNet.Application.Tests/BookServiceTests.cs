using AutoMapper;
using CA_Microservices_DotNet.Application.Mappings;
using CA_Microservices_DotNet.Application.Services;
using CA_Microservices_DotNet.Common.Models;
using CA_Microservices_DotNet.Domain.Entities;
using CA_Microservices_DotNet.Domain.Interfaces;
using CA_Microservices_DotNet.Domain.Interfaces.Repositories;
using CA_Microservices_DotNet.Domain.Interfaces.Services;
using CA_Microservices_DotNet.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;
using System.Linq.Expressions;
using Telerik.JustMock;
using Telerik.JustMock.Helpers;

namespace CA_Microservices_DotNet.Application.Tests;

[TestFixture]
public class BookServiceTests
{
    private static BookService _sut = default!;

    //Mocked properties needed by the service to be initialized.
    private IMemoryCacheService _mockCache = default!;
    private IUnitOfWork _mockUnitOfWork = default!;
    private IGenericRepository<Book> _mockRepository = default!;
    private IMapper _mapper = default!;
    private MapperConfiguration _mapperConfiguration = default!;

    [SetUp]
    public void Setup()
    {
        _mockCache = Mock.Create<IMemoryCacheService>(Behavior.Strict);
        _mockUnitOfWork = Mock.Create<IUnitOfWork>(Behavior.Strict);
        _mockRepository = Mock.Create<IGenericRepository<Book>>(Behavior.Strict);

        //Create an actual instance of Automapper to avoid mocking it.
        _mapperConfiguration = new MapperConfiguration(c => c.AddProfile(new BookProfile()));
        _mapper = new Mapper(_mapperConfiguration);

        _sut = new BookService(_mockCache, _mockRepository, _mockUnitOfWork, _mapper);

    }

    [Test]
    public async Task GetAllBooks_Should_Return_Books_From_Database_Successfully()
    {
        //Arrange
        List<Book>? cachedBooks;
        List<Book>? booksFromRepo = new List<Book>()
        {
            new()
            {
                Id = 1,
                Name = "The Lord of the Rings",
                Description = "This is a description of book 2.",
                Author = "J.R.R. Tolkien"
            }
        };

        //Mock the call to CacheService to return no data or false which means there is nothing in cache
        _mockCache.Arrange(c => c.TryGetValue(Arg.AnyString, out cachedBooks))
            .Returns(false);

        _mockCache.Arrange(c => c.Set(Arg.AnyString, Arg.IsAny<List<Book>>(), Arg.IsAny<TimeSpan>()))
            .DoNothing();

        //Mock the response from the repository
        _mockRepository.Arrange(r => r.Get(null, Arg.IsAny<string[]>(), Arg.IsAny<CancellationToken>()))
            .ReturnsAsync(booksFromRepo);

        //Act
        var response = await _sut.GetAllBooks();

        //Assert
        Assert.That(response, Is.Not.Null);
        //This Assert is used for comparing collections, it will iterate over expected and actual responses using the 
        //comparison passed to compare one by one item
        Assert.That(response, Is.EquivalentTo(booksFromRepo)
            .Using((BookModel actual, Book expected) => 
                 actual.Name == expected.Name &&
                 actual.Description == expected.Description &&
                 actual.Author == expected.Author &&
                 actual.Id  == expected.Id ));
    }
}