using FluentAssertions;
using NUnit.Framework;
using SimpleVM.Commands;

namespace SimpleVM.Tests.Commands
{
    [TestFixture]
    [Category("Commands")]
    public class MovcCommandShould : CommandTest<MovcCommand>
    {
        [Test]
        public void Copy_Given_Constant_To_R0()
        {
            // arrange
            Registers[0] = 6;

            // act
            Command.Execute(0x0F);

            // assert
            Registers[0].Should().Be(15);
        }
    }
}