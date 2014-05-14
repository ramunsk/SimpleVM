using System.Collections.Generic;
using SimpleVM.Commands;

namespace SimpleVM
{
	public interface ICpu
	{
		byte[] Registers { get; }
		byte InstructionRegister { get; set; }
		byte Flags { get; set; }
		IInput In { get; }
		IOutput Out { get; }
		void Tick();
	}

	public class Cpu : ICpu
	{
		private readonly IMemory _memory;

		public Cpu(IMemory memory, IInput input, IOutput output)
		{
			_memory = memory;
			In = input;
			Out = output;
			Registers = new byte[16];

			Commands = new Dictionary<byte, Command>
            {
                {0x01, new IncCommand(this)},
                {0x02, new DecCommand(this)},
                {0x03, new MovCommand(this)},
                {0x04, new MovcCommand(this)},
                {0x05, new LslCommand(this)},
                {0x06, new LsrCommand(this)},
                {0x07, new JmpCommand(this)},
                {0x0A, new JfeCommand(this)},
                {0x0B, new RetCommand(this)},
                {0x0C, new AddCommand(this)},
                {0x0D, new SubCommand(this)},
                {0x0E, new XorCommand(this)},
                {0x0F, new OrCommand(this)},
                {0x10, new InCommand(this)},
                {0x11, new OutCommand(this)}
            };
		}

		public byte[] Registers { get; private set; }
		public byte InstructionRegister { get; set; }

		/// <remarks>
		/// Bit 1 - End of file
		/// Bit 2 - RET
		/// Bit 3 - Unknown command
		/// </remarks>
		public byte Flags { get; set; }

		public IInput In { get; private set; }

		public IOutput Out { get; private set; }

		public void Tick()
		{
			var instructonByte = _memory.Read(InstructionRegister);
			var parameterByte = _memory.Read((byte)(InstructionRegister + 1));

			if (!Commands.ContainsKey(instructonByte))
			{
				Flags |= (2 | 4);
				return;
			}

			var command = Commands[instructonByte];
			command.Execute(parameterByte);
		}

		public IDictionary<byte, Command> Commands { get; private set; }

	}
}