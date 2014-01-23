using NUnit.Framework;
using System;
using Avgangsalarm.Core.Services;
using System.Collections.Generic;

namespace Avgangsalarm.Core.Tests.Fakes
{
	public class LocationRepositoryFake : ILocationRepository
	{
		public LocationRepositoryFake()
		{
			AddedLocations = new List<Location> ();
			DeletedLocations = new List<Location> ();
		}

		public IEnumerable<Location> AddedLocations { get; private set;}
		public IEnumerable<Location> DeletedLocations { get; private set;}
		public bool SaveCalled { get; private set;}
		public bool FetchAllCalled { get; private set;}

		#region ILocationRepository implementation

		public void Add (Location location)
		{
			((List<Location>)AddedLocations).Add (location);
		}

		public void Delete (Location location)
		{
			((List<Location>)DeletedLocations).Add (location);
		}

		public void Save ()
		{
			SaveCalled = true;
		}

		public IEnumerable<Location> FetchAll ()
		{
			FetchAllCalled = true;
			return _locations;
		}

		public void SetLoctions(IEnumerable<Location> locations)
		{
			_locations = locations;
		}

		private IEnumerable<Location> _locations;

		#endregion
	}
}

