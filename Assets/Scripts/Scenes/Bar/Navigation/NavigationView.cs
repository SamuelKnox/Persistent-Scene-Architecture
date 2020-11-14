using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SecondDinner.Bar
{
    /// <summary>
    /// Bar's view for navigation
    /// </summary>
    public class NavigationView : MonoBehaviour
    {
        [Tooltip("Button used to navigate to foo")]
        [SerializeField]
        private Button fooButton;

        /// <summary>
        /// Called when the user wants to navigate to the foo scene
        /// </summary>
        public UnityAction OnNavigateToFoo;

        private void OnEnable()
        {
            fooButton.onClick.AddListener(NavigateToFoo);
        }

        private void OnDisable()
        {
            fooButton.onClick.RemoveListener(NavigateToFoo);
        }

        private void NavigateToFoo()
        {
            OnNavigateToFoo?.Invoke();
        }
    }
}