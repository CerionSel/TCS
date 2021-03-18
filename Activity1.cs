using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using System;

namespace TamagochiSel
{

    [Activity(
        Label = "@string/app_name",
        MainLauncher = true,
        Icon = "@drawable/icon",
        AlwaysRetainTaskState = true,
        LaunchMode = LaunchMode.SingleInstance,
        ScreenOrientation = ScreenOrientation.FullUser,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.Keyboard | ConfigChanges.KeyboardHidden | ConfigChanges.ScreenSize
    )]
    public class Activity1 : AndroidGameActivity
    {
        private Game1 _game;
        private View _view;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            //ISharedPreferencesEditor editor = prefs.Edit();
            //editor.PutBoolean("key_for_my_bool_value", mBool);
            //editor.Apply();        // applies changes asynchronously on newer APIs
            string jsonPet = prefs.GetString("jsonPet", "Snake");

            if (jsonPet != null)
            {
                //Pet pet = JsonConvert.DeserializeObject<Pet>(jsonPet);
                Pet pet = new Pet(jsonPet, jsonPet);
                _game = new Game1(pet);
                _view = _game.Services.GetService(typeof(View)) as View;

                SetContentView(Resource.Layout.activity_main);

                FrameLayout gameView = FindViewById<FrameLayout>(Resource.Id.frameLayout1);
                gameView.AddView(_view);
                _game.Run();
                RunOnUiThread(() => {
                    var alarmIntent = new Intent(this, typeof(BackgroundReceiver));

                    var pending = PendingIntent.GetBroadcast(this, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);

                    var alarmManager = GetSystemService(AlarmService).JavaCast<AlarmManager>();
                    alarmManager.SetInexactRepeating(AlarmType.ElapsedRealtime, 1000, 480000, pending); //480000мс == 8мин
                });
                
            }
            else
            {
                Intent intent = new Intent(this, typeof(SelectPet));
                StartActivity(intent);
                Finish();
            }
        }
    }

    

    [BroadcastReceiver]
    public class BackgroundReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            PowerManager pm = (PowerManager)context.GetSystemService(Context.PowerService);
            PowerManager.WakeLock wakeLock = pm.NewWakeLock(WakeLockFlags.Partial, "BackgroundReceiver");
            wakeLock.Acquire();
            pet
            Console.WriteLine("w");

            wakeLock.Release();
        }
    }
}
