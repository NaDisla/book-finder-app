using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using book_finder_app.Droid.Renderers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:ExportRenderer(typeof(Button),typeof(CustomButtonRendererDroid))]
namespace book_finder_app.Droid.Renderers
{
    public class CustomButtonRendererDroid : ButtonRenderer
    {
        public CustomButtonRendererDroid(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
            Control.SetAllCaps(false);
        }
    }
}