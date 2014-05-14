using FluentAssertions;
using NUnit.Framework;
using SimpleVM.Commands;

namespace SimpleVM.Tests.Commands
{
    [TestFixture]
    [Category("Commands")]
    public class MovCommandShould : CommandTest<MovCommand>
    {
        [Test]
        public void Copy_Value_From_One_Register_To_Another()
        {
            // arrange
            Registers[5] = 8;
            Registers[6] = 0;


            // act
            Command.Execute(0x56);

            // Assert
            Registers[6].Should().Be(8);
        }
    }
}