namespace SimpleVM.Commands
{
    public class InCommand : DoubleParamCommand
    {
        public InCommand(ICpu cpu) : base(cpu)
        {
        }

        protected override void OnExecute(byte parameter1, byte parameter2)
        {
            var data = Cpu.In.Read();
            if (!data.HasValue)
            {
                Cpu.Flags |= 0x01;
                return;
            }
            Cpu.Registers[parameter1] = data.Value;
        }
    }
}