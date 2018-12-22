using Caliburn.Micro;
using System.Diagnostics;

namespace SaveTheVid.ViewModels
{
    class DialogAboutViewModel : Screen
    {
        private const string MySiteURL = @"http://www.elgaspar.com";
        private const string LicenseSaveTheVid = @"Resources\LICENSE SaveTheVid.txt";

        private const string LicenseCaliburnMicro = @"Resources\third-party licenses\LICENSE Caliburn.Micro.txt";
        private const string LicenseMahAppsMetro = @"Resources\third-party licenses\LICENSE MahApps.Metro.txt";
        private const string LicenseMahAppsMetroIconPacks = @"Resources\third-party licenses\LICENSE MahApps.Metro.IconPacks.txt";
        private const string LicenseControlzEz = @"Resources\third-party licenses\LICENSE ControlzEx.txt";
        private const string LicenseYoutubeDl = @"Resources\third-party licenses\LICENSE youtube-dl.txt";

        public MainViewModel ParentVM { get; }

        public DialogAboutViewModel(MainViewModel parent)
        {
            ParentVM = parent;
        }

        public void VisitMySite()
        {
            Process.Start(MySiteURL);
        }

        public void ShowMyLicense()
        {
            Process.Start(LicenseSaveTheVid);
        }

        public void ShowCaliburnMicroLicense()
        {
            Process.Start(LicenseCaliburnMicro);
        }

        public void ShowMahAppsMetroLicense()
        {
            Process.Start(LicenseMahAppsMetro);
        }

        public void ShowMahAppsMetroIconPacksLicense()
        {
            Process.Start(LicenseMahAppsMetroIconPacks);
        }

        public void ShowControlzExLicense()
        {
            Process.Start(LicenseControlzEz);
        }

        public void ShowYoutubeDlLicense()
        {
            Process.Start(LicenseYoutubeDl);
        }

        public void Ok()
        {
            //Do nothing
            TryClose(true);
        }

    }
}
