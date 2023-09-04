namespace StoreAdministrationSystem.Domain.Orders;

public static class OrderStatuses
{
    public const string Created = nameof(Created);
    public const string Paid = nameof(Paid);
    public const string OnTheWay = nameof(OnTheWay);
    public const string InPointOfIssue = nameof(InPointOfIssue);
    public const string Completed = nameof(Completed);
    public const string Rejected = nameof(Rejected);
    public const string Declined = nameof(Declined);
}
