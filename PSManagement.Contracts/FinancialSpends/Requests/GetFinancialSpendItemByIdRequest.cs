namespace PSManagement.Contracts.FinancialSpends.Requests
{
    public record GetFinancialSpendItemByIdRequest(
   int ProjectId,
   int Id);
}
