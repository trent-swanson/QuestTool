using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(QuestGiver))]
public class QuestGiverEditor : Editor {


    public override void OnInspectorGUI() {
        DrawDefaultInspector();
        QuestGiver myScript = (QuestGiver)target;

        if(GUILayout.Button("Make Quest Marker")) {
            myScript.AddMarker();
        }

        GUILayout.Space(20);
        if (GUILayout.Button("Add New Quest", GUILayout.Height(50))) {
            AddQuest();
        }

        GUILayout.Space(20);
        if (GUILayout.Button("Clear All Quests", GUILayout.Height(30))) {
            myScript.ClearAllQuests();
        }
        //GUILayout.Label(myScript.quests[0].name);
    }

    public void AddQuest() {
        QuestGiver myScript = (QuestGiver)target;
        myScript.AddNewQuest();
        string tempName = EditorGUILayout.TextField("Quest Name");
        myScript.quests[0].SetName(tempName);
    }
}