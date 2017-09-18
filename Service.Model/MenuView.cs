using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Service.Model
{
    public class MenuView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public int Sort { get; set; }
        public Nullable<int> _parentId { get; set; }
    }
}