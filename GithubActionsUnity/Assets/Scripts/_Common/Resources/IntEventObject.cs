using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace _Common.Resources
{
    [CreateAssetMenu(fileName = "IntEventObject", menuName = "Project/Events/IntEventObject")]
    public class IntEventObject : ScriptableObject
    {
        [SerializeField] private UnityEvent<int> _event = new();
        
        public void RegisterListener(UnityAction<int> listener)
        {
            _event.AddListener(listener);
        }
        
        public void UnregisterListener(UnityAction<int> listener)
        {
            _event.RemoveListener(listener);
        }

        public void RaiseEvent(int value)
        {
            _event.Invoke(value);
        }
    }
}