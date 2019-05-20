using Restaurant_Menus.Models;
using System.Collections.Generic;

namespace Restaurant_Menus.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Menu> Menus { get; set; }
       // public IEnumerable<FileModel> Files { get; set; }
    }
}
