using System;
using MonoTouch.UIKit;
using Avgangsalarm.Core;
using System.Collections.Generic;
using System.Linq;

namespace Avgangsalarm.iOS
{
	public class RegionTableViewSource : UITableViewSource
	{
		string cellIdentifier = "RegionTableViewCell";
		private Location[] _locations;

		public RegionTableViewSource (IEnumerable<Location> locations)
		{
			_locations = locations.ToArray ();
		}

		#region implemented abstract members of UITableViewSource

		public override int RowsInSection (UITableView tableview, int section)
		{
			return _locations.Length;
		}

		public override UITableViewCell GetCell (UITableView tableView, MonoTouch.Foundation.NSIndexPath indexPath)
		{
			var cell = DequeueOrCreateCell (tableView);

			var location = _locations [indexPath.Row];

			cell.TextLabel.Text = location.Name;

			//var imagePath = 
			//cell.ImageView.Image = UIImage.FromBundle (imagePath);

			return cell;
		}

		#endregion

		UITableViewCell DequeueOrCreateCell (UITableView tableView)
		{
			var cell = tableView.DequeueReusableCell (cellIdentifier);
			if (cell == null) 
			{
				cell = new UITableViewCell (UITableViewCellStyle.Default, cellIdentifier);
			}

			return cell;
		}
	}
}

