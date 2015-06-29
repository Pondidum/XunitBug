using System;
using Xunit;
using Xunit.Abstractions;

namespace XunitBug
{
	public interface IEventStore
	{
		int? GetLatestSequenceFor<TKey>(TKey aggegateID);
	}

	public class TestEventStore : IEventStore
	{
		public int? Value { get; set; }

		public int? GetLatestSequenceFor<TKey>(TKey aggegateID)
		{
			return Value;
		}
	}

	public class Tests
	{
		[Fact]
		public void When_faking_a_value()
		{
			DoTest(new TestEventStore());
		}

		public void DoTest(IEventStore store)
		{
			var test = store.GetLatestSequenceFor(Guid.NewGuid());

			Assert.Equal(null, test);
		}
	}
}
