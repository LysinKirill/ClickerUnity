using System;

namespace Core
{
    public class ObservableInt
    {
        private int _value;
        public Action<int> OnValueChanged;

        public ObservableInt(int value)
        {
            _value = value;
        }

        public int Value
        {
            get { return _value; }
            set
            {
                OnValueChanged?.Invoke(value);
                _value = value;
            }
        }
    }
}
