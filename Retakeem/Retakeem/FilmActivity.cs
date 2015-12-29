using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Media;
using System.Threading;
using Android.Content.PM;
using Android.Util;
using Android.Hardware;


namespace Retakeem
{
    [Activity(Label = "FilmActivity", ScreenOrientation = ScreenOrientation.Portrait)]
    public class FilmActivity : Activity
    {
        //int count = 1;
        MediaRecorder recorder;
        Boolean isStoped = false;
        Camera camera;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.VideoPrise);

            // Get our button from the layout resource,
            // and attach an event to it
            var record = FindViewById<Button>(Resource.Id.Record);
            //var stop = FindViewById<Button>(Resource.Id.Stop);
            //var play = FindViewById<Button>(Resource.Id.Play);
            var video = FindViewById<VideoView>(Resource.Id.surface);

            string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Retakem.mp4";


            /*stop.Click += delegate {
                if (recorder != null)
                {
                    isStoped = true;
                    recorder.Stop();
                    recorder.Release();
                }
            };*/

            camera = Camera.Open();
            camera.SetDisplayOrientation(90);
            camera.Unlock();


            record.Click += delegate {
                video.StopPlayback();
                recorder = new MediaRecorder();
                recorder.SetCamera(camera);
                recorder.SetVideoSource(VideoSource.Camera);
                recorder.SetAudioSource(AudioSource.Camcorder);
                recorder.SetOutputFormat(OutputFormat.Mpeg4);
                recorder.SetVideoEncoder(VideoEncoder.Mpeg4Sp);
                recorder.SetAudioEncoder(AudioEncoder.HeAac);
                recorder.SetOutputFile(path);
                recorder.SetPreviewDisplay(video.Holder.Surface);
                recorder.SetOrientationHint(90);
                recorder.Prepare();
                recorder.Start();

                Thread.Sleep(15000);

                if (recorder != null)
                {
                    isStoped = true;
                    recorder.Stop();
                    recorder.Release();
                    recorder.Dispose();
                    recorder = null;
                    camera.StopPreview();
                    camera.Release();
                    camera.Dispose();
                }
                var uri = Android.Net.Uri.Parse(path);
                video.SetVideoURI(uri);
                //video.Start();
                Intent intent = new Intent(this, typeof(VideoReadActivity));
                StartActivity(intent);
            };

           /* play.Click += delegate {
                var uri = Android.Net.Uri.Parse(path);
                video.SetVideoURI(uri);
                video.Start();
            };*/
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();

            if (recorder != null)
            {
                recorder.Release();
                recorder.Dispose();
                recorder = null;
            }
        }
    }
}

