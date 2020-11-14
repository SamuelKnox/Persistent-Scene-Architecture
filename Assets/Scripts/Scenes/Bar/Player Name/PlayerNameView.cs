using TMPro;
using UnityEngine;

namespace SecondDinner.Bar
{
    /// <summary>
    /// The view used to show the player name
    /// </summary>
    public class PlayerNameView : MonoBehaviour
    {
        [Tooltip("Text used to display the player's name")]
        [SerializeField]
        private TextMeshProUGUI playerName;

        /// <summary>
        /// Sets the player name to be displayed
        /// </summary>
        /// <param name="playerName">The player name to display</param>
        public void SetPlayerName(string playerName)
        {
            this.playerName.text = playerName;
        }
    }
}