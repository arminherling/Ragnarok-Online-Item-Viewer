using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnarokOnlineItemViewer.Models
{
    public class Item
    {
        public Item( string id = "", string name = "", string description = "" )
        {
            ID = id;
            Name = name;
            Description = description;
        }

        public string ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
    }
}
