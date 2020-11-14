#if UNITY_EDITOR
using SecondDinner.Data;
using UnityEditor;
using UnityEngine;

namespace SecondDinner.Tools
{
    /// <summary>
    /// Class to create tools specific to Second Dinner
    /// </summary>
    public class ToolsWindow : EditorWindow
    {
        /// <summary>
        /// Creates an option in the menu to open the tools window
        /// </summary>
        [MenuItem("Second Dinner/Tools")]
        static void Init()
        {
            var optionsWindow = GetWindow<ToolsWindow>("Tools");
            optionsWindow.Show();
        }

        private void OnGUI()
        {
            DisplayToolsGui();
        }

        private void DisplayToolsGui()
        {
            GUILayout.Label("Tools", EditorStyles.boldLabel);
            if (GUILayout.Button("Clear Data"))
            {
                DataManager.Clear();
                Debug.Log($"All local data has been deleted.");
            }
        }
    }
}
#endif