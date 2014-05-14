namespace SimpleVM.Commands
{
	public class IncCommand : DoubleParamCommand
	{
		public IncCommand(ICpu cpu)
			: base(cpu)
		{
		}


		protected override void OnExecute(byte parameter1, byte parameter2)
		{
			Cpu.Registers[parameter1]++;
		}
	}
}