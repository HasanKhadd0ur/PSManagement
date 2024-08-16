using PSManagement.Domain.Steps.Repositories;
using PSManagement.Domain.Tracking;
using PSManagement.Infrastructure.Persistence.Repositories.Base;

namespace PSManagement.Infrastructure.Persistence.Repositories.TrackRepository
{
    public class TracksRepository : BaseRepository<Track>, ITracksRepository
    {
        public TracksRepository(AppDbContext context) : base(context)
        {
        }
    }

}
