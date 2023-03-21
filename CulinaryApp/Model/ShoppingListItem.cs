using System;
using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace CulinaryApp.Model
{
    public class ShoppingListItem
    {
        [AutoIncrement,PrimaryKey]
        public int ID { get; set; }
        public string Title { get; set; }
        public bool IsChecked { get; set; }
    } 
}

