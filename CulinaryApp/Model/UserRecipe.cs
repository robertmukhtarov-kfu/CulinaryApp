using System;
using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace CulinaryApp.Model
{
    public class UserRecipe
    {
        [AutoIncrement,PrimaryKey]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Instructions { get; set; }
    } 
}

