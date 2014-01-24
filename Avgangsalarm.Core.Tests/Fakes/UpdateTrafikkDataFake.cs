using System;
using Avgangsalarm.Core.Services;
using System.Collections.Generic;
using Avgangsalarm.Core.Models;
using System.Threading.Tasks;

namespace Avgangsalarm.Core.Tests
{
	public class UpdateTrafikkDataFake : IUpdateTrafikkdata
	{
		private List<int> _stopIds = new List<int> ();

		public bool GetDeparturesForStopWasCalledForRegion (int stop)
		{
			return _stopIds.Contains(stop);
		}

		#region IUpdateTrafikkdata implementation

		public Task<IEnumerable<Departure>> GetDeparturesForStop (int stopId)
		{
			_stopIds.Add (stopId);
			return Task.FromResult(new List<Departure> () as IEnumerable<Departure>);
		}

		#endregion
	}
}

