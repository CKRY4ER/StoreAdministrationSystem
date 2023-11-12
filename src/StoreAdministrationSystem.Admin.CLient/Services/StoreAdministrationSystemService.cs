using Refit;
using StoreAdministrationSystem.Admin.Client.Services.Exceptions;
using StoreAdministrationSystem.Admin.Integration.Client;
using StoreAdministrationSystem.Admin.Integration.Client.Models;
using System.Net;

namespace StoreAdministrationSystem.Admin.Client.Services;

internal sealed class StoreAdministrationSystemService : IStoreAdministrationSystemService
{
    private readonly IStoreAdministrationServiceAdminClient _client;

    public StoreAdministrationSystemService(IStoreAdministrationServiceAdminClient client)
        => _client = client;

    public async Task CreateAdminUserAsync(CreateAdminUserRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _client.CreateAdminUserAsync(request, cancellationToken);

            if (response.IsSuccessStatusCode)
                return;

            switch (response.StatusCode)
            {
                case (HttpStatusCode.Conflict):
                    throw new ServerException("Не удалось создать пользователя. Пользователь уже существует.");

                case (HttpStatusCode.InternalServerError):
                    throw new ServerException("Не удалось создать пользователя. Ошибка на стороне сервреа.");

            }
        }
        catch (ApiException ex)
        {
            throw new ServerException($"Не удалось установить соединение с сервером для создания пользователя. Сообщение: {ex.Message}");
        }
    }

    public async Task CreateProductAsync(CreateProductRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _client.CreateProductAsync(request, cancellationToken);

            if (response.IsSuccessStatusCode)
                return;

            switch (response.StatusCode)
            {
                case (HttpStatusCode.Conflict):
                    throw new ServerException("Не удалось создать продукт. Продукт уже существует.");

                case (HttpStatusCode.InternalServerError):
                    throw new ServerException("Не удалось создать продукт. Ошибка на стороне сервреа.");

            }
        }
        catch (ApiException ex)
        {
            throw new ServerException($"Не удалось установить соединение с сервером для создания продукта. Сообщение: {ex.Message}");
        }
    }

    public async Task CreateProductCategoryAsync(CreateProductCategoryRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _client.CreateProductCategoryAsync(request, cancellationToken);

            if (response.IsSuccessStatusCode)
                return;

            switch (response.StatusCode)
            {
                case (HttpStatusCode.Conflict):
                    throw new ServerException("Не удалось создать категорию продукта. Категория уже существует.");

                case (HttpStatusCode.InternalServerError):
                    throw new ServerException("Не удалось создать категорию продукта. Ошибка на стороне сервера.");
            }
        }
        catch (ApiException ex)
        {
            throw new ServerException($"Не удалось установить соединение с сервером для создания категории продукта. Сообщение: {ex.Message}");
        }
    }

    public async Task<GetOrderByIdResponse> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _client.GetOrderByIdAsync(orderId, cancellationToken);

            return response.StatusCode switch
            {
                HttpStatusCode.OK => response.Content!,
                HttpStatusCode.NotFound => throw new ServerException("Не удалось найти заказ"),
                HttpStatusCode.InternalServerError => throw new ServerException("Не удалсоь найти заказ. Ошибка на стороне сервера")
            };
        }
        catch(ApiException ex)
        {
            throw new ServerException($"Не удалось установить соединение с сервером для получения заказа. Сообщение: {ex.Message}");
        }
    }

    public async Task<PageResponse<GetPagedOrderListResponse>> GetPagedOrderListAsync(GetPagedOrderListRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _client.GetPagedOrderListAsync(request, cancellationToken);

            return response.StatusCode switch
            {
                HttpStatusCode.OK => response.Content!,
                HttpStatusCode.InternalServerError => throw new ServerException("Не удалось получить список заказов. Ошибка на стороне сервера.")
            };
        }
        catch(ApiException ex)
        {
            throw new ServerException($"Не удалось установить соединение с сервером для получения списка заказов. Сообщение: {ex.Message}");
        }
    }

    public async Task<PageResponse<GetPagedProductCategoriesListResponse>> GetPagedProductCategoriesListAsync(GetPagedProductCategoriesListRequest request,
        CancellationToken cancellationToken)
    {
        try
        {
            var response = await _client.GetPagedProductCategoriesListAsync(request, cancellationToken);

            return response.StatusCode switch
            {
                HttpStatusCode.OK => response.Content!,
                HttpStatusCode.InternalServerError => throw new ServerException("Не удалось получить список категорий товаров. Ошибка на стороне сервера.")
            };
        }
        catch(ApiException ex)
        {
            throw new ServerException($"Не удалось установить соединение с сервером для получения списка категорий товаров. Сообщение: {ex.Message}");
        }
    }

    public async Task<PageResponse<GetPagedProductListResponse>> GetPagedProductListAsync(GetPagedProductListRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _client.GetPagedProductListAsync(request, cancellationToken);

            return response.StatusCode switch
            {
                HttpStatusCode.OK => response.Content!,
                HttpStatusCode.InternalServerError => throw new ServerException("Не удалось получить список товаров. Ошибка на стороне сервера.")
            };
        }
        catch(ApiException ex)
        {
            throw new ServerException($"Не удалось установить соединение с сервером для получения списка товаров. Сообщение: {ex.Message}");
        }
    }

    public async Task<PageResponse<GetPagedUserListResponse>> GetPagedUserListAsync(GetPagedUserListRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _client.GetPagedUserListAsync(request, cancellationToken);

            return response.StatusCode switch
            {
                HttpStatusCode.OK => response.Content!,
                HttpStatusCode.InternalServerError => throw new ServerException("Не удалось получить список пользователей. Ошибка на стороне сервера.")
            };
        }
        catch(ApiException ex)
        {
            throw new ServerException($"Не удалось установить соединение с сервером для получения списка пользователей. Сообщение: {ex.Message}");
        }
    }

    public async Task<GetUserByIdResponse> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _client.GetUserByIdAsync(userId, cancellationToken);

            return response.StatusCode switch
            {
                HttpStatusCode.OK => response.Content!,
                HttpStatusCode.NotFound => throw new ServerException("Пользователь не найден"),
                HttpStatusCode.InternalServerError => throw new ServerException("Не удалось получить пользователя. Ошибка сервера.")
            };
        }
        catch(ApiException ex)
        {
            throw new ServerException($"Не удалось установить соединение с сервером для получения пользователя. Сообщение: {ex.Message}");
        }
    }

    public async Task UpdateProductAsync(Guid productId, UpdateProductRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _client.UpdateProductAsync(productId, request, cancellationToken);

            if (response.IsSuccessStatusCode)
                return;

            switch (response.StatusCode)
            {
                case HttpStatusCode.Conflict:
                    throw new ServerException("Не удалось обновить продукт. Продукт уже существует.");

                case HttpStatusCode.InternalServerError:
                    throw new ServerException("Не удалось обновить продукт. Ошибка сервера.");
            }
        }
        catch(ApiException ex)
        {
            throw new ServerException($"Не удалось установить соединение с сервером для обновления продукта. Сообщение: {ex.Message}");
        }
    }

    public async Task UpdateProductCategoryAsync(Guid categoryId, string name, CancellationToken cancellationToken)
    {
        try
        {
            var response = await _client.UpdateProductCategoryAsync(categoryId, name, cancellationToken);

            if (response.IsSuccessStatusCode)
                return;

            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    throw new ServerException("Не удалось обновить категорию. Категория не найдена.");

                case HttpStatusCode.Conflict:
                    throw new ServerException("Не удалось обновить категорию. Категория  с таким имененем уже существует.");

                case HttpStatusCode.InternalServerError:
                    throw new ServerException("Не удалось обновить категорию. Ошибка сервера.");
            }
        }
        catch(ApiException ex)
        {
            throw new ServerException($"Не удалось установить соединение с сервером для обновления категории продукта. Сообщение: {ex.Message}");
        }
    }
}

public interface IStoreAdministrationSystemService
{
    #region Orders 

    Task<PageResponse<GetPagedOrderListResponse>> GetPagedOrderListAsync(GetPagedOrderListRequest request, CancellationToken cancellationToken);

    Task<GetOrderByIdResponse> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken);

    #endregion

    #region ProductCategories

    Task<PageResponse<GetPagedProductCategoriesListResponse>> GetPagedProductCategoriesListAsync(GetPagedProductCategoriesListRequest request,
        CancellationToken cancellationToken);

    Task CreateProductCategoryAsync(CreateProductCategoryRequest request, CancellationToken cancellationToken);

    Task UpdateProductCategoryAsync(Guid categoryId, string name, CancellationToken cancellationToken);

    #endregion

    #region Products

    Task<PageResponse<GetPagedProductListResponse>> GetPagedProductListAsync(GetPagedProductListRequest request, CancellationToken cancellationToken);

    Task CreateProductAsync(CreateProductRequest request, CancellationToken cancellationToken);

    Task UpdateProductAsync(Guid productId, UpdateProductRequest request, CancellationToken cancellationToken);

    #endregion

    #region Users

    Task<PageResponse<GetPagedUserListResponse>> GetPagedUserListAsync(GetPagedUserListRequest request, CancellationToken cancellationToken);

    Task<GetUserByIdResponse> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);

    Task CreateAdminUserAsync(CreateAdminUserRequest request, CancellationToken cancellationToken);

    #endregion
}
