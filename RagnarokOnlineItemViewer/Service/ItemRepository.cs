using RagnarokOnlineItemViewer.Models;
using System.Collections.Generic;

namespace RagnarokOnlineItemViewer.Service
{
    public class ItemRepository : IRepository<Item>
    {
        private readonly string _filePath;

        public ItemRepository( string filePath ) => _filePath = filePath;

        public IEnumerable<Item> All()
        {
            return new List<Item>();
        }
    }
}
