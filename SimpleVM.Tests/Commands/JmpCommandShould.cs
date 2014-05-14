using FluentAssertions;
using NUnit.Framework;
using SimpleVM.Commands;

namespace SimpleVM.Tests.Commands
{
    public class JmpCommandShould : CommandTest<JmpCommand>
    {
        [Test]
        public void Should_Change_Instruction_Register_By_Given_Negative_Value()
        {
            // arrange
            Cpu.InstructionRegister = 40;
            sbyte address = -20;
            
            // act
            Command.Execute((byte)address);

            // assert
            Cpu.InstructionRegister.Should().Be(20);
        }

        [Test]
        public void Should_Change_Instruction_Register_By_Given_Positive_Value()
        {
            // arrange
            Cpu.InstructionRegister = 40;
            
            // act
            Command.Execute(20);

            // assert
            Cpu.InstructionRegister.Should().Be(60);
        }

    }
}