using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TamagochiSel
{
    class AdapterPetSelect : BaseAdapter
    {

        Context context;
        ImageView petImage;
        TextView petTitle;

        public AdapterPetSelect(Context context, int resource, string petTitle)
        {
            this.context = context;
            petImage.SetImageResource(resource);
            this.petTitle.Text = petTitle;
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return position;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;
            if (row == null)
            {
                row = LayoutInflater.From(context).Inflate(Resource.Layout.SelectPetElement, null, false);
            }

            petTitle = row.FindViewById<TextView>(Resource.Id.PetName);
            petImage = row.FindViewById<ImageView>(Resource.Id.imageView1);
            return row;
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get
            {
                return 0;
            }
        }

    }

    class AdapterPetSelectViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}