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

        public string ID { get;  }
        public string Name { get; }
        public string Description { get;}
    }
}
