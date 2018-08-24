using System.Collections.Generic;

namespace RagnarokOnlineItemViewer.Service
{
    public interface IRepository<T>
    {
        IEnumerable<T> All();
    }
}
