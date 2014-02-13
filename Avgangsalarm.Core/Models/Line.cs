using System;
using System.Collections.Generic;

namespace Avgangsalarm.Core
{
	public class Line
	{
		public Line(string id, string destination)
		{
			Id = id;
			Destination = destination;
		}
		public string Id { get; private set; }
		public string Destination { get; set; }

		public override bool Equals (object obj)
		{
			var other = obj as Line;
			if(other == null)
			{
				return false;
			}

			return other.Id == Id && other.Destination == Destination;
		}

		public override int GetHashCode ()
		{
			var tuple = new Tuple<string, string> (Id, Destination);
			return tuple.GetHashCode ();
		}

		public override string ToString ()
		{
			return string.Format ("{0} {1}", Id, Destination);
		}
	}
}

