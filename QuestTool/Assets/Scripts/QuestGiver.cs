using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour {

    public GameObject questMarker;
    public Vector3 questMarkerPos;
    public Color questMarkerColour;
    private GameObject questMarkerRef;

    [System.Serializable]
    public class Quest {
        public string name;
        public string dialogue;
        public Quest() {
            name = "New Quest";
            dialogue = "";
        }
        public void SetName(string _name) {
            name = _name;
        }
        public void SetDialogue(string _dialogue) {
            name = _dialogue;
        }
    }

    [SerializeField]
    public List<Quest> quests = new List<Quest>();


    void OnApplicationQuit() {
        quests.Clear();
    }

    public void AddMarker() {
		if(questMarkerRef == null) {
			questMarkerRef = GameObject.Instantiate(questMarker, transform);
		}
        questMarkerRef.transform.localPosition = questMarkerPos;
        questMarkerRef.GetComponent<SpriteRenderer>().color = questMarkerColour;
    }

    public void AddNewQuest() {
        Quest tempQuest = new Quest();
        quests.Add(tempQuest);
    }

    public void ClearAllQuests() {
        quests.Clear();
    }
}
