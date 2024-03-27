﻿using CA_Microservices_DotNet.Common.Models;

namespace CA_Microservices_DotNet.Domain.Interfaces.Services;

public interface IBookService
{
    /// <summary>
    /// Gets a single Book by its id.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<BookModel?> GetBook(int id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets all the Books.
    /// </summary>
    /// <returns></returns>
    Task<List<BookModel>> GetAllBooks(CancellationToken cancellationToken = default);
}
