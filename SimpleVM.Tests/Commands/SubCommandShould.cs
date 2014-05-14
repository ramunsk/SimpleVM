using FluentAssertions;
using NUnit.Framework;
using SimpleVM.Commands;

namespace SimpleVM.Tests.Commands
{
    public class SubCommandShould : CommandTest<SubCommand>
    {
        [Test]
        public void Subtract_Given_Register_Values()
        {
            // arrange
            Registers[3] = 8;
            Registers[6] = 5;

            // act
            Command.Execute(0x63); // SUB R3, R6

            // assert
            Registers[3].Should().Be(3);
        }
    }
}