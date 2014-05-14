namespace SimpleVM
{
    public interface IMemory
    {
        byte Read(byte address);
        void Load(byte[] data);
    }

    public class Memory : IMemory
    {
        private readonly byte[] _memory;

        public Memory()
        {
            _memory = new byte[256];
        }

        public byte Read(byte address)
        {
            return _memory[address];
        }

        public void Load(byte[] data)
        {
            data.CopyTo(_memory, 0);
        }
    }
}