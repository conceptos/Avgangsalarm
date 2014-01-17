using System;

namespace Avgangsalarm.Core
{
	public class Location
	{
		public Location (string id, string name, int latitude, int longitude, int alertZoneRadiusInMeters)
		{
			Id = id;
			Name = name;
			Latitude = latitude;
			Longitude = longitude;
			AlertZoneRadiusInMeters = alertZoneRadiusInMeters;
		}

		public string Id { get; private set; }
		public string Name { get; private set; }
		public int Latitude { get; private set; }
		public int Longitude { get; private set; }
		public int AlertZoneRadiusInMeters { get; private set; }
		public DateTime LastEnteredZone { get; private set;}
	}
}

