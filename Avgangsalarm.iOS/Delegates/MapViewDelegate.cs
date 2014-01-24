using System;
using MonoTouch.MapKit;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace Avgangsalarm.iOS.Delegates
{
	internal class MapViewDelegate : MKMapViewDelegate
	{
		private bool _locationSet = false;

		public override void DidUpdateUserLocation(MKMapView mapView, MKUserLocation userLocation)
		{
			if (!_locationSet) {
				_locationSet = true;
				ZoomToUserLocation (mapView, userLocation);
			} 
			else 
			{
				mapView.SetCenterCoordinate(userLocation.Coordinate, true);
			}
		}

		void ZoomToUserLocation (MKMapView mapView, MKUserLocation l)
		{
			var span = new MKCoordinateSpan 
			{
				LatitudeDelta = 0.1,
				LongitudeDelta = 0.1,
			};

			var region = new MKCoordinateRegion  
			{
				Center = l.Coordinate,
				Span = span,
			};

			mapView.SetRegion (region, true);
		}

		[Obsolete ("Since iOS 7 it is recommnended that you use GetRendererForOverlay")] 
		// TODO: Finn ut av denne
		public override MKOverlayView GetViewForOverlay (MKMapView mapView, NSObject overlay)
		{
			var circleOverlay = overlay as MKCircle;
			var circleView = new MKCircleView (circleOverlay);
			circleView.FillColor = UIColor.Red;
			circleView.Alpha = 0.2f;
			return circleView;		
		}
	}
}

