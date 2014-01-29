using System;
using Avgangsalarm.Core;

namespace Avgangsalarm.iOS
{
	public static class TransportationTypeToImagePathConverter
	{
		public static string Convert(TransportationType t)
		{
			switch(t)
			{
			case TransportationType.Ferry:
				return "drift_baat_SORT";
			case TransportationType.Rail:
				return "drift_tog_SORT";
			case TransportationType.Tram:
				return "drift_trikk_SORT";
			case TransportationType.Metro:
				return "drift_T-bane_SORT";
			case TransportationType.Bus:
			default:
				return "drift_buss_SORT";
			}
		}
	}
}

