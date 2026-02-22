using Windows.Networking.NetworkOperators;
using Windows.Networking.Connectivity;

Console.WriteLine("Hotspot System Starting...");

// The Wi-Fi adapter may not be fully initialized immediately after boot, so we implement a 15 second safety delay;
await Task.Delay(15000);

try
{
    // Retrieve the active internet connection profile, whether it is Ethernet or Wi-Fi;
    var connectionProfile = NetworkInformation.GetInternetConnectionProfile();

    if (connectionProfile == null) // If no active connection profile is found;
    {
        File.AppendAllText("hotspot_log.txt", $"{DateTime.Now}: Connection profile not found.\n");
        return;
    }

    var tetheringManager = NetworkOperatorTetheringManager.CreateFromConnectionProfile(connectionProfile);

    // Turn on the hotspot if it is currently disabled;
    if (tetheringManager.TetheringOperationalState != TetheringOperationalState.On)
    {
        Console.WriteLine("Starting Hotspot...");
        var result = await tetheringManager.StartTetheringAsync();
        File.AppendAllText("hotspot_log.txt", $"{DateTime.Now}: Operation result: {result.Status}\n");
    }
    else
    {
        Console.WriteLine("Hotspot is already active!");
    }
}
catch (Exception ex)
{
    File.AppendAllText("hotspot_log.txt", $"{DateTime.Now}: ERROR: {ex.Message}\n");
}