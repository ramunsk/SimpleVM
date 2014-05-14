namespace SimpleVM.Commands
{
    public class OrCommand : DoubleParamCommand
    {
        public OrCommand(ICpu cpu) : base(cpu)
        {
        }

        protected override void OnExecute(byte parameter1, byte parameter2)
        {
            Cpu.Registers[parameter1] |= Cpu.Registers[parameter2];
        }
    }
}