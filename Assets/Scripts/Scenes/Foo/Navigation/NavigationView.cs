using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SecondDinner.Foo
{
    /// <summary>
    /// Foo's view for navigation
    /// </summary>
    public class NavigationView : MonoBehaviour
    {
        [Tooltip("Button used to navigate to bar")]
        [SerializeField]
        private Button barButton;

        /// <summary>
        /// Called when the user wants to navigate to the bar scene
        /// </summary>
        public UnityAction OnNavigateToBar;

        private void OnEnable()
        {
            barButton.onClick.AddListener(NavigateToBar);
        }

        private void OnDisable()
        {
            barButton.onClick.RemoveListener(NavigateToBar);
        }

        private void NavigateToBar()
        {
            OnNavigateToBar?.Invoke();
        }
    }
}