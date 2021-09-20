using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using book_finder_app.Customs;
using book_finder_app.Droid.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(CustomEntryRenderer),typeof(CustomEntryRendererDroid))]
namespace book_finder_app.Droid.Renderers
{
    public class CustomEntryRendererDroid : EntryRenderer
    {
        public CustomEntryRendererDroid(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if(Control != null) { Control.SetBackgroundColor(Android.Graphics.Color.Transparent); }
        }
    }
}