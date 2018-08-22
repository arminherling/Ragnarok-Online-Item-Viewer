using RagnarokOnlineItemViewer.Models;
using RagnarokOnlineItemViewer.Service;
using System.Collections.Generic;

namespace RagnarokOnlineItemViewer.Tests.Fakes
{
    class FakeItemRepository : IRepository<Item>
    {
        private List<Item> _items = new List<Item>();
        public IEnumerable<Item> All()
        {
            return _items;
        }

        public void AddFake( Item fake )
        {
            _items.Add( fake );
        }
    }
}
