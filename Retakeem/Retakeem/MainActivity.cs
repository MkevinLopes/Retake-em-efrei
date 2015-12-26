using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Media;

namespace Retakeem
{
    [Activity(Label = "Retakeem", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;
        MediaRecorder recorder;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.VideoPrise);

            // Get our button from the layout resource,
            // and attach an event to it
            var record = FindViewById<Button>(Resource.Id.Record);
            var stop = FindViewById<Button>(Resource.Id.Stop);
            var play = FindViewById<Button>(Resource.Id.Play);
            var video = FindViewById<VideoView>(Resource.Id.SampleVideoView);

            string path = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/test.mp4";

            record.Click += delegate {
                video.StopPlayback();

                recorder = new MediaRecorder();


                recorder.SetVideoSource(VideoSource.Camera);
                recorder.SetAudioSource(AudioSource.Mic);
                recorder.SetOutputFormat(OutputFormat.Default);
                recorder.SetVideoEncoder(VideoEncoder.Default);
                recorder.SetAudioEncoder(AudioEncoder.Default);
                recorder.SetOutputFile(path);
                recorder.SetPreviewDisplay(video.Holder.Surface);
                recorder.Prepare();
                recorder.Start();
            };

            stop.Click += delegate {
                if (recorder != null)
                {
                    recorder.Stop();
                    recorder.Release();
                }
            };

            play.Click += delegate {
                var uri = Android.Net.Uri.Parse(path);
                video.SetVideoURI(uri);
                video.Start();
            };
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

