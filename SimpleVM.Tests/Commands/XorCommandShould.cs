using FluentAssertions;
using NUnit.Framework;
using SimpleVM.Commands;

namespace SimpleVM.Tests.Commands
{
    public class XorCommandShould : CommandTest<XorCommand>
    {
        [Test]
        public void Do_XOR_On_Given_Registers()
        {
            // arrange
            Registers[5] = 10; // 0000 1010
            Registers[8] = 12; // 0000 1100

            // act
            Command.Execute(0x85); // XOR R5, R8

            // assert
            Registers[5].Should().Be(6); // 0000 0110
        }
    }
}