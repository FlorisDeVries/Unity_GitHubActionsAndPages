using UnityEngine;
using UserInput.Resources;

namespace Characters
{
    public class PlayerController : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private Vector2 _currentVelocity;
        private Vector2 _direction;

        [SerializeField]
        private float _acceleration = 10f;

        [SerializeField]
        private float _deceleration = 10f;

        [SerializeField]
        private float _maxSpeed = 5f;

        private void OnEnable()
        {
            _rigidbody = GetComponent<Rigidbody2D>();

            GameplayInputActions.Instance.MovementAction.OnValueChanged += OnMovement;
        }

        private void OnDisable()
        {
            GameplayInputActions.Instance.MovementAction.OnValueChanged -= OnMovement;
        }

        private void OnMovement(Vector2 direction)
        {
            _direction = direction.normalized;
        }

        private void FixedUpdate()
        {
            var targetVelocity = _direction * _maxSpeed;

            // Apply acceleration or deceleration
            _currentVelocity = _direction.magnitude > 0
                ? Vector2.MoveTowards(_currentVelocity, targetVelocity, _acceleration * Time.fixedDeltaTime)
                : Vector2.MoveTowards(_currentVelocity, Vector2.zero, _deceleration * Time.fixedDeltaTime);

            _rigidbody.linearVelocity = _currentVelocity;
        }
    }
}