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
    }

    public void AddQuest() {
        QuestGiver myScript = (QuestGiver)target;
        myScript.AddNewQuest();
    }
}