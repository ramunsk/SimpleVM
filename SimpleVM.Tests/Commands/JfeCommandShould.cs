using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using SimpleVM.Commands;

namespace SimpleVM.Tests.Commands
{
    public class JfeCommandShould : CommandTest<JfeCommand>
    {
        [Test]
		[Category("Commands")]
		[TestCase(20, 120)]
		[TestCase(220, 64)]
        public void Change_Instruction_Register_By_Given_Positive_Value_If_FE_Flag_Is_Set(byte offset, byte expected)
        {
            // arrange
	        Cpu.InstructionRegister.Returns<byte>(100);
            Cpu.Flags.Returns<byte>(1);

            // act
            Command.Execute(offset);

            // Assert
            Cpu.InstructionRegister.Should().Be(expected);
        }

        [Test]
		[Category("Commands")]
		[TestCase(20)]
		[TestCase(220)]
        public void Change_Instruction_Register_By_Two_If_FE_Flag_Is_Not_Set(byte offset)
        {
            // arrange
            Cpu.InstructionRegister.Returns<byte>(100);
            Cpu.Flags = 0;

            // act
            Command.Execute(offset);

            // Assert
            Cpu.InstructionRegister.Should().Be(102);
        }
    }
}