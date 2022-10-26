namespace DeviceOrientationMAUI;

public partial class MainPage : ContentPage
{
	int count = 0;
	private readonly DeviceOrientationService _deviceOrientationService;

    public MainPage()
	{
		InitializeComponent();
		//Shell.Current.DisplayAlert("Orientation", DeviceDisplay.Current.MainDisplayInfo.Orientation.ToString(), "Ok");

		DeviceDisplay.Current.MainDisplayInfoChanged += Current_MainDisplayInfoChanged;
        _deviceOrientationService = new DeviceOrientationService();
    }

	private void Current_MainDisplayInfoChanged(object sender, DisplayInfoChangedEventArgs e)
	{
        Shell.Current.DisplayAlert("Orientation", $"Current Orientation: {DeviceDisplay.Current.MainDisplayInfo.Orientation}", "Ok");
    }

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicked {count} time";
		else
			CounterBtn.Text = $"Clicked {count} times";

		SemanticScreenReader.Announce(CounterBtn.Text);

		Shell.Current.DisplayAlert("Orientation", DeviceDisplay.Current.MainDisplayInfo.Orientation.ToString(), "Ok");
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
        switch (DeviceDisplay.Current.MainDisplayInfo.Orientation)
		{
			case DisplayOrientation.Landscape: _deviceOrientationService.SetDeviceOrientation(DisplayOrientation.Portrait); break;
			case DisplayOrientation.Portrait: _deviceOrientationService.SetDeviceOrientation(DisplayOrientation.Landscape); break;
		}

        // Note: DeviceDisplay.Current.MainDisplayInfoChanged does not get fire when we change the orientation programatically
        // We can call the event handler method from here explicitely
    }
}

