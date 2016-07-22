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

namespace XamaAndrTest
{
    [Activity(Label = "ExerciseActivity")]
    public class ExerciseActivity : Activity
    {
        //private TextView tvExerciseName;
        // private ScrollView svParameters;
        private TableLayout tlParameters;
        private VideoView vvExerciseVideo;
        private MediaController mediaController;
        //private Button bStartExercise;
        //private ProgressBar pbExerciseProgress;

        private Button bSkip;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Exercise);

            tlParameters = FindViewById<TableLayout>(Resource.Id.tlParameters);

            vvExerciseVideo = FindViewById<VideoView>(Resource.Id.vvExerciseVideo);
            mediaController = new MediaController(this, true);
            vvExerciseVideo.SetMediaController(mediaController);

            bSkip = FindViewById<Button>(Resource.Id.bSkip);
            bSkip.Click += delegate
            {
                Intent intent = new Intent(this, typeof(ExerciseMarkActivity));
                StartActivity(intent);
            };
        }

        protected override void OnStart()
        {
            base.OnStart();
            vvExerciseVideo.Prepared += OnVideoPlayerPrepared;
            LaunchVideo();
        }

        protected override void OnStop()
        {
            base.OnStop();
            vvExerciseVideo.Prepared -= OnVideoPlayerPrepared;
        }

        private void LaunchVideo()
        {
            string videoUri = "http://bitly.com/1MC3Gig";
            vvExerciseVideo.SetVideoURI(Android.Net.Uri.Parse(videoUri));
            vvExerciseVideo.Start();
        }

        private void OnVideoPlayerPrepared(object sender, EventArgs e)
        {
            mediaController.SetAnchorView(vvExerciseVideo);
            mediaController.Show(3000);
        }

    }
}