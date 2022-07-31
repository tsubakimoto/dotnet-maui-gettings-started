// https://docs.microsoft.com/ja-jp/dotnet/maui/platform-integration/device/battery

namespace MauiSamples.Pages;

public partial class BatteryPage : ContentPage
{
	public BatteryPage()
	{
        InitializeComponent();
	}

    private bool _isBatteryLow = false;

    private void BatterySaverSwitch_Toggled(object sender, ToggledEventArgs e)
    {
        // Capture the initial state of the battery
        _isBatteryLow = Battery.Default.EnergySaverStatus == EnergySaverStatus.On;
        BatterySaverLabel.Text = $"Battery saver: {_isBatteryLow}";

        // Watch for any changes to the battery saver mode
        if (e.Value)
            Battery.Default.EnergySaverStatusChanged += Battery_EnergySaverStatusChanged;
        else
            Battery.Default.EnergySaverStatusChanged -= Battery_EnergySaverStatusChanged;
    }

    private void Battery_EnergySaverStatusChanged(object sender, EnergySaverStatusChangedEventArgs e)
    {
        // Update the variable based on the state
        _isBatteryLow = Battery.Default.EnergySaverStatus == EnergySaverStatus.On;
        BatterySaverLabel.Text = $"Battery saver: {_isBatteryLow}";
        BatteryStateLabel.Text = GetBatteryStateText();
        BatteryLevelLabel.Text = GetBatteryLevelText();
    }

    private string GetBatteryStateText()
    {
        return Battery.Default.State switch
        {
            BatteryState.Charging => "Battery is currently charging",
            BatteryState.Discharging => "Charger is not connected and the battery is discharging",
            BatteryState.Full => "Battery is full",
            BatteryState.NotCharging => "The battery isn't charging.",
            BatteryState.NotPresent => "Battery is not available.",
            BatteryState.Unknown => "Battery is unknown",
            _ => "Battery is unknown"
        };
    }

    private string GetBatteryLevelText()
    {
        return $"Battery is {Battery.Default.ChargeLevel * 100}% charged.";
    }
}