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
using Android.Webkit;
using System.IO;
using Android.Media;

namespace XamaAndrTest
{
    [Activity(Label = "PrepareActivity")]
    public class PrepareActivity : Activity
    {
        private Button bnext;
        private VideoView videoView;
        private TableLayout tlPrepareParam;
        private MediaController mediaController;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Prepare);

            bnext = FindViewById<Button>(Resource.Id.bNext);
            videoView = FindViewById<VideoView>(Resource.Id.videoView1);
            tlPrepareParam = FindViewById<TableLayout>(Resource.Id.tlPrepareParam);
            mediaController = new MediaController(this, true);
            videoView.SetMediaController(mediaController); 

            bnext.Click += delegate
            {
                Intent intent = new Intent(this, typeof(ExerciseActivity));
                StartActivity(intent);
            };

            for (var i = 0; i < 2; i++)
            {
                var tvTemp = new TextView(this);
                tvTemp.SetText("Кол-во подходов", TextView.BufferType.Normal);

                var tvTemp2 = new TextView(this);
                tvTemp2.SetText("100..", TextView.BufferType.Normal);

                var trTemp = new TableRow(this);
                trTemp.AddView(tvTemp);
                trTemp.AddView(tvTemp2);

                tlPrepareParam.AddView(trTemp);
            }

        }
       
        protected override void OnStart()
        {
            base.OnStart();
            videoView.Prepared += VideoView_Prepared;
            LaunchVideo();
        }

        private void VideoView_Prepared(object sender, EventArgs e)
        {
            mediaController.SetAnchorView(videoView);
            mediaController.Show(3000);
        }

        private void LaunchVideo()
        {
            string videoUrl = "http://bitly.com/1MC3Gig";
            videoView.SetVideoURI(Android.Net.Uri.Parse(videoUrl));
            videoView.Start();
        }
    }
}