namespace SimpleVM
{
    public interface IInput
    {
        byte? Read();
    }

    public class Input : IInput
    {
        private readonly byte[] _bytes;
        private int _position;

        public Input(byte[] bytes)
        {
            _bytes = bytes;
            _position = 0;
        }

        public byte? Read()
        {
            if (_position >= _bytes.Length)
            {
                return null;
            }
            var b = _bytes[_position];
            _position++;
            return b;
        }
    }
}