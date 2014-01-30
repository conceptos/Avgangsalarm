using NUnit.Framework;
using System;
using Avgangsalarm.Core.Services.Impl;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avgangsalarm.Core.Tests
{

	public class TrafikkDataAdapterFake : ITrafikkDataAdapter
	{
		#region ITrafikkDataAdapter implementation

		public Task<IEnumerable<LineDeparture>> GetLineDeparturesForStopId (int stopId)
		{
			var departures =  
				new List<LineDeparture> 
			{
				new LineDeparture 
				{
					LineRef = 31,
					ExpectedDepartureTime = "/Date(1390390153000+0100)/"
				}
			};

			return Task.FromResult (departures as IEnumerable<LineDeparture>);
		}

		#endregion
	}
}
