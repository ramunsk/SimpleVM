namespace SimpleVM.Commands
{
    public class AddCommand : DoubleParamCommand
    {
        public AddCommand(ICpu cpu) : base(cpu)
        {
        }

        protected override void OnExecute(byte parameter1, byte parameter2)
        {
            Cpu.Registers[parameter1] += Cpu.Registers[parameter2];
        }
    }
}