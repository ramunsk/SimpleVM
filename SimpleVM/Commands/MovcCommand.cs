namespace SimpleVM.Commands
{
    public class MovcCommand : SingleParamCommand
    {
        public MovcCommand(ICpu cpu) : base(cpu)
        {
        }

        protected override void OnExecute(byte parameter)
        {
            Cpu.Registers[0] = parameter;
        }
    }
}