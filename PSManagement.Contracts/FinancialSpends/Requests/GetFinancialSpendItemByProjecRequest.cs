namespace PSManagement.Contracts.FinancialSpends.Requests
{
    public record GetFinancialSpendItemByProjecRequest(
        int ProjectId,
        int? PageNumber,
        int? PageSize
        );
}
