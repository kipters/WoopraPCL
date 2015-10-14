using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using WoopraPCL;
using WoopraPCL.iOS;

namespace SampleApp.iOS
{
	partial class MainTableViewController : UITableViewController
	{
		public MainTableViewController (IntPtr handle) : base (handle)
		{
		}

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            playBarButtonItem.Clicked += (object sender, EventArgs e) => 
                {
                    var domain = domainTextField.Text?.Trim();
                    var email = emailTextField.Text?.Trim();
                    var path = pathTextField.Text?.Trim();

                    if (string.IsNullOrEmpty(domain) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(path))
                    {
                        ShowAlert("Error", "Check all the fields");
                        return;
                    }

                    try
                    {
                        var visitor = WoopraVisitor.CreateWithEmail(new TouchWoopraCrypto(), email);
                        var device = UIDevice.CurrentDevice;
                        var tracker = new WoopraTracker(visitor, device.Model, $"{device.SystemName} {device.SystemVersion}", "SampleApp", "ios")
                            {
                                Domain = domain
                            };
                        var wEvent = new WoopraEvent("pv");
                        wEvent.Properties.Add("url", path);
                        tracker.TrackEvent(wEvent);

                        ShowAlert("Completed", "");
                    }
                    catch (Exception ex)
                    {
                        ShowAlert(ex.GetType().Name, ex.Message);
                    }
                };
        }

        private void ShowAlert(string title, string text)
        {
            var controller = UIAlertController.Create(title, text, UIAlertControllerStyle.Alert);
            controller.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Default, null));
            PresentViewController(controller, true, null);
        }
	}
}
