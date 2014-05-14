namespace SimpleVM.Commands
{
	public class DecCommand : DoubleParamCommand
	{
		public DecCommand(ICpu cpu) : base(cpu)
		{
		}

		protected override void OnExecute(byte parameter1, byte parameter2)
		{
			Cpu.Registers[parameter1]--;
		}
	}
}