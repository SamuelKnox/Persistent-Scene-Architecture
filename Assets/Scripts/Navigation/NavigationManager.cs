using SecondDinner.Common;
using SecondDinner.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SecondDinner.Navigation
{
    /// <summary>
    /// The manager used to navigate across the game
    /// </summary>
    public class NavigationManager : MonoBehaviourSingleton<NavigationManager>
    {
        [Tooltip("Default scene to start at if none are saved")]
        [SerializeField]
        private string defaultScene = "Foo";

        [Tooltip("The single scene that is currently loaded")]
        [SerializeField]
        [ReadOnly]
        private string currentScene;

        /// <summary>
        /// Loads the initial scene to start the game.  Determined by the last scene open, or the default if run for the first time
        /// </summary>
        public static void LoadStartingScene()
        {
            if (DataManager.Exists(DataKeys.Scene))
            {
                string sceneName = DataManager.Load<string>(DataKeys.Scene);
                LoadScene(sceneName);
            }
            else
            {
                LoadScene(Instance.defaultScene);
            }
        }

        /// <summary>
        /// Loads a scene
        /// </summary>
        /// <param name="sceneName">Name of the scene to load</param>
        /// <returns>Async operation indicating when the scene has completed loading</returns>
        public static AsyncOperation LoadScene(string sceneName)
        {
            if (!string.IsNullOrEmpty(Instance.currentScene))
            {
                SceneManager.UnloadSceneAsync(Instance.currentScene);
            }
            var asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            Instance.currentScene = sceneName;
            DataManager.Save(DataKeys.Scene, Instance.currentScene);
            return asyncOperation;
        }
    }
}