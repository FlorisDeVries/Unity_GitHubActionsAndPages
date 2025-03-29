using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace _Common.Unity.Resources
{
    [CreateAssetMenu(fileName = "Scene", menuName = "Project/GameManagement/Unity Scene")]
    public class UnityScene : ScriptableObject
    {
        [SerializeField]
        private string _name;

        public virtual string Name => _name;

        public void LoadScene()
        {
            SceneManager.LoadScene(Name);
        }

        public async Task LoadSceneAsync()
        {
            await LoadSceneAsync(Name);
        }

        private Task LoadSceneAsync(string sceneName)
        {
            var tcs = new TaskCompletionSource<bool>();
            var asyncOp = SceneManager.LoadSceneAsync(sceneName);

            asyncOp.completed += (op) => { tcs.SetResult(true); };

            return tcs.Task;
        }
    }
}