using System;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using SimpleVM.Commands;

namespace SimpleVM.Tests
{
	[TestFixture]
	[Category("CPU")]
	public class CpuShould
	{
        private IMemory _memory;
		private IInput _input;
	    private IOutput _output;
        private Cpu _cpu;

	    [SetUp]
		public void Setup()
	    {
	        _memory = Substitute.For<IMemory>();
		    _input = Substitute.For<IInput>();
	        _output = Substitute.For<IOutput>();
			
            _cpu = new Cpu(_memory, _input, _output);
		}

		[TearDown]
		public void TearDown()
		{
			_cpu = null;
		    _memory = null;
		    _input = null;
		    _output = null;
		}

		[Test]
		public void Have_Registers_Initialised()
		{
			// assert
			_cpu.Registers.Should().NotBeNull();
		}

		[Test]
		public void Have_16_Registers()
		{
			// assert
			_cpu.Registers.Length.Should().Be(16);
		}

		[Test]
		public void Have_Registers_Initialized_To_0()
		{
			// assert
			foreach (var register in _cpu.Registers)
			{
				register.Should().Be(0);
			}
		}

	    [Test]
        [Category("CPU")]
        [TestCase(0x01, typeof(IncCommand))]
        [TestCase(0x02, typeof(DecCommand))]
        [TestCase(0x03, typeof(MovCommand))]
        [TestCase(0x04, typeof(MovcCommand))]
        [TestCase(0x05, typeof(LslCommand))]
        [TestCase(0x06, typeof(LsrCommand))]
        [TestCase(0x07, typeof(JmpCommand))]
        [TestCase(0x0A, typeof(JfeCommand))]
        [TestCase(0x0B, typeof(RetCommand))]
        [TestCase(0x0C, typeof(AddCommand))]
        [TestCase(0x0D, typeof(SubCommand))]
        [TestCase(0x0E, typeof(XorCommand))]
        [TestCase(0x0F, typeof(OrCommand))]
        [TestCase(0x10, typeof(InCommand))]
        [TestCase(0x11, typeof(OutCommand))]
	    public void Resolve_Commands_Correctly(byte byteCode, Type commandType)
	    {
            // assert
	        _cpu.Commands[byteCode].Should().BeOfType(commandType);
	    }
	}
}