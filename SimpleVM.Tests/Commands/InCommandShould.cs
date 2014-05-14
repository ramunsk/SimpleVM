using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using SimpleVM.Commands;

namespace SimpleVM.Tests.Commands
{
    public class InCommandShould : CommandTest<InCommand>
    {
        [Test]
        public void Put_Read_Data_To_A_Given_Register()
        {
            // arrange
            In.Read().Returns((byte?)47);

            // act
            Command.Execute(0x03);

            // assert
            Registers[3].Should().Be(47);
        }

        [Test]
        public void Not_Set_EOF_Flag_When_Data_Is_Read()
        {
            // arrange
            In.Read().Returns((byte?)47);

            // act
            Command.Execute(0x03);

            // assert
            Cpu.Flags.Should().Be(0);
        }

        [Test]
        public void Not_Change_Given_Register_When_Reading_EOF()
        {
            // arrange
            Registers[3] = 32;
            In.Read().Returns((byte?)null);

            // act
            Command.Execute(0x03);

            // assert
            Registers[3].Should().Be(32);
        }

        [Test]
        public void Set_EOF_Flag_When_EOF_Is_Read()
        {
            // arrange
            In.Read().Returns((byte?)null);

            // act
            Command.Execute(0x03);

            // assert
            Cpu.Flags.Should().Be(0x01);
        }
    }
}