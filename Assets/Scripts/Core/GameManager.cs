using SecondDinner.Navigation;
using UnityEngine;

/// <summary>
/// The entry point for the game
/// </summary>
public class GameManager : MonoBehaviour
{
    private void Start()
    {
        NavigationManager.LoadStartingScene();
    }
}