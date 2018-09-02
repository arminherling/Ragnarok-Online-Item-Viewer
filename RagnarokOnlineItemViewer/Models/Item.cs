namespace RagnarokOnlineItemViewer.Models
{
    public class Item
    {
        public Item( int id = -1, string name = "", string description = "" )
        {
            ID = id;
            Name = name;
            Description = description;
        }

        public int ID { get;  }
        public string Name { get; }
        public string Description { get;}
    }
}
