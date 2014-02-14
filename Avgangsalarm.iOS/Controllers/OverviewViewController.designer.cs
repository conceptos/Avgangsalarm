// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using MonoTouch.Foundation;
using System.CodeDom.Compiler;

namespace Avgangsalarm.iOS
{
	[Register ("OverviewViewController")]
	partial class OverviewViewController
	{
		[Outlet]
		MonoTouch.UIKit.UITableView LocationListView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UINavigationBar Menu { get; set; }

		[Action ("BtnAddClicked:")]
		partial void BtnAddClicked (MonoTouch.Foundation.NSObject sender);
		
		void ReleaseDesignerOutlets ()
		{
			if (LocationListView != null) {
				LocationListView.Dispose ();
				LocationListView = null;
			}

			if (Menu != null) {
				Menu.Dispose ();
				Menu = null;
			}
		}
	}
}
