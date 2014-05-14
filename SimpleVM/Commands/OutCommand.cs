namespace SimpleVM.Commands
{
    public class OutCommand : DoubleParamCommand
    {
        public OutCommand(ICpu cpu) : base(cpu)
        {
        }

        protected override void OnExecute(byte parameter1, byte parameter2)
        {
            Cpu.Out.Write(Cpu.Registers[parameter1]);
        }
    }
}