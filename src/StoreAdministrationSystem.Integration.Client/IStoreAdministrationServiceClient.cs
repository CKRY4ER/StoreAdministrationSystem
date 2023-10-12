namespace StoreAdministrationSystem.Integration.Client;
using Refit;
using StoreAdministrationSystem.Integration.Client.Models;

public interface IStoreAdministrationServiceClient
{
    #region Orders

    /// <summary>
    /// Получение пагинированного списка заказов
    /// </summary>
    /// <returns>
    /// 200 - успешно
    /// 500 - ошибка
    /// </returns>
    [Get("/api/orders")]
    Task<ApiResponse<PageResponse<GetPagedOrderListResponse>>> GetPagedOrderListAsync(GetPagedOrderListRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Получение заказа по ID
    /// </summary>
    /// <returns>
    /// 200 - успешно
    /// 404 - заказ не найден
    /// 500 - ошибка
    /// </returns>
    [Get("/api/orders/{orderId}")]
    Task<ApiResponse<GetOrderByIdResponse>> GetorderByIdAsync(Guid orderId, CancellationToken cancellationToken);

    /// <summary>
    /// Создание заказа на основе корзины пользователя
    /// </summary>
    /// <returns>
    /// 200 - успешно создан
    /// 422 - корзина пользователя пуста/пользователь не найден/недостаточно продукта для заказа
    /// 500 - ошибка
    /// </returns>
    [Post("/api/orders")]
    Task<IApiResponse> CreateOrderAsync(Guid userId, CancellationToken cancellationToken);

    #endregion

    #region ProductCategories

    /// <summary>
    /// Получение пагинированного списка категорий товаров
    /// </summary>
    /// <returns>
    /// 200 - успешно
    /// 500 - ошибка
    /// </returns>
    [Get("/api/product-categories")]
    Task<ApiResponse<PageResponse<GetPagedProductCategoriesListResponse>>> GetPagedProductCategoriesListAsync(GetPagedProductCategoriesListRequest request,
        CancellationToken cancellationToken);

    /// <summary>
    /// Создание новой категории товаров
    /// </summary>
    /// <returns>
    /// 200 - успешно
    /// 409 - категория уже сушествует
    /// 500 - ошибка
    /// </returns>
    [Post("/api/product-categories")]
    Task<IApiResponse> CreateProductCategoryAsync(CreateProductCategoryRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Обновить/изменить категорию товаров
    /// </summary>
    /// <returns>
    /// 200 -  успешно
    /// 404 - категория не найдена
    /// 500 - ошибка
    /// </returns>
    [Patch("/api/product-categories/{categoryId}/update")]
    Task<IApiResponse> UpdateProductCategoryAsync(Guid categoryId, string name, CancellationToken cancellationToken);

    #endregion

    #region Products

    /// <summary>
    /// Получение пагинированного списка всех продуктов
    /// </summary>
    /// <returns>
    /// 200 - успешно
    /// 500 - ошибка
    /// </returns>
    [Get("/api/products")]
    Task<ApiResponse<PageResponse<GetPagedProductListResponse>>> GetPagedProductListAsync(GetPagedProductListRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Создание нового продукта
    /// </summary>
    /// <returns>
    /// 200 - успешно
    /// 409 - продукт уже сушествует
    /// 500 - ошибка
    /// </returns>
    [Post("/api/products")]
    Task<IApiResponse> CreateProductAsync(CreateProductRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Внести изменения в продукт
    /// </summary>
    /// <returns>
    /// 200 - успешно
    /// 404 - продукт не найден/категория не найдена
    /// 500 - ошибка
    /// </returns>
    [Patch("/api/products/{productId}/update")]
    Task<IApiResponse> UpdateProductAsync(UpdateProductRequest request, CancellationToken cancellationToken);

    #endregion

    #region Users

    /// <summary>
    /// Получение пагинированного списка всех пользователей
    /// </summary>
    /// <returns>
    /// 200 - успешно
    /// 500 - ошибка
    /// </returns>
    [Get("/api/users")]
    Task<ApiResponse<PageResponse<GetPagedUserListResponse>>> GetPagedUserListAsync(GetPagedUserListRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Получение информации о пользователе
    /// </summary>
    /// <returns>
    /// 200 - найден
    /// 404 - не найден
    /// 500 - ошибка
    /// </returns>
    [Get("/api/users/{userId}")]
    Task<ApiResponse<GetUserByIdResponse>> GetUserBydAsync(Guid userId, CancellationToken cancellationToken);

    /// <summary>
    /// Создание нового пользователя
    /// </summary>
    /// <returns>
    /// 200 - успешно создан
    /// 409 - пользователь уже существует
    /// 500 - ошибка
    /// </returns>
    [Post("/api/users")]
    Task<IApiResponse> CreateUserAsync(CreateUserRequest request, CancellationToken cancellationToken);

    /// <summary>
    /// Добавление новой позиции в карзине пользователя или увеличиение кол-ва продукта в позиции
    /// </summary>
    /// <returns></returns>
    [Post("/api/users{userId}/add-product/{productId}")]
    Task<IApiResponse> AddProductInUserSchoppingCart(Guid userId, Guid productId, [Query] int productCount, CancellationToken cancellationToken);

    /// <summary>
    /// Удаление позиции карзины пользователя или уменьшение кол-ва продукта в позиции
    /// </summary>
    /// <returns></returns>
    [Post("/api/users/{userId}/delete-product/{productId}")]
    Task<IApiResponse> DeleteProductFromUserSchoppingCart(Guid userId, Guid productId, [Query] int productCount, CancellationToken cancellationToken);

    #endregion
}
