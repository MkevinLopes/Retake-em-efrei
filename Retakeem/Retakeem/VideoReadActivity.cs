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
using Android.Content.PM;

namespace Retakeem
{
    [Activity(Label = "VideoReadActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class VideoReadActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.LecteurVideoPrise);
            var videoView = FindViewById<VideoView>(Resource.Id.videoView1);
            var continuer = FindViewById<Button>(Resource.Id.Continuer);
            var abandonner = FindViewById<Button>(Resource.Id.abandonner);
            var replay = FindViewById<Button>(Resource.Id.Replay);

            var uri = Android.Net.Uri.Parse(Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Retakem.mp4");
            videoView.SetVideoURI(uri);
            videoView.Start();

            continuer.Click += delegate
            {
                //envoie au serveur
            };

            abandonner.Click += delegate
            {
                Intent intent = new Intent(this, typeof(MenuPrincipalActivity));
                StartActivity(intent);
            };

            replay.Click += delegate
            {
                videoView.SetVideoURI(uri);
                videoView.Start();
            };
        }
    }
}