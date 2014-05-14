namespace SimpleVM.Commands
{
	public abstract class DoubleParamCommand : Command
	{
		protected DoubleParamCommand(ICpu cpu)
			: base(cpu)
		{
		}

		protected abstract void OnExecute(byte parameter1, byte parameter2);

		protected override void OnExecute(byte parameters)
		{
		    var parameter1 = (byte) (parameters & 0x0F);
		    var parameter2 = (byte) (parameters >> 4);

		    OnExecute(parameter1, parameter2);
		}
	}
}