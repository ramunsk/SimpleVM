using System;
using NSubstitute;
using NUnit.Framework;
using SimpleVM.Commands;

namespace SimpleVM.Tests.Commands
{
    [TestFixture]
    [Category("Commands")]
    public abstract class CommandTest<TCommand>
    {
        protected Command Command;
        protected ICpu Cpu;
        protected byte[] Registers;
        protected IInput In;

        [SetUp]
        public void Setup()
        {
            Registers = new byte[16];
            Cpu = Substitute.For<ICpu>();
            Cpu.Registers.Returns(Registers);
            In = Substitute.For<IInput>();
            Cpu.In.Returns(In);
            Command = (Command)Activator.CreateInstance(typeof (TCommand), Cpu);
        }

        [TearDown]
        public void TearDown()
        {
            Registers = null;
            In = null;
            Cpu = null;
            Command = null;
        }
    }
}