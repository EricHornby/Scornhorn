using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainPortrait : MonoBehaviour {

    public static MainPortrait instance;
    public Image image;

    public Sprite[] tippyFaces;
    public Sprite[] mallowFaces;
    public Sprite[] ribbonFaces;
    /*
    NEUTRAL = 0
    SMILE = 1
    SHOCKED = 2
    ANGRY = 3
    SLY = 4
    UNNERVED = 5
    */

    public void Neutral(string characterName)
    {
        if (characterName == "T")
        {
            image.sprite = tippyFaces[0];
        }
        if (characterName == "T")
        {
            image.sprite = mallowFaces[0];
        }
        if (characterName == "")
        {
            image.sprite = ribbonFaces[0];
        }
    }

    public void Smile(string characterName)
    {
        if (characterName == "T")
        {
            image.sprite = tippyFaces[1];
        }
        if (characterName == "T")
        {
            image.sprite = mallowFaces[1];
        }
        if (characterName == "")
        {
            image.sprite = ribbonFaces[1];
        }
    }

    public void Shocked(string characterName)
    {
        if (characterName == "T")
        {
            image.sprite = tippyFaces[2];
        }
        if (characterName == "T")
        {
            image.sprite = mallowFaces[2];
        }
        if (characterName == "")
        {
            image.sprite = ribbonFaces[2];
        }
    }

    public void Angry(string characterName)
    {
        if (characterName == "T")
        {
            image.sprite = tippyFaces[3];
        }
        if (characterName == "T")
        {
            image.sprite = mallowFaces[3];
        }
        if (characterName == "")
        {
            image.sprite = ribbonFaces[3];
        }
    }

    public void Sly(string characterName)
    {
        if (characterName == "T")
        {
            image.sprite = tippyFaces[4];
        }
        if (characterName == "T")
        {
            image.sprite = mallowFaces[4];
        }
        if (characterName == "")
        {
            image.sprite = ribbonFaces[4];
        }
    }

    public void Unnerved(string characterName)
    {
        if (characterName == "T")
        {
            image.sprite = tippyFaces[5];
        }
        if (characterName == "T")
        {
            image.sprite = mallowFaces[5];
        }
        if (characterName == "")
        {
            image.sprite = ribbonFaces[5];
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
