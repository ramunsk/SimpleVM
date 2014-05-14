namespace SimpleVM.Commands
{
    public class JfeCommand : SingleParamCommand
    {
        public JfeCommand(ICpu cpu) : base(cpu)
        {
        }

        protected override void OnExecute(byte parameter)
        {
        }

	    protected override void OnAfterExecute(byte parameters)
	    {
			if ((Cpu.Flags & 0x01) == 0x01)
			{
				Cpu.InstructionRegister += parameters;
				return;
			}
			base.OnAfterExecute(parameters);
	    }
    }
}