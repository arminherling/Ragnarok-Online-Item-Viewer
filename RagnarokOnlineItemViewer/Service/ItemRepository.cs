using Newtonsoft.Json;
using RagnarokOnlineItemViewer.Models;
using System.Collections.Generic;
using System.IO;

namespace RagnarokOnlineItemViewer.Service
{
    public class ItemRepository : IRepository<Item>
    {
        private readonly string _filePath;

        public ItemRepository( string filePath ) => _filePath = filePath;

        public IEnumerable<Item> All()
        {
            var json = File.ReadAllText( _filePath );
            return JsonConvert.DeserializeObject<List<Item>>( json );
        }
    }
}
