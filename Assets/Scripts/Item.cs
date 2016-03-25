using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {

    public Texture2D cursor;

    void Awake()
    {
    }

    public string GetName()
    {
        return gameObject.name;
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
