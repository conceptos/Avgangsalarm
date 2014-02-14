using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;
using System.Collections.Generic;
using System.Linq;

namespace Avgangsalarm.iOS
{

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
