using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

[System.Serializable]
public class Interaction
{
    //Requirements
    public string itemCause; // Only used if ProcCondition = Item! empty otherwise

    public string[] switchREQUIRED;
    public string[] switchFORBIDDEN;

    public string[] itemsREQUIRED;
    public string[] itemsFORBIDDEN;

    public string[] switchON;
    public string[] switchOFF;
    public string[] itemGIVE;
    public string[] itemTAKE;
    //TODO: SFX Play? Animation or Screen effect Proc? Form Change for Curios? Use -> Activate "Use On Something Else" type event?

    public TextAsset[] texts;
    public bool cycleRepeat = true; //if CycleRepeat is true, cycling to the end of the texts will reset it. Otherwise it will stall forever at the end one.
    int cycles;

    public bool oneOff; //a "cheat switch", adds a unique named switchA to "switchON" and also adds its to "switchFORBIDDEN", essentially declaring that this interaction can only occur once.
    bool oneOffCompleted;

    public bool GetInteractionValidity()
    {

        if (itemCause != "")
        {
            if (itemCause != GameMaster.instance.itemUse || GameMaster.instance.actionState != GameMaster.ActionState.Item)
            {
                return false;
            }
        }
        
        if (oneOffCompleted)
        {
            return false;
        }    

        foreach (string switchReq in switchREQUIRED)
        {
            if (!GameMaster.GetSwitch(switchReq))
            {
                return false;
            }
        }

        foreach (string switchForbid in switchFORBIDDEN)
        {
            if (GameMaster.GetSwitch(switchForbid))
            {
                return false;
            }
        }

        foreach (string itemReq in itemsREQUIRED)
        {
            if (!Inventory.instance.ContainsItem(itemReq))
            {
                return false;
            }
        }

        foreach (string itemForbid in itemsFORBIDDEN)
        {
            if (Inventory.instance.ContainsItem(itemForbid))
            {
                return false;
            }
        }

        return true;
    }

    public void PerformInteraction()
    {
        
        foreach(string s in switchON)
        {
            GameMaster.SetSwitch(s, true);
        }
        foreach (string s in switchOFF)
        {
            GameMaster.SetSwitch(s, false);
        }
        foreach (string s in itemGIVE)
        {
            Inventory.instance.AddItem(s);
        }
        foreach (string s in itemTAKE)
        {
            Inventory.instance.RemoveItem(s);
        }

        if (oneOff)
        {
            oneOffCompleted = true;
        }

        PrintText();
    }

    public void PrintText()
    {
        TextBoxManager theTextBox = TextBoxManager.instance;

        theTextBox.DisableTextBox();
        theTextBox.EnableTextBox();
        theTextBox.ReloadScript(texts[cycles]);
        cycles++;

        if (cycles >= texts.Length)
        {
            if (cycleRepeat)
            {
                cycles = 0;
            }
            else
            {
                cycles = texts.Length - 1;
            }
        }
           
    }

}

