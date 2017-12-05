using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour {

    [Header("Quest Marker")]
    [Tooltip("Marker Sprite")]
    public GameObject questMarker;
    [Tooltip("Local Postition of Marker")]
    public Vector3 questMarkerPos;
    [Tooltip("Colour of Marker")]
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
    [HideInInspector]
    public List<Quest> quests = new List<Quest>();

    void Awake() {
        Debug.Log(quests.Count);
    }

    void OnApplicationQuit() {
        quests.Clear();
    }

    public void AddMarker() {
        questMarkerRef = GameObject.Instantiate(questMarker, transform);
        questMarkerRef.transform.localPosition = questMarkerPos;
        questMarkerRef.GetComponent<SpriteRenderer>().color = questMarkerColour;
    }

    public void AddNewQuest() {
        Quest tempQuest = new Quest();
        quests.Add(tempQuest);
        Debug.Log(quests.Count);
    }

    public void ClearAllQuests() {
        quests.Clear();
        Debug.Log(quests.Count);
    }
}
