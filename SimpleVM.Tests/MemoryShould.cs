using FluentAssertions;
using NUnit.Framework;

namespace SimpleVM.Tests
{
    [TestFixture]
    public class MemoryShould
    {
        [Test]
        public void Read_From_A_Given_Address()
        {
            // arrange
            var memory = new Memory();
            memory.Load(new byte[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });

            // act
            var data = memory.Read(5);

            // assert
            data.Should().Be(6);
        }

        [Test]
        public void Load_Data_To_The_Start_Of_Memory()
        {
            // arrange
            var memory = new Memory();

            // act
            memory.Load(new byte[] { 1, 2, 3 });
            
            // assert
            memory.Read(0).Should().Be(1);
            memory.Read(1).Should().Be(2);
            memory.Read(2).Should().Be(3);
            memory.Read(3).Should().Be(default(byte));
        }
    }
}