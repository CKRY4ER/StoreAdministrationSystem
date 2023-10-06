namespace StoreAdministrationSystem.Application;

public static class ApplicationErrorCodes
{
    public const string PRODUCT_CATEGORY_ALREADY_EXISTS = "product_category_already_exists";
    public const string PRODUCT_CATEGORY_NOT_FOUND = "product_category_not_found";

    public const string PRODUCT_ALREADY_EXIST = "product_already_exists";
    public const string PRODUCT_NOT_FOUND = "product_not_found";
    public const string NOT_ENOUGHT_PRODUCT = "not_enough_product";

    public const string ORDER_NOT_FOUND = "order_not_found";

    public const string USER_SCHOPPING_CART_EMPTY = "user_shopping_cart_empty";
    public const string USER_SCHOPPING_CART_POSITION_NOT_FOUND = "user_schopping_cart_position_not_found";
    public const string USER_NOT_FOUND = "user_not_found";
    public const string USER_ALREADY_EXIST = "user_already_exists";

    public const string INTERNAL_ERROR = "internal_error";
}
