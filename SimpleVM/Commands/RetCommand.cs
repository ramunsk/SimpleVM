namespace SimpleVM.Commands
{
	public class RetCommand : SingleParamCommand
	{
		public RetCommand(ICpu cpu) : base(cpu)
		{
		}

		protected override void OnExecute(byte parameter)
		{
			Cpu.Flags |= 0x02;
		}

		protected override void OnAfterExecute(byte parameters)
		{
		}
	}
}