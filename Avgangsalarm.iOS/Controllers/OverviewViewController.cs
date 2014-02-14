// This file has been autogenerated from a class added in the UI designer.

using System;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Avgangsalarm.Core.Services;
using Avgangsalarm.Core;
using TinyIoC;

namespace Avgangsalarm.iOS
{
	public partial class OverviewViewController : UIViewController
	{
		private readonly ILog _logger = LogManager.GetLogger ( typeof(OverviewViewController));
		private readonly IUpdateEngine _update = TinyIoCContainer.Current.Resolve<IUpdateEngine>();
		private readonly ILocationRepository _lokasjonRepository = TinyIoCContainer.Current.Resolve<ILocationRepository>();

		public OverviewViewController() : base("OverviewView", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}

		partial void BtnAddClicked (MonoTouch.Foundation.NSObject sender)
		{
			_logger.Info("OverViewViewController: Add clicked!");
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();		

			// Perform any additional setup after loading the view, typically from a nib.
			SetupMenu ();

			_update.Start ();
		}

		public override void ViewWillAppear (bool animated)
		{
			var regions = _lokasjonRepository.FetchAll ();
			LocationListView.Source = new RegionTableViewSource (regions);

			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion

		void SetupMenu ()
		{
			var titleItem = (UINavigationItem)Menu.Items [0];
			titleItem.LeftBarButtonItems = new [] {
				new UIBarButtonItem (),
				new UIBarButtonItem (UIBarButtonSystemItem.FlexibleSpace),
			};

			var addButton = new UIBarButtonItem (UIBarButtonSystemItem.Add);
			titleItem.RightBarButtonItem = addButton;


			addButton.Clicked += (object sender, EventArgs e) => { TodoAlert(); };
		}

		public static void TodoAlert()
		{
			using (var alert = new UIAlertView ("TODO Alert", "Not implemented", null, "OK", null)) 
			{
				alert.Show ();
			}
		}
	}
}
