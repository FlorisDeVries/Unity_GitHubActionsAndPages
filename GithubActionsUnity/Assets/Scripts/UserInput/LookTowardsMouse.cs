using UnityEngine;
using UserInput.Resources;

namespace UserInput
{
    public class LookTowardsMouse : MonoBehaviour
    {
        private MouseData _mouseData;

        private void OnEnable()
        {
            _mouseData = MouseData.Instance;
        }

        private void Update()
        {
            if (!_mouseData) return;

            var direction = transform.position - _mouseData.WorldPosition;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}