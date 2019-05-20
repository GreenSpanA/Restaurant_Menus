﻿
namespace Restaurant_Menus.Models
{
    public class Menu : BaseEntity
    {

        public int Id { get; set; }

        public string Category { get; set; }

        public string Dish { get; set; }

        public string Description { get; set; }

        public string Veg_Comment { get; set; }

        public string Price { get; set; }

        public int File_Id { get; set; }
    }
}
