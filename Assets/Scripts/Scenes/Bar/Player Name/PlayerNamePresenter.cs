using SecondDinner.Data;
using UnityEngine;

namespace SecondDinner.Bar
{
    /// <summary>
    /// The controller used to set the player name
    /// </summary>
    [RequireComponent(typeof(PlayerNameView))]
    public class PlayerNamePresenter : MonoBehaviour
    {
        [Tooltip("Default player name if none is set")]
        [SerializeField]
        private string defaultPlayerName;

        private PlayerNameView playerNameView;

        private void Awake()
        {
            playerNameView = GetComponent<PlayerNameView>();
        }

        private void Start()
        {
            InitializePlayerName();
        }

        private void InitializePlayerName()
        {
            if(DataManager.Exists(DataKeys.PlayerName))
            {
                string playerName = DataManager.Load<string>(DataKeys.PlayerName);
                playerNameView.SetPlayerName(playerName);
            }
            else
            {
                playerNameView.SetPlayerName(defaultPlayerName);
            }
        }
    }
}