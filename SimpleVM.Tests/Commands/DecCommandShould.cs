using FluentAssertions;
using NUnit.Framework;
using SimpleVM.Commands;

namespace SimpleVM.Tests.Commands
{
	[TestFixture]
	[Category("Commands")]
	public class DecCommandShould : CommandTest<DecCommand>
	{
		[Test]
		public void Increase_Given_Register_By_One()
		{
			// arrange
			Registers[4] = 8;

			// act
			Command.Execute(4);

			// Assert
			Registers[4].Should().Be(7);
		}

		[Test]
		public void Gracefuly_Handle_Overflow()
		{
			// arrange
			Registers[10] = 0;

			// act
			Command.Execute(10);

			// Assert
			Registers[10].Should().Be(255);
		}
	}
}