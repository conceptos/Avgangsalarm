using System;
using NUnit.Framework;

namespace Avgangsalarm.Core.Tests.ModelTests
{
	[TestFixture]
	public class LineTests
	{
		Line _1_X = new Line("1", "X");
		Line _2_X = new Line("2", "X");
		Line _1_Y = new Line("1", "Y");
		Line _2_Y = new Line("2", "Y");

		Line _result = new Line("1", "X");

		[Test]
		public void NotEqual()
		{
			Assert.AreNotEqual (_result, null);
			Assert.AreNotEqual (_result, "dummy");
			Assert.AreNotEqual (_result, _1_Y);
			Assert.AreNotEqual (_result, _2_X);
			Assert.AreNotEqual (_result, _2_Y);
		}

		[Test]
		public void AreEqual()
		{
			Assert.AreEqual (_result, _1_X);
		}

		[Test]
		public void EqualHashCodeForEqualObjects()
		{
			var a = _1_X.GetHashCode ();
			var b = _result.GetHashCode ();
			Assert.AreEqual (a, b);
		}
	}
}

