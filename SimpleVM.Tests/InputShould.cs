using FluentAssertions;
using NUnit.Framework;

namespace SimpleVM.Tests
{
    [TestFixture]
    [Category("Input")]
    public class InputShould
    {
        private byte[] _bytes;
        private Input _input;

        [SetUp]
        public void Setup()
        {
            _bytes = new byte[] {1, 2, 3};
            _input = new Input(_bytes);
        }

        [TearDown]
        public void TearDown()
        {
            _input = null;
            _bytes = null;
        }

        [Test]
        public void Read_Given_Data_Byte_By_Byte()
        {
            // act
            var byte1 = _input.Read();
            var byte2 = _input.Read();
            var byte3 = _input.Read();
            
            // assert
            byte1.Should().HaveValue();
            byte1.Should().Be(1);
            byte2.Should().HaveValue();
            byte2.Should().Be(2);
            byte3.Should().HaveValue();
            byte3.Should().Be(3);
        }

        [Test]
        public void Return_Null_When_Reading_Past_The_End_Of_Data()
        {
            // arrange
            _input.Read();
            _input.Read();
            _input.Read();

            // act
            var value = _input.Read();

            // assert
            value.Should().NotHaveValue();
        }
    }
}