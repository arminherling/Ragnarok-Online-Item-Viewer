using RagnarokOnlineItemViewer.Models;
using System;
using System.Collections.Generic;

namespace RagnarokOnlineItemViewer.Service
{
    public class ItemRepository : IRepository<Item>
    {
        public ItemRepository(string filePath)
        {
        }

        public IEnumerable<Item> All()
        {
            return new List<Item>();
        }
    }
}
