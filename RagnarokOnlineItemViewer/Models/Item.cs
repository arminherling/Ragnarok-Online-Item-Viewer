using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnarokOnlineItemViewer.Models
{
    public class Item
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }

        public Item( int id = 0, string name = "", string description = "" )
        {
            ID = id;
            Name = name;
            Description = description;
        }
    }
}
