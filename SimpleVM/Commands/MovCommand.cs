namespace SimpleVM.Commands
{
    public class MovCommand : DoubleParamCommand
    {
        public MovCommand(ICpu cpu) : base(cpu)
        {
        }

        protected override void OnExecute(byte parameter1, byte parameter2)
        {
            Cpu.Registers[parameter1] = Cpu.Registers[parameter2];
        }
    }
}