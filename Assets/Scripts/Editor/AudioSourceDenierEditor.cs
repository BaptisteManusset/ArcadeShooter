using UnityEditor;
using UnityEngine;
namespace Editor {
	[CustomEditor(typeof(AudioSource))]
	public class AudioSourceDenierEditor : UnityEditor.Editor {


		//center editorstyle for the inspector

		public override void OnInspectorGUI() {
			GUIStyle centerStyle = EditorStyles.helpBox;
			centerStyle.alignment = TextAnchor.MiddleCenter;
			centerStyle.fontStyle = FontStyle.Bold;
			centerStyle.fontSize = 12;
			centerStyle.normal = new GUIStyleState() {textColor = new Color(0.89f, 0.21f, 0.14f)};
			centerStyle.border = new RectOffset(20, 20, 20, 20);


			GUILayout.Label("Don't use directly to play audio,\nuse EazySoundManager instead to play audio", centerStyle);
			GUILayout.Space(15);


			base.OnInspectorGUI();
		}
	}
}
