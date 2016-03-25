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

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
