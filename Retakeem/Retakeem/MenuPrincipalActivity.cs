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

namespace Retakeem
{
    [Activity(Label = "MenuPrincipalActivity", MainLauncher = true, Icon = "@drawable/chaise")]
    public class MenuPrincipalActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.MenuPrincipal);

            var jouer = FindViewById<ImageButton>(Resource.Id.jouer);
            var filmer = FindViewById<ImageButton>(Resource.Id.filmer);
            var options = FindViewById<ImageButton>(Resource.Id.options);

            filmer.Click += delegate
            {
                Intent intent = new Intent(this, typeof(FilmActivity));
                StartActivity(intent);
            };
        }
    }
}