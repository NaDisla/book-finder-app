using Android.Content;
using book_finder_app.Droid.Renderers;
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