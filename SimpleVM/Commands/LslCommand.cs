namespace SimpleVM.Commands
{
    public class LslCommand : DoubleParamCommand
    {
        public LslCommand(ICpu cpu) : base(cpu)
        {
        }

	    protected override void OnExecute(byte parameter1, byte parameter2)
	    {
			Cpu.Registers[parameter1] = (byte)(Cpu.Registers[parameter1] << 1);
	    }
    }
}