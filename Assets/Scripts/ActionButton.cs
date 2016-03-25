using UnityEngine;
using System.Collections;

public class ActionButton : MonoBehaviour {

    public GameMaster.ActionState selfState;

    public void selectButton() {

        GameMaster.SetCursorDefault();
        if (selfState == GameMaster.ActionState.Item)
        {
            TextBoxManager.instance.OpenInventory();
            GameMaster.instance.actionState = GameMaster.ActionState.Use;
        }
        else
        {
            GameMaster.instance.actionState = selfState;
        }
    }

    // Use this for initialization


    // Update is called once per frame
    void Update()
    {




    }
}
