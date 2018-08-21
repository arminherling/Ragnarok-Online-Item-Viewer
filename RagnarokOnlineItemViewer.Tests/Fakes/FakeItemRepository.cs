using RagnarokOnlineItemViewer.Models;
using RagnarokOnlineItemViewer.Service;
using System.Collections.Generic;

namespace RagnarokOnlineItemViewer.Tests.Fakes
{
    class FakeItemRepository : IRepository<Item>
    {
        public IEnumerable<Item> All()
        {
            return new List<Item>();
        }
    }
}
