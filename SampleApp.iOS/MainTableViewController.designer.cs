// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SampleApp.iOS
{
	[Register ("MainTableViewController")]
	partial class MainTableViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField domainTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField emailTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField pathTextField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIBarButtonItem playBarButtonItem { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (domainTextField != null) {
				domainTextField.Dispose ();
				domainTextField = null;
			}
			if (emailTextField != null) {
				emailTextField.Dispose ();
				emailTextField = null;
			}
			if (pathTextField != null) {
				pathTextField.Dispose ();
				pathTextField = null;
			}
			if (playBarButtonItem != null) {
				playBarButtonItem.Dispose ();
				playBarButtonItem = null;
			}
		}
	}
}
