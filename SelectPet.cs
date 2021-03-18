using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TamagochiSel
{
    [Activity(Label = "SelectPet")]
    public class SelectPet : ListActivity
    {
        List<string> pets = new List<string>() { "Sneak", "Hyena", "Scorpio", "Vulture" };
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.loginActivity);

            var ListAdapter = new ArrayAdapter<String>(this, Resource.Id.listView1, pets);
        }

        protected override void OnListItemClick(ListView l, View v, int position, long id)
        {
            var t = pets[position];
            Pet pet = new Pet(t, t);

            string json = JsonConvert.SerializeObject(pet);
            ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
            ISharedPreferencesEditor editor = prefs.Edit();
            editor.PutString("jsonPet", json);

            Intent intent = new Intent(this, typeof(Activity1));
            StartActivity(intent);
            Finish();
        }
    }
}