namespace PSManagement.Contracts.Tracks.Requests
{
    public record GetTracksByProjectRequest(
      int ProjectId,
      int? PageNumber,
      int? PageSize

      );
}
