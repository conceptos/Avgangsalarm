using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Linq;

namespace Avgangsalarm.iOS
{
	public partial class PageViewController : UIViewController
	{
		private UIPageViewController _pageController;
		List<UIViewController> _subControllers = new List<UIViewController>();

		public PageViewController () : base ("PageView", null)
		{
		}

		public int PageCount
		{
			get { return _subControllers.Count; }
		}

		public IEnumerable<UIViewController> Pages
		{
			get { return _subControllers.AsEnumerable (); }
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			SetUpPageController ();
			View.AddSubview(_pageController.View);
		}

		void SetUpPageController ()
		{
			SetupPageController ();
			SetupPageNumberControl ();
		}

		void SetupPageController ()
		{
			_pageController = new UIPageViewController (UIPageViewControllerTransitionStyle.Scroll, UIPageViewControllerNavigationOrientation.Horizontal, UIPageViewControllerSpineLocation.Min);
			var overviewViewController = new OverviewViewController ();
			var mapViewController = new MapViewController ();
			_subControllers.Add (overviewViewController);
			_subControllers.Add (mapViewController);
			_pageController.SetViewControllers (new[] {
				overviewViewController
			}, UIPageViewControllerNavigationDirection.Forward, false, s =>  {
			});
			_pageController.DataSource = new PageDataSource (this);
			_pageController.View.Frame = View.Bounds;
		}

		void SetupPageNumberControl ()
		{
			PageControl.CurrentPage = 0;
			PageControl.Pages = Pages.Count ();
			_pageController.DidFinishAnimating += HandleDidFinishAnimating;
		}

		void HandleDidFinishAnimating (object sender, UIPageViewFinishedAnimationEventArgs e)
		{
			var pages = Pages.ToList ();
			var viewController = _pageController.ViewControllers.FirstOrDefault ();
			var index = pages.IndexOf (viewController);
			PageControl.CurrentPage = index;
		}
	}
}

