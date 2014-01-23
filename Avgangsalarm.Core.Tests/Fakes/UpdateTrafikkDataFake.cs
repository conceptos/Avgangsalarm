using System;
using Avgangsalarm.Core.Services;
using System.Collections.Generic;
using Avgangsalarm.Core.Models;

namespace Avgangsalarm.Core.Tests
{
	public class UpdateTrafikkDataFake : IUpdateTrafikkdata
	{
		#region IUpdateTrafikkdata implementation

		public IEnumerable<Departure> GetDeparturesForStop (int stopId, IEnumerable<Line> lines)
		{
			return new List<Departure> ();
		}

		#endregion
	}
}

