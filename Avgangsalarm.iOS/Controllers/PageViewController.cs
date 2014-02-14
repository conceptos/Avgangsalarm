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
			_pageController = new UIPageViewController(UIPageViewControllerTransitionStyle.Scroll,
				UIPageViewControllerNavigationOrientation.Horizontal,
				UIPageViewControllerSpineLocation.Min);

			var overviewViewController = new OverviewViewController ();
			var mapViewController = new MapViewController ();

			_subControllers.Add (overviewViewController);
			_subControllers.Add (mapViewController);


 			_pageController.SetViewControllers(
				new [] { overviewViewController }, 
				UIPageViewControllerNavigationDirection.Forward, false, 
				s => { });

			_pageController.DataSource = new PageDataSource (this);

			_pageController.View.Frame = View.Bounds;
			View.AddSubview(_pageController.View);
		}
	}

	public class PageDataSource : UIPageViewControllerDataSource
	{
		PageViewController _parentController;
		public PageDataSource(PageViewController parentController)
		{
			_parentController = parentController;
		}

		public override UIViewController GetPreviousViewController (UIPageViewController pageViewController, UIViewController referenceViewController)
		{
			var controllers = _parentController.Pages.ToList ();
			var index = controllers.IndexOf (referenceViewController);
			index--;
			var previous = (index <= 0) ? null :  controllers [index];
			return previous;
		}

		public override UIViewController GetNextViewController (UIPageViewController pageViewController, UIViewController referenceViewController)
		{
			var controllers = _parentController.Pages.ToList ();
			var index = controllers.IndexOf (referenceViewController);
			index++;
			var next = (index >= controllers.Count) ? null :  controllers [index];
			return next;
		}
	}
}

