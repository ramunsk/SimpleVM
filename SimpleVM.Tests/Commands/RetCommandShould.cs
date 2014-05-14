using FluentAssertions;
using NUnit.Framework;
using SimpleVM.Commands;

namespace SimpleVM.Tests.Commands
{
	public class RetCommandShould : CommandTest<RetCommand>
	{
		[Test]
		public void Set_RET_Flag()
		{
			// arrange
			Cpu.Flags = 0;

			// act
			Command.Execute(0); // parameter does not matter

			// assert
			Cpu.Flags.Should().Be(2);
		}
	}
}