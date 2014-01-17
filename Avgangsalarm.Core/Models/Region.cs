using System;

namespace Avgangsalarm.Core
{
	public class Region
	{
		public Region(float latitude, float longitude, int alertZoneRadiusInMeters)
		{
			Latitude = latitude;
			Longitude = longitude;
			AlertZoneRadiusInMeters = alertZoneRadiusInMeters;
		}
		public float Latitude { get; private set; }
		public float Longitude { get; private set; }
		public int AlertZoneRadiusInMeters { get; private set; }

		public void IsWithinRegion ()
		{
			throw new NotImplementedException ();
		}
	}
}
