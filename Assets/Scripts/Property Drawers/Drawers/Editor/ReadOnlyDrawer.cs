using UnityEditor;
using UnityEngine;

namespace SecondDinner.Common
{
    /// <summary>
    /// Read Only Drawer Class
    /// </summary>
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        /// <summary>
        /// Gets the height of the property drawer
        /// </summary>
        /// <param name="property">The property</param>
        /// <param name="label">Label for the property</param>
        /// <returns>The property height</returns>
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        /// <summary>
        /// Draws the property drawer
        /// </summary>
        /// <param name="position">Position of the property drawer</param>
        /// <param name="property">The property</param>
        /// <param name="label">Label for the property</param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label, true);
            GUI.enabled = true;
        }
    }
}