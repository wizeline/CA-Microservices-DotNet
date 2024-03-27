using CA_Microservices_DotNet.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CA_Microservices_DotNet.Infrastructure.Integration.Tests;

[TestFixture]
internal class UnitOfWorkTests
{
    //sut stands for System Under Test, which is the system/service we are testing.
    private UnitOfWork _sut = default!;

    private static Book _book = new()
    {
        Name = "The Lord of the Rings",
        Description = "This is a description of book 2.",
        Author = "J.R.R. Tolkien"
    };

    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        _sut = new UnitOfWork(Startup.CreateDbContext());
    }

    [Test, Order(1)]
    public void Add_Should_Create_A_Database_Record_Successfully()
    {
        //Arrange

        //Act
        _sut.Add(_book);

        //Assert
        Assert.DoesNotThrowAsync(async () => await _sut.SaveChangesAsync());
    }

    [Test, Order(2)]
    public async Task Update_Should_Edit_The_Record_Successfully()
    {
        //Arrange
        var newName = "Updated Name";
        _book.Name = newName;
        using var dbContext = Startup.CreateDbContext();

        //Act
        _sut.Update(_book);
        await _sut.SaveChangesAsync();

        var updatedBook = await dbContext.Books.FirstOrDefaultAsync(x => x.Id == _book.Id);

        //Assert
        Assert.That(updatedBook, Is.Not.Null);
        Assert.That(updatedBook.Name, Is.EqualTo(newName));
    }

    [Test, Order(3)]
    public async Task Remove_Should_Delete_A_Record_Successfully()
    {
        //Arrange
        using var dbContext = Startup.CreateDbContext();
        
        //Act
        _sut.Remove(_book);
        await _sut.SaveChangesAsync();
        
        var deletedBook = await dbContext.Books.FirstOrDefaultAsync(b => b.Id == _book.Id);

        //Assert
        Assert.That(deletedBook, Is.Null);
    }
}