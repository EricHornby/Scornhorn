using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameMaster : MonoBehaviour {

    public static GameMaster instance;

    public Dictionary<string, bool> switches;

    public enum ActionState
    {
        Looky, Insult, Use, Gimme, Move, Item
    }

    public string itemUse;

    public ActionState actionState;

    public Room activeRoom;
    public List<Room> rooms = new List<Room>();

    public GameObject roomsRoot;

    void Awake() {
        instance = this;
        switches = new Dictionary<string, bool>();
    }

    public static void SetCursorDefault()
    {
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto); 
    }

    public static bool GetSwitch(string key)
    {

        if (GameMaster.instance.switches.ContainsKey(key))
        {
            return GameMaster.instance.switches[key];
        }
        else
        {
            return false;
        }
    }

    public static void SetSwitch(string key, bool val)
    {
        if (GameMaster.instance.switches.ContainsKey(key))
        {
            GameMaster.instance.switches[key] = val;
        }
        else
        {
            GameMaster.instance.switches.Add(key, val);
        }
    }


    public void SetRoomTo(string roomName)
    {
        Room newRoom = null;

        foreach(Room r in rooms)
        {
            if (r.name == roomName)
            {
                newRoom = r;
            }
        }

        if (newRoom != null)
        {
            activeRoom.gameObject.SetActive(false);
            activeRoom.isActiveRoom = false;
            activeRoom = newRoom;
            activeRoom.gameObject.SetActive(true);
        }

        


    }

    // Use this for initialization
    void Start() {
        foreach (Room r in roomsRoot.GetComponentsInChildren<Room>(true) )
        {
            rooms.Add(r);
            if (r.isActiveRoom)
            {
                activeRoom = r;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
