using RagnarokOnlineItemViewer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RagnarokOnlineItemViewer.Service
{
    public interface IRepository<T>
    {
        IEnumerable<T> All();
    }
}
