using _Common.Unity;
using GameManagement.Resources;
using UnityEngine;
using UserInput.Resources;

namespace GameManagement
{
    public class SceneInitialization : MonoBehaviour
    {
        [SerializeField]
        private int _sceneInitializationFrames = 3;

        private void OnEnable()
        {
            var mainCamera = Camera.main;

            StartCoroutine(CoroutineHelper.DelayFixedFrames(
                () =>
                {
                    GameManager.Instance.ChangeState(GameState.Playing);
                    GameManager.Instance.SetMainCamera(mainCamera);
                }, _sceneInitializationFrames)
            );
            
            GameplayInputActions.Instance.SetActive(true);
            GameplayInputActions.Instance.PauseGameAction.OnActivated += SetPause;
        }

        private void OnDisable()
        {
            GameManager.Instance.ChangeState(GameState.Loading);
            GameplayInputActions.Instance.PauseGameAction.OnActivated -= SetPause;
        }

        private void SetPause()
        {
            GameManager.Instance.TogglePause();
        }
    }
}