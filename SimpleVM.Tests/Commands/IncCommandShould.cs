using FluentAssertions;
using NUnit.Framework;
using SimpleVM.Commands;

namespace SimpleVM.Tests.Commands
{
	[TestFixture]
	[Category("Commands")]
	public class IncCommandShould : CommandTest<IncCommand>
	{
		[Test]
		public void Increase_Given_Register_By_One()
		{
			// arrange
			Registers[5] = 8;		

			// act
			Command.Execute(5);

			// Assert
			Registers[5].Should().Be(9);
		}

		[Test]
		public void Gracefuly_Handle_Overflow()
		{
			// arrange
			Registers[12] = 255;	

			// act
			Command.Execute(12);

			// Assert
			Registers[12].Should().Be(0);
		}
	}
}