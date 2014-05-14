namespace SimpleVM.Commands
{
	public abstract class Command
	{
		protected Command(ICpu cpu)
		{
			Cpu = cpu;
		}

		protected ICpu Cpu { get; private set; }

		
		protected abstract void OnExecute(byte parameters);

		protected virtual void OnAfterExecute(byte parameters)
		{
			Cpu.InstructionRegister += 2;
		}

		public void Execute(byte parameters)
		{
			OnExecute(parameters);
			OnAfterExecute(parameters);
		}
	}
}