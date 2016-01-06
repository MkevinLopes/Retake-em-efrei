using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Retakeem;
//using Xamarin.Forms;

//[assembly: Dependency(typeof(TodoItemDatabase))]
namespace Retakeem
{   
    class TodoItemDatabase
    {
        private ISQLite database;

        public TodoItemDatabase()
        {
            /*database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<TodoItem>();*/
        }
    }
}