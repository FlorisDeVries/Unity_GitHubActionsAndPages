using _Common.Math;
using GameManagement.Resources;
using UnityEngine;
using UnityEngine.InputSystem;
using UserInput.Resources;

namespace GameManagement
{
    public class MouseUpdates: MonoBehaviour
    {
        [SerializeField] private LayerMask _interactionLayers;
        
        private MouseData _mouseData;
        private GameManager _gameManager;
        private Vector2 _screenPos;

        private void OnEnable()
        {
            _mouseData = MouseData.Instance;
            _gameManager = GameManager.Instance;
        }

        private void FixedUpdate()
        {
            if (!_gameManager.MainCamera)
                return;

            _screenPos = Mouse.current.position.ReadValue();
            var worldPosition = _gameManager.MainCamera
                .ScreenToWorldPoint(_screenPos);

            worldPosition.z = 0;

            transform.position = worldPosition;
            _mouseData.SetPosition(worldPosition);
            _mouseData.SetMouseScreenPosition(_screenPos);
            _mouseData.SetCurrentlyHovering(MouseMath.GameObjectUnderMouse(_gameManager.MainCamera, _screenPos, 10000, _interactionLayers));
        }
        
    }
}