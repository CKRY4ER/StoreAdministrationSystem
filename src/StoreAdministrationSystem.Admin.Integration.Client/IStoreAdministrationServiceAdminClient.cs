using Refit;
using StoreAdministrationSystem.Admin.Integration.Client.Models;

namespace StoreAdministrationSystem.Admin.Integration.Client;

public interface IStoreAdministrationServiceAdminClient
{
    #region Orders

    /// <summary>
    /// Получение пагинированного списка всех заказов
    /// </summary>
    /// <returns>
    /// 200 - успешно
    /// 500 - ошибка
    /// </returns>
    [Get("/api/orders")]
    Task<ApiResponse<PageResponse<GetPagedOrderListResponse>>> GetPagedOrderListAsync(GetPagedOrderListRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Получение заказа по ИД
    /// </summary>
    /// <param name="orderId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// 200 - найден
    /// 404 - заказ не найден
    /// 500 - ошибка
    /// </returns>
    [Get("/api/orders/{orderId}")]
    Task<ApiResponse<GetOrderByIdResponse>> GetOrderByIdAsync(Guid orderId, CancellationToken cancellationToken = default);

    #endregion

    #region ProductCategories

    /// <summary>
    /// Получить список категорий товаров
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// 200 - успешно
    /// 500 - ошибка
    /// </returns>
    [Get("/api/product-categories")]
    Task<ApiResponse<PageResponse<GetPagedProductCategoriesListResponse>>> GetPagedProductCategoriesListAsync(GetPagedProductCategoriesListRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Создать новую категорию товара
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// 200 - успешно
    /// 409 - категория уже существует
    /// 500 - ошибка
    /// </returns>
    [Post("/api/product-categories")]
    Task<IApiResponse> CreateProductCategoryAsync(CreateProductCategoryRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Обновить категорию
    /// </summary>
    /// <param name="categoryId"></param>
    /// <param name="name"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// 200 - успешно
    /// 404 - категория не найдена
    /// 409 - категория уже существует
    /// 500 - ошибка
    /// </returns>
    [Patch("/api/product-categories/{categoryId}/update")]
    Task<IApiResponse> UpdateProductCategoryAsync(Guid categoryId, [Query] string name, CancellationToken cancellationToken);

    #endregion

    #region Products

    /// <summary>
    /// Получить пагинированный список продуктов
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// 200 - успешно
    /// 500 - ошибка
    /// </returns>
    [Get("/api/products")]
    Task<ApiResponse<PageResponse<GetPagedProductListResponse>>> GetPagedProductListAsync(GetPagedProductListRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Создать новый продукт
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// 200 - успех 
    /// 409 - продукт уже существует
    /// 500 - ошибка
    /// </returns>
    [Post("/api/products")]
    Task<IApiResponse> CreateProductAsync(CreateProductRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Обновить продукт
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// 200 - успех
    /// 409 - продукт уже существует
    /// 500 - ошибка
    /// </returns>
    [Patch("/api/products/{productId}/update")]
    Task<IApiResponse> UpdateProductAsync(Guid productId, UpdateProductRequest request, CancellationToken cancellationToken);

    #endregion

    #region Users

    /// <summary>
    /// Получить пагинированный список пользователей
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// 200 - успех
    /// 500 - ошибка
    /// </returns>
    [Get("/api/users")]
    Task<ApiResponse<PageResponse<GetPagedUserListResponse>>> GetPagedUserListAsync(GetPagedUserListRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Получить пользователя по ИД
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// 200 - успех
    /// 404 - пользователь не найден
    /// 500 - ошибка
    /// </returns>
    [Get("/api/users/{userId}")]
    Task<ApiResponse<GetUserByIdResponse>> GetUserByIdAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Создать нового пользователя с правами администратора
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns>
    /// 200 - успех
    /// 409 - пользователь уже существует
    /// 500 - ошибка
    /// </returns>
    [Post("/api/users")]
    Task<IApiResponse> CreateAdminUserAsync(CreateAdminUserRequest request, CancellationToken cancellationToken);

    #endregion
}
