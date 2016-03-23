using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class ActivateTextAtLine : MonoBehaviour, IPointerClickHandler {

    public TextAsset[] lookyTexts;
    public int startLine;
    public int endLine;
    public int lookyClicks;
    public TextBoxManager theTextBox;

    public bool isItem;
    Item item;

    Interactable inter;
    

    public void OnPointerClick (PointerEventData eventData)
    {
        if (GameMaster.instance.actionState == GameMaster.ActionState.Looky)
        {
            Looky();
        }
        else if (GameMaster.instance.actionState == GameMaster.ActionState.Gimme)
        {
            Gimme();
        }
        else if (GameMaster.instance.actionState == GameMaster.ActionState.Insult)
        {
            Insult();
        }
        else if (GameMaster.instance.actionState == GameMaster.ActionState.Use)
        {
            Use();
        }
    }

    void Looky() {
        Debug.Log("Looky!");
        if (!theTextBox.isActive || (theTextBox.isActive && theTextBox.itemMode))
        {
            theTextBox.DisableTextBox();
            theTextBox.EnableTextBox();
            theTextBox.ReloadScript(lookyTexts[lookyClicks]);
            lookyClicks++;
        }

        if (lookyClicks >= lookyTexts.Length)
            lookyClicks = 0;
    }

    void Gimme()
    {
        Debug.Log("gimme!");
    }

    void Insult()
    {
        Debug.Log("insult!");

    }

    void Use()
    {
        Debug.Log("use!");
 
    }


    public void OnMouseUp()
    {
        /*
        if (GameMaster.instance.actionState == GameMaster.ActionState.Looky)
        {
            LookyText();
        }
        else if (GameMaster.instance.actionState == GameMaster.ActionState.Gimme)
        {
            GimmeText();
        }
        else if (GameMaster.instance.actionState == GameMaster.ActionState.Insult)
        {
            InsultText();
        }
        else if (GameMaster.instance.actionState == GameMaster.ActionState.Use)
        {
            UseTexts();
        }
        */
    }

    void Start() {
        theTextBox = TextBoxManager.instance;

        item = GetComponent<Item>();
        if (item == null)
        {
            isItem = false;
        }
        else
        {
            isItem = true;
        }

        
    }

    public Item GetItem()
    {
        return item;
    }

    void Update() {

    }

    /*  
    void OnTriggerEnter2D(Collider2D other)
    { if (other.name == "Player")
        { theTextBox.ReloadScript(theText);
            theTextBox.currentLine = startLine;
            theTextBox.endAtLine = endLine;

        }
    }
    */
}
