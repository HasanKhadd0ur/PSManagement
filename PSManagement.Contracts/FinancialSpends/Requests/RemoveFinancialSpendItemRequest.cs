namespace PSManagement.Contracts.FinancialSpends.Requests
{
    public record RemoveFinancialSpendItemRequest(
        int ProjectId,
        int Id
        );
}
