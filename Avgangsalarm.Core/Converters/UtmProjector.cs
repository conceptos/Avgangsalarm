using System;

namespace Avgangsalarm.Core.Converters
{
	public static class UtmProjector
	{
		private const double A = 6378137; // jordradius
		private const double B = 6356752.3;
		private const double EccSquared = 1 - ((B / A) * (B / A)); //= 0.00672267
		private const double K0 = 0.9996;
		private const double Deg2Rad = Math.PI / 180.0;
		private const double Rad2Deg = 180.0 / Math.PI;

		public static Geokoordinat UtmInverseProjectUtm32N(Kartkoordinat koordinat)
		{
			return UtmInverseProject(koordinat, 32);
		}

		private static Geokoordinat UtmInverseProject(Kartkoordinat koordinat, int zone)
		{
			var e1 = (1 - Math.Sqrt(1 - EccSquared)) / (1 + Math.Sqrt(1 - EccSquared));

			var x = koordinat.X - 500000;
			var y = koordinat.Y;

			var longOrigin = (zone - 1) * 6 - 180 + 3;
			const double eccPrimeSquared = (EccSquared) / (1 - EccSquared);

			var m = y / K0;
			var mu = m / (A * (1 - EccSquared / 4 - 3 * EccSquared * EccSquared / 64 - 5 * EccSquared * EccSquared * EccSquared / 256));

			var phi1Rad = (mu + (3 * e1 / 2 - 27 * e1 * e1 * e1 / 32) * Math.Sin(2 * mu)
				+ (21 * e1 * e1 / 16 - 55 * e1 * e1 * e1 * e1 / 32) * Math.Sin(4 * mu)
				+ (151 * e1 * e1 * e1 / 96) * Math.Sin(6 * mu));

			var n1 = A / Math.Sqrt(1 - EccSquared * Math.Sin(phi1Rad) * Math.Sin(phi1Rad));
			var t1 = Math.Tan(phi1Rad) * Math.Tan(phi1Rad);
			var c1 = eccPrimeSquared * Math.Cos(phi1Rad) * Math.Cos(phi1Rad);
			var r1 = A * (1 - EccSquared) / Math.Pow(1 - EccSquared * Math.Sin(phi1Rad) * Math.Sin(phi1Rad), 1.5);
			var d = x / (n1 * K0);

			return new Geokoordinat
			{
				Lon = ((longOrigin * Deg2Rad + (
					(d - (1 + 2 * t1 + c1) * d * d * d / 6 + (5 - 2 * c1 + 28 * t1 - 3 * c1 * c1 + 8 * eccPrimeSquared + 24 * t1 * t1) * d * d * d * d * d / 120)
					/ Math.Cos(phi1Rad))) * Rad2Deg),

				Lat = ((phi1Rad - (n1 * Math.Tan(phi1Rad) / r1) * 
					(d * d / 2 - (5 + 3 * t1 + 10 * c1 - 4 * c1 * c1 - 9 * eccPrimeSquared) * d * d * d * d / 24 + 
						(61 + 90 * t1 + 298 * c1 + 45 * t1 * t1 - 252 * eccPrimeSquared - 3 * c1 * c1)
						* d * d * d * d * d * d / 720)) * Rad2Deg)
			};
		}
	}

	public struct Geokoordinat
	{
		public double Lat;
		public double Lon;
	}

	public struct Kartkoordinat
	{
		public double X;
		public double Y;
	}
}

