using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainPortrait : MonoBehaviour {

    public static MainPortrait instance;
    public Image image;

    public Sprite[] tippyFaces;

    public void Neutral(string characterName)
    {
        if (characterName == "T")
        {
            image.sprite = tippyFaces[0];
        }
    }

    public void Smile(string characterName)
    {
        if (characterName == "T")
        {
            image.sprite = tippyFaces[1];
        }
    }

    public void Shocked(string characterName)
    {
        if (characterName == "T")
        {
            image.sprite = tippyFaces[2];
        }
    }

    public void Angry(string characterName)
    {
        if (characterName == "T")
        {
            image.sprite = tippyFaces[3];
        }
    }

    public void Sly(string characterName)
    {
        if (characterName == "T")
        {
            image.sprite = tippyFaces[4];
        }
    }

    public void ChangePortrait(string characterName, string emotion, string effect)
    {
        Debug.Log("recieving Portrait Command: " + characterName + " " + emotion + " " + effect);

        if (emotion == "")
        {
            Smile(characterName);
        }
        if (emotion == "Angry")
        {
            Angry(characterName);
        }
        if (emotion == "Shocked")
        {
            Shocked(characterName);
        }
        if (emotion == "Sly")
        {
            Sly(characterName);
        }
    }

    void Awake () { instance = this; }

	// Use this for initialization
	void Start () {
        image = this.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
