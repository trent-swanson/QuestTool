using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(QuestGiver))]
public class QuestGiverEditor : Editor {
	
	QuestGiver myScript;
	List<bool> showQuestInfo = new List<bool>();

	void OnEnable() {
		myScript = (QuestGiver)target;
	}

    public override void OnInspectorGUI() {
		GUIStyle scriptTitleStyle = new GUIStyle();
		scriptTitleStyle.fontSize = 20;
		scriptTitleStyle.alignment = TextAnchor.MiddleCenter;
		scriptTitleStyle.fontStyle = FontStyle.Bold;

		GUIStyle titleStyle = new GUIStyle ();
		titleStyle.fontSize = 14;
		titleStyle.alignment = TextAnchor.MiddleCenter;
		titleStyle.fontStyle = FontStyle.Bold;

		GUIStyle buttonSyle = new GUIStyle (GUI.skin.button);
		buttonSyle.fontSize = 11;
		buttonSyle.fontStyle = FontStyle.Bold;


		GUILayout.Space(10);
		GUILayout.Label ("Quest Giver", scriptTitleStyle);

		GUILayout.Space(20);
		GUILayout.Label ("Quest Marker", titleStyle);
		myScript.questMarker = (GameObject)EditorGUILayout.ObjectField ("Quest Marker", myScript.questMarker, typeof(GameObject), false);
		myScript.questMarkerPos = EditorGUILayout.Vector3Field ("Quest Marker Position", myScript.questMarkerPos);
		myScript.questMarkerColour = EditorGUILayout.ColorField ("Quest Marker Colour", myScript.questMarkerColour);

		if(GUILayout.Button("Update Quest Marker", buttonSyle, GUILayout.Height(30))) {
            myScript.AddMarker();
        }

		GUILayout.Space(30);
		GUILayout.Label ("Quests:  " + myScript.quests.Count, titleStyle);
		GUILayout.BeginHorizontal ();
		if (GUILayout.Button("Add New Quest", buttonSyle, GUILayout.Height(40))) {
            AddQuest();
        }
        GUILayout.Space(20);
		if (GUILayout.Button("Clear All Quests", buttonSyle, GUILayout.Height(40))) {
			ClearQuests();
        }
		GUILayout.EndHorizontal ();

		for (int i = 0; i < myScript.quests.Count; i++) {
			GUILayout.Space(5);
			GUILayout.BeginVertical ("box");
			GUILayout.Space(5);
			GUILayout.BeginHorizontal ();
			GUILayout.Space(15);
			showQuestInfo[i] = EditorGUILayout.Foldout (showQuestInfo[i], myScript.quests[i].name);
			if (GUILayout.Button("X", GUILayout.Width(25))) {
				RemoveQuest(i);
				return;
			}
			GUILayout.Space(15);
			GUILayout.EndHorizontal ();
			if(showQuestInfo[i]) {
				GUILayout.Space(5);
				myScript.quests[i].name = EditorGUILayout.TextField ("Quest Name", myScript.quests[i].name);
				GUILayout.Label("Quest Dialogue");
				myScript.quests[i].dialogue = EditorGUILayout.TextArea (myScript.quests[i].dialogue);
			}
			GUILayout.Space(5);
			GUILayout.EndVertical ();
		}
    }

    public void AddQuest() {
        myScript.AddNewQuest();
		showQuestInfo.Add (false);
    }

	public void RemoveQuest(int index) {
		myScript.quests.RemoveAt(index);
		showQuestInfo.RemoveAt (index);
	}

	public void ClearQuests() {
		myScript.ClearAllQuests();
		for (int i = 0; i < showQuestInfo.Count; i++) {
			showQuestInfo [i] = false;
		}
	}
}