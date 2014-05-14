namespace SimpleVM.Commands
{
	public abstract class SingleParamCommand : Command
	{
		protected SingleParamCommand(ICpu cpu)
			: base(cpu)
		{
		}
	}
}