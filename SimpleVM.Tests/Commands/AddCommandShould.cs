using FluentAssertions;
using NUnit.Framework;
using SimpleVM.Commands;

namespace SimpleVM.Tests.Commands
{
    public class AddCommandShould : CommandTest<AddCommand>
    {
        [Test]
        public void Add_Given_Register_Values()
        {
            // arrange
            Registers[3] = 5;
            Registers[6] = 8;

            // act
            Command.Execute(0x63); // MOV R3, R6

            // assert
            Registers[3].Should().Be(13);
        }
    }
}