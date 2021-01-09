using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace DrSeries.Droid
{
    [Activity(Theme = "@style/MainTheme.SplashActivity",
        MainLauncher = true,
        NoHistory = true, Icon = "@drawable/icon")]
    public class SplashActivity : AppCompatActivity
    {
        // Launches the startup task
        protected override void OnCreate(Bundle bundle)
        {
            if (Window != null)
            {
                if (Window.DecorView != null)
                    Window.DecorView.SystemUiVisibility =
                        (StatusBarVisibility) ((int) Window.DecorView.SystemUiVisibility ^
                                               (int) SystemUiFlags.LayoutStable ^
                                               (int) SystemUiFlags.LayoutFullscreen);
                Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
                Window.SetFlags(WindowManagerFlags.Fullscreen, WindowManagerFlags.Fullscreen);
            }

            base.OnCreate(bundle);
            StartActivity(typeof(MainActivity));
        }
    }
}