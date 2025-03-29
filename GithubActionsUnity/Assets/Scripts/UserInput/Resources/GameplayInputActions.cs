using _Common.Actions;
using _Common.BaseClasses;
using UnityEngine;
using UnityEngine.InputSystem;
using UserInput.Generated;

namespace UserInput.Resources
{
    /// <summary>
    /// Input manager for the game
    /// Usage example: InputActions.Instance.PrimaryInputAction.OnValueChanged += OnPrimaryAction;
    /// </summary>
    [CreateAssetMenu(fileName = "GameplayInputActions", menuName = "Project/Input/GameplayInputActions")]
    public class GameplayInputActions : ASingletonResource<GameplayInputActions>, GameInput.IGameplayActions
    {
        protected override string ResourcePath => "Input/GameplayInputActions";
        
        [SerializeField]
        private GameInput _gameInput;

        private void OnEnable()
        {
            if (_gameInput != null) return;

            _gameInput = new GameInput();
            _gameInput.Gameplay.SetCallbacks(this);
        }

        private void OnDisable()
        {
            _gameInput.Gameplay.Disable();
        }

        public void SetActive(bool active)
        {
            if (active)
                _gameInput.Gameplay.Enable();
            else
                _gameInput.Gameplay.Disable();
        }

        public InputAction<Vector2> MovementAction { get; } = new();
        public void OnMovement(InputAction.CallbackContext context)
        {
            MovementAction.Value = context.ReadValue<Vector2>();
        }

        public BoolInputAction PrimaryInputAction { get; } = new();
        public void OnPrimaryAction(InputAction.CallbackContext context)
        {
            PrimaryInputAction.OnInputAction(context);
        }

        public BoolInputAction SecondaryInputAction { get; } = new();
        public void OnSecondaryAction(InputAction.CallbackContext context)
        {
            SecondaryInputAction.OnInputAction(context);
        }

        public BoolInputAction PauseGameAction { get; } = new();
        public void OnPauseGame(InputAction.CallbackContext context)
        {
            PauseGameAction.OnInputAction(context);
        }

        public InputAction<float> ZoomAction { get; } = new();
        public void OnZoom(InputAction.CallbackContext context)
        {
            ZoomAction.Value = context.ReadValue<float>();
        }
    }
}