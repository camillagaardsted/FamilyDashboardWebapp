using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyDashboard
{

    // this class contains the settings for this app
    class LocalAppSettings
    {
        // all settingss here are made anonymous - please contact me if you want info about how this is configured
        public static void SetSettings()
        {

            Windows.Storage.ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;
            localSettings.Values["FIUsername"] = "username";
            localSettings.Values["FIPassword"] = "password";
            localSettings.Values["childname3"] = "Name1";

            localSettings.Values["childname2"] = "Name2";

            localSettings.Values["childname1"] = "Name3";


            localSettings.Values["skoleurl"] = "school intra url";
            localSettings.Values["emuloginurl"] = "login.emu.dk";
            localSettings.Values["child2homeworkurl"] = "url1";

            localSettings.Values["child3homeworkurl"] = "url2";

        }

    }

    


}
