using UIKit;

namespace DeviceOrientationMAUI
{
    public partial class DeviceOrientationService
    {
        private static readonly IReadOnlyDictionary<DisplayOrientation, UIInterfaceOrientation> _iosDisplayOrientationMap =
            new Dictionary<DisplayOrientation, UIInterfaceOrientation>
            {
                [DisplayOrientation.Landscape] = UIInterfaceOrientation.LandscapeLeft,
                [DisplayOrientation.Portrait] = UIInterfaceOrientation.Portrait,
            };

        public partial void SetDeviceOrientation(DisplayOrientation displayOrientation)
        {
            if (_iosDisplayOrientationMap.TryGetValue(displayOrientation, out var iosOrientation))
                UIApplication.SharedApplication.SetStatusBarOrientation(iosOrientation, true);
        }
    }
}
