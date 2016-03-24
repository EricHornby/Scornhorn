using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

    public GameObject textBox;
    public Text theText;
    public string[] textLines;

    public int currentLine;
    int lastPrintedLine = -1;
    public int endAtLine;

    public bool isActive;

    public bool itemMode;

    public static TextBoxManager instance;

    public RectTransform itemRoot;

    public static string GetStrBetweenTags(string value, string startTag, string endTag)
    {
        if (value.Contains(startTag) && value.Contains(endTag))
        {
            int index = value.IndexOf(startTag) + startTag.Length;
            return value.Substring(index, value.IndexOf(endTag) - index);
        }
        else
            return null;
    }

    public static List<string> GetAllStrBetweenTags(string value, string startTag, string endTag)
    {
        List<string> output = new List<string>();
        while (value.Contains(startTag) && value.Contains(endTag))
        {
            int index = value.IndexOf(startTag) + startTag.Length;

            output.Add(value.Substring(index, value.IndexOf(endTag) - index));
            if (value.IndexOf(endTag) + 1 < value.Length - 1)
            {
                value = value.Substring(value.IndexOf(endTag) + 1);
            }
            else
            {
                value = "";
            }

        }
        return output;
    }

    void Awake ()
    {
        instance = this;
    }

	void Start () {

        itemRoot.gameObject.SetActive(false);

    }
	
	void Update () {

        if (currentLine > endAtLine)
        { currentLine = endAtLine; }

        if (!isActive)
        { return; }

        if (isActive && !itemMode)
        {
            if (lastPrintedLine != currentLine)
            {
                PrintLine(textLines[currentLine]);
                lastPrintedLine = currentLine;
            }
           

            if (Input.GetKeyDown(KeyCode.Return))
            { currentLine += 1; }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            { currentLine += 1; }

            if (currentLine > endAtLine)
            { StartDisableTextBox(); }
        }
        
	}


    public void OpenInventory()
    {
       
        if (!itemMode)
        {
            DisableTextBox();
            EnableTextBox();
            itemMode = true;
            itemRoot.gameObject.SetActive(true);
            theText.text = "";
        }
        else
        {
            StartDisableTextBox();
        }
       
    }

    public void PrintLine(string textLine)
    {
        List<string> tags = GetAllStrBetweenTags(textLine, "[", "]");
        
        while (tags.Count < 3)
        {
            tags.Add("");
        }

        MainPortrait.instance.ChangePortrait(tags[0], tags[1], tags[2]);

        textLine = textLine.Substring(textLine.LastIndexOf(']')+1);

        theText.text = textLine;
    }

    public void EnableTextBox()
    {
        textBox.SetActive(true);
        isActive = true;
    }

    public void PrintText()
    {
        theText.gameObject.SetActive(true);
    }

    public void HideText()
    {
        theText.gameObject.SetActive(false);
        
    }

    public void StartDisableTextBox()
    {
     
        Animator animText = textBox.GetComponent<Animator>();
        animText.SetTrigger("Close Window");        
    }

    public void DisableTextBox()
    {
        textBox.SetActive(false);
        isActive = false;
        MainPortrait.instance.Neutral("T");
        itemMode = false;
        itemRoot.gameObject.SetActive(false);
    }

    public void ReloadScript(TextAsset inputText)
    {
        currentLine = 0;
        lastPrintedLine = -1;
        Debug.Log(inputText);
        textLines = (inputText.text.Split('\n'));
        endAtLine = textLines.Length - 1;
        // endAtLine = 
    }
}
