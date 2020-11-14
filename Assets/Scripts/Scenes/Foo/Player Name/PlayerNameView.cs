using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace SecondDinner.Foo
{
    /// <summary>
    /// Foo's view used to take the player name input
    /// </summary>
    public class PlayerNameView : MonoBehaviour
    {
        [Tooltip("Input field used to change the player name")]
        [SerializeField]
        private TMP_InputField playerNameInput;

        /// <summary>
        /// Called when the user want's to change the player name
        /// </summary>
        public UnityAction<string> OnPlayerNameChanged;

        private void OnEnable()
        {
            playerNameInput.onEndEdit.AddListener(ChangePlayerName);
        }

        private void OnDisable()
        {
            playerNameInput.onEndEdit.RemoveListener(ChangePlayerName);
        }

        public void SetPlayerName(string playerName)
        {
            playerNameInput.text = playerName;
        }

        private void ChangePlayerName(string playerName)
        {
            OnPlayerNameChanged?.Invoke(playerName);
        }
    }
}