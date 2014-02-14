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
	[Register ("MapViewController")]
	partial class MapViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIView MapView { get; set; }

		[Outlet]
		MonoTouch.UIKit.UINavigationBar Menu { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (MapView != null) {
				MapView.Dispose ();
				MapView = null;
			}

			if (Menu != null) {
				Menu.Dispose ();
				Menu = null;
			}
		}
	}
}
