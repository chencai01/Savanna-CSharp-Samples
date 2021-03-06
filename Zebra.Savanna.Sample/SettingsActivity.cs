using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Views;

using AndroidX.AppCompat.App;
using AndroidX.Preference;

namespace Zebra.Savanna.Sample
{
    [Activity(Name = "com.zebra.savanna.sample.SettingsActivity",
        ConfigurationChanges = ConfigChanges.KeyboardHidden | ConfigChanges.Orientation | ConfigChanges.ScreenSize,
        Label = "@string/title_activity_settings")]
    public class SettingsActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.settings_activity);
            SupportFragmentManager
                    .BeginTransaction()
                    .Replace(Resource.Id.settings, new SettingsFragment())
                    .Commit();
            SupportActionBar?.SetDisplayHomeAsUpEnabled(true);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Android.Resource.Id.Home)
            {
                // This ID represents the Home or Up button. In the case of this
                // activity, the Up button is shown. For
                // more details, see the Navigation pattern on Android Design:
                //
                // http://developer.android.com/design/patterns/navigation.html#up-vs-back
                //
                NavigateUpTo(new Intent(this, typeof(ItemListActivity)));
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        class SettingsFragment : PreferenceFragmentCompat
        {
            public override void OnCreatePreferences(Bundle savedInstanceState, string rootKey)
            {
                SetPreferencesFromResource(Resource.Xml.root_preferences, rootKey);
            }
        }
    }
}