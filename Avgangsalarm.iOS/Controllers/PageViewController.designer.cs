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
	[Register ("PageViewController")]
	partial class PageViewController
	{
		[Outlet]
		MonoTouch.UIKit.UIPageControl PageControl { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (PageControl != null) {
				PageControl.Dispose ();
				PageControl = null;
			}
		}
	}
}
