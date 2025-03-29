using System;
using UnityEngine.InputSystem;

namespace _Common.Actions
{
    public class InputAction<T>
    {
        public event Action<T> OnValueChanged = delegate { };

        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                if (Equals(_value, value)) return;
                _value = value;
                OnValueChanged.Invoke(_value);
            }
        }
    }
    
    public class BoolInputAction : InputAction<bool>
    {
        public event Action OnActivated = delegate { };
        
        public void OnInputAction(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Value = true;
                OnActivated.Invoke();
            }
            else if (context.canceled)
            {
                Value = false;
            }
        }
    }
}