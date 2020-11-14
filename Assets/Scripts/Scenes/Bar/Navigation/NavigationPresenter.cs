using SecondDinner.Navigation;
using UnityEngine;

namespace SecondDinner.Bar
{
    /// <summary>
    /// Bar's controller for navigation
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
            navigationView.OnNavigateToFoo += NavigateToFoo;
        }

        private void OnDisable()
        {
            navigationView.OnNavigateToFoo -= NavigateToFoo;
        }

        private void NavigateToFoo()
        {
            NavigationManager.LoadScene(SceneNames.Foo);
        }
    }
}