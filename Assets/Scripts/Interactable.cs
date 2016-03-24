using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IPointerClickHandler
{
    public Interaction[] lookies;
    public Interaction[] insults;

    public bool isItem;
    TextBoxManager theTextBox;    
    Item item;



    public void OnPointerClick(PointerEventData eventData)
    {
        if (GameMaster.instance.actionState == GameMaster.ActionState.Looky)
        {
            if (!theTextBox.isActive || (theTextBox.isActive && theTextBox.itemMode))
            {
                Looky();
            }
        }
        else if (GameMaster.instance.actionState == GameMaster.ActionState.Gimme)
        {
            if (!theTextBox.isActive || (theTextBox.isActive && theTextBox.itemMode))
            {
                Gimme();
            }
        }
        else if (GameMaster.instance.actionState == GameMaster.ActionState.Insult)
        {
            if (!theTextBox.isActive || (theTextBox.isActive && theTextBox.itemMode))
            {
                Insult();
            }
        }
        else if (GameMaster.instance.actionState == GameMaster.ActionState.Use)
        {
            if (!theTextBox.isActive || (theTextBox.isActive && theTextBox.itemMode))
            {
                Use();
            }
        }
    }

    void PerformInteractionFromPool(Interaction[] interactionSet)
    {
        for(int x = 0; x < interactionSet.Length; x++)
        {
            if (interactionSet[x].GetInteractionValidity())
            {
                interactionSet[x].PerformInteraction();
                break;
            }
        }
    }

    void Looky()
    {
        PerformInteractionFromPool(lookies);
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


    void Start()
        {
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

        void Update()
        {

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
