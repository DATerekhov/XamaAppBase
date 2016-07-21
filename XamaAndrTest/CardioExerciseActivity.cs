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
using System.Timers;

namespace XamaAndrTest
{
    [Activity(Label = "CardioExerciseActivity")]
    public class CardioExerciseActivity : Activity
    {
        private TableLayout tlCardioParam;
        private Button bCardioBegin;
        private Button bCardioPause;
        private Button bCardioStop;
        private TextView tvTimer;
        private Chronometer chrono;
        private long lastPause;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.CardioExercise);

            bCardioBegin = FindViewById<Button>(Resource.Id.bCardioBegin);
            bCardioPause = FindViewById<Button>(Resource.Id.bCardioPause);
            bCardioStop = FindViewById<Button>(Resource.Id.bCardioStop);
            tlCardioParam = FindViewById<TableLayout>(Resource.Id.tlCardioParams);
            tvTimer = FindViewById<TextView>(Resource.Id.tvTimer);
            chrono = FindViewById<Chronometer>(Resource.Id.chronometer);

            //выгрузка параметров в таблицу
            for (var i = 0; i < 2; i++)
            {
                var tvTemp = new TextView(this);
                tvTemp.SetText("Дистанция", TextView.BufferType.Normal);
                tvTemp.SetTextSize(Android.Util.ComplexUnitType.Dip, 18.0f);

                var tvTemp2 = new TextView(this);
                tvTemp2.SetText("1000m", TextView.BufferType.Normal);
                tvTemp2.SetTextSize(Android.Util.ComplexUnitType.Dip, 18.0f);

                var trTemp = new TableRow(this);
                trTemp.AddView(tvTemp);
                trTemp.AddView(tvTemp2);

                tlCardioParam.AddView(trTemp);
            }
            //
            bCardioBegin.Click += BCardioBegin_Click;
            bCardioPause.Click += BCardioPause_Click;
            bCardioStop.Click += BCardioStop_Click;
        }

        private void BCardioStop_Click(object sender, EventArgs e)
        {
            chrono.Base = chrono.Base + SystemClock.ElapsedRealtime() - lastPause;
            chrono.Start();
        }

        private void BCardioPause_Click(object sender, EventArgs e)
        {
            lastPause = SystemClock.ElapsedRealtime();
            chrono.Stop();
        }

        private void BCardioBegin_Click(object sender, EventArgs e)
        {
            chrono.Base = SystemClock.ElapsedRealtime();
            chrono.Start();
            
            bCardioBegin.Visibility = ViewStates.Invisible;
            bCardioBegin.Focusable = false;

            bCardioPause.Visibility = ViewStates.Visible;
            bCardioPause.Focusable = true;

            bCardioStop.Visibility = ViewStates.Visible;
            bCardioStop.Focusable = true;
        }

    }
}