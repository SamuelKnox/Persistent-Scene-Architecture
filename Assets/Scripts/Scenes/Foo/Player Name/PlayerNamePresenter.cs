using SecondDinner.Data;
using UnityEngine;

namespace SecondDinner.Foo
{
    /// <summary>
    /// The presenter used to set/save the player's name
    /// </summary>
    [RequireComponent(typeof(PlayerNameView))]
    public class PlayerNamePresenter : MonoBehaviour
    {
        private PlayerNameView playerNameView;

        private void Awake()
        {
            playerNameView = GetComponent<PlayerNameView>();
        }

        private void OnEnable()
        {
            playerNameView.OnPlayerNameChanged += SetPlayerName;
        }

        private void Start()
        {
            InitializePlayerName();
        }

        private void OnDisable()
        {
            playerNameView.OnPlayerNameChanged -= SetPlayerName;
        }

        private void InitializePlayerName()
        {
            if (DataManager.Exists(DataKeys.PlayerName))
            {
                string playerName = DataManager.Load<string>(DataKeys.PlayerName);
                playerNameView.SetPlayerName(playerName);
            }
        }

        private void SetPlayerName(string playerName)
        {
            DataManager.Save(DataKeys.PlayerName, playerName);
        }
    }
}