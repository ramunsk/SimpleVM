namespace SimpleVM.Commands
{
    public class JmpCommand : SingleParamCommand
    {
        public JmpCommand(ICpu cpu) : base(cpu)
        {
        }

        protected override void OnExecute(byte parameter)
        {
        }

	    protected override void OnAfterExecute(byte parameters)
	    {
			Cpu.InstructionRegister += parameters;
	    }
    }
}