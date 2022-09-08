using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemController : MonoBehaviour
{
    string itemName;

    //public Button removeButton;

    public void removeItem(){
        Debug.Log("Remove called. itemName is: "+itemName);
        //OnItemFocusButtons.Instance.removeItemFromCart(itemName);
        string name = transform.gameObject.name;
        OnItemFocusButtons.Instance.removeItemFromCart(name);
        Destroy(gameObject);
    }

    public void AddItem(string name){
        itemName = name;
    }
}
