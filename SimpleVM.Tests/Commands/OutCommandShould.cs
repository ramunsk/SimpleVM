using NSubstitute;
using NUnit.Framework;
using SimpleVM.Commands;

namespace SimpleVM.Tests.Commands
{
    public class OutCommandShould : CommandTest<OutCommand>
    {
        [Test]
        public void Write_Value_Of_Given_Register_To_Output()
        {
            // arrange
            Registers[14] = 50;

            // act
            Command.Execute(0x0E);

            // assert
            Cpu.Out.Received().Write(50);
        }
    }
}