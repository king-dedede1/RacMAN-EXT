using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RacMAN.API;

/**
 * Static class for using webMAN's web commands on ps3
 * only added a couple because the rest dont really matter
 */
public static class WebMAN
{
    // Should be switched to HttpClient
    private static WebClient _client = new();

    private static string Get(string url)
    {
        try
        {
            return _client.DownloadString(url);
        }
        catch
        {
            return "";

        }
    }

    public static string GetGameTitleID(string ip)
    {
        var output = Get($"http://{ip}/cpursx.ps3?/sman.ps3");
        int gamePos = output.IndexOf("target=\"_blank\">") + 16;
        return output.Substring(gamePos, 9);
    }

    public static string GetGameTitle(string ip)
    {
        var cpursx = Get($"http://{ip}/cpursx.ps3");
        int loc = cpursx.IndexOf("http://google.com/search?q=");
        if (loc == -1)
        {
            return "PS3 Game";
        }
        {
            int i = 0;
            for (; cpursx[i + loc + 27] != '\"'; i++) { }
            return cpursx.Substring(loc + 27, i);
        }
    }

    public static void PauseRSX(string ip)
    {
        Get($"http://{ip}/xmb.ps3$rsx_pause");
    }

    public static void ContinueRSX(string ip)
    {
        Get($"http://{ip}/xmb.ps3$rsx_continue");
    }

    public static void PrepareRatchetron(string ip)
    {
        // Check if Ratchetron is already loaded
        string slot6sprx = Get($"http://{ip}/home.ps3mapi");

        bool ratchetronLoaded = slot6sprx.Contains("ratchetron_server.sprx");

        if (ratchetronLoaded)
        {
            return;
        }

        Get($"http://{ip}/vshplugin.ps3mapi?prx=%2Fdev_hdd0%2Ftmp%2Fratchetron_server.sprx&load_slot=6");
    }
}
