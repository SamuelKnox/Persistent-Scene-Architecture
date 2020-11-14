using SecondDinner.Navigation;
using UnityEngine;

namespace SecondDinner.Foo
{
    /// <summary>
    /// Foo's controller for navigation
    /// </summary>
    [RequireComponent(typeof(NavigationView))]
    public class NavigationPresenter : MonoBehaviour
    {
        private NavigationView navigationView;

        private void Awake()
        {
            navigationView = GetComponent<NavigationView>();
        }

        private void OnEnable()
        {
            navigationView.OnNavigateToBar += NavigateToBar;
        }

        private void OnDisable()
        {
            navigationView.OnNavigateToBar -= NavigateToBar;
        }

        private void NavigateToBar()
        {
            NavigationManager.LoadScene(SceneNames.Bar);
        }
    }
}