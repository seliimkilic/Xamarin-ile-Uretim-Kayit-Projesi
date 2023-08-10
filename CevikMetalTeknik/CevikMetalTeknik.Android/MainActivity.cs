using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Environment = Android.OS.Environment;
using Android.Content;
using Android;
using Android.Support.V4.App;

namespace CevikMetalTeknik.Droid
{
    [Activity(Label = "CevikMetalTeknik", Icon = "@mipmap/ceviklogo", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Android.Content.PM.Permission[] grantResults)
        //{
        //    Plugin.CurrentActivity.CrossCurrentActivity.Current.Activity = this;
        //    Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //}

        private void RequestStorageAccess()
        {
            if (!Environment.IsExternalStorageManager)
            {
                StartActivityForResult(new Intent(Android.Provider.Settings.ActionManageAllFilesAccessPermission), 3);
            }
        }


        //protected override void OnCreatee(Bundle bundle)
        //{
        //    if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
        //    {
        //        if (!(CheckPermissionGranted(Manifest.Permission.ReadExternalStorage) && !CheckPermissionGranted(Manifest.Permission.WriteExternalStorage)))
        //        {
        //            RequestPermission();
        //        }
        //    }
        //    LoadApplication(new App());
        //}

        private void RequestPermission()
        {
            ActivityCompat.RequestPermissions(this, new string[] { Manifest.Permission.ReadExternalStorage, Manifest.Permission.WriteExternalStorage }, 0);
        }

        public bool CheckPermissionGranted(string Permissions)
        {
            // Check if the permission is already available.
            if (ActivityCompat.CheckSelfPermission(this, Permissions) != Permission.Granted)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}