using System;
using System.IO;
using LiteDB;
using LiteDbApp.ViewModels;
using Xamarin.Forms;

namespace LiteDbApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            var litedbConnectionString =
                $"Filename={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "litedb.db")}";

            using (var db = new LiteDatabase(litedbConnectionString))
            {
                var tests = db.GetCollection("test");

                tests.Upsert(new BsonDocument { ["_id"] = "Certificate", ["Name"] = $"Hello World {DateTime.Now:yyyy-MM-dd HH:mm:ss}" });
            }

            using (var db = new LiteDatabase(litedbConnectionString))
            {
                var tests = db.GetCollection("test");

                this.MainPageViewModel.Message = tests.FindById("Certificate")["Name"];
            }
        }

        private MainPageViewModel MainPageViewModel => (MainPageViewModel)this.BindingContext;
    }
}