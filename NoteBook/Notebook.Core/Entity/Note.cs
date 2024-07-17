using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook.Core.Entity
{
    public class Note(int id, string title = "", string description = "")
    {
        public int Id { get; set; } = id;
        public string Title { get; set; } = title;
        public string Description { get; set; } = description;
    }
}
