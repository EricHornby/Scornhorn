using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Interactable : MonoBehaviour, IPointerClickHandler
{
    public Interaction[] lookies;
    public Interaction[] insults;
    public Interaction[] usies;
    public Interaction[] gimmies;
    public Interaction[] itemInteractions;
    public Interaction[] moves;

    public bool isItem;
    TextBoxManager theTextBox;    
    Item item;

    public string[] switchExistenceREQ;
    public string[] switchExistenceFORBID;

    SpriteRenderer sprite;
    Collider2D coll;

    public bool available;


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
        else if (GameMaster.instance.actionState == GameMaster.ActionState.Item)
        {
            GameMaster.SetCursorDefault();
            if (!theTextBox.isActive || (theTextBox.isActive && theTextBox.itemMode))
            {
                ItemUsedOn();
            }
        }
        else if (GameMaster.instance.actionState == GameMaster.ActionState.Move)
        {
            if (!theTextBox.isActive || (theTextBox.isActive && theTextBox.itemMode))
            {
                Move();
            }
        }

    }

    void PerformInteractionFromPool(Interaction[] interactionSet)
    {
        for(int x = interactionSet.Length; x >= 0; x--)
        {
            if (interactionSet[x].GetInteractionValidity())
            {
                interactionSet[x].PerformInteraction();
                break;
            }
        }
    }

    void ItemUsedOn()
    {
        PerformInteractionFromPool(itemInteractions);
    }

    void Looky()
    {
        PerformInteractionFromPool(lookies);
    }

    void Gimme()
    {
        Debug.Log("gimme!");
        PerformInteractionFromPool(gimmies);
    }

    void Insult()
    {
        Debug.Log("insult!");
        PerformInteractionFromPool(insults);

    }

    void Use()
    {
        Debug.Log("use!");
        if (!isItem)
        {
            PerformInteractionFromPool(usies);
        }
        else
        {
            RegisterItemAsUse();
            Cursor.SetCursor(item.cursor, Vector2.zero, CursorMode.Auto);
            theTextBox.StartDisableTextBox();
        }
    }

    void Move()
    {
        Debug.Log("move!");
        PerformInteractionFromPool(moves);
    }

    void RegisterItemAsUse()
    {
        GameMaster.instance.actionState = GameMaster.ActionState.Item;
        GameMaster.instance.itemUse = item.name;
    }


    void Awake()
    {
        available = true;
       
        coll = GetComponent<Collider2D>();
        sprite = GetComponent<SpriteRenderer>();
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

        if (!isItem)
        {
            CheckExistenceValidity();
        }
    }

     public Item GetItem()
     {
           return item;
     }

     void Update()
     {
        if (!isItem)
        {
            CheckExistenceValidity();
        }
    }

    void CheckExistenceValidity()
    {
        bool canExist = true;
        foreach (string switchReq in switchExistenceREQ)
        {
            if (!GameMaster.GetSwitch(switchReq))
            {
                canExist = false;
            }
        }

        foreach (string switchForbid in switchExistenceFORBID)
        {
            if (GameMaster.GetSwitch(switchForbid))
            {
                canExist = false;
            }
        }

        if (canExist && !available)
        {
            sprite.enabled = true;
            coll.enabled = true;
            available = true;
        }
        else if (!canExist && available)
        {
            sprite.enabled = false;
            coll.enabled = false;
            available = false;
        }
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
