using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using SimpleVM.Commands;

namespace SimpleVM.Tests.Commands
{
    public class LslCommandShould : CommandTest<LslCommand>
    {
        [Test]
        public void Shift_Given_Register_Value_To_Left_By_One()
        {
            // arrange 
            Registers[3] = 4;

            // act
            Command.Execute(3);

            // Assert
            Registers[3].Should().Be(8);
        }
    }
}