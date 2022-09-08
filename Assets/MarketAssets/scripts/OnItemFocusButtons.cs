using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using System.Linq;

public class OnItemFocusButtons : MonoBehaviour
{
    public static OnItemFocusButtons Instance;
    //ShoppingCart
    Dictionary<string,int> cartItemList;
    [SerializeField] private Transform contentContainer; // ScrollView Content Prefab
    [SerializeField] private GameObject itemPrefab;  // Prefab of the model item to instantiate inside contentContainer

    public InventoryItemController[] InventoryItems;

    //Buttons to show when we focus one item 
    [SerializeField] GameObject[] onFocusButtonList;

    //List<GameObject> detectedItemsList = new List<GameObject>();

    Dictionary<int, GameObject> detectedItems = new Dictionary<int,GameObject>();

    //on taget found
    public void setFocusedItem(GameObject shopItem) {
        // //Only one image target must be active to show onfocus buttons
        // if(onFocusItem == null){
        //     //Set focused item
        //     onFocusItem = shopItem; 
        //     //Show buttons
        //     foreach (var button in onFocusButtonList){ 
        //         button.SetActive(true);
        //     }
        // }

       detectedItems.Add(shopItem.GetInstanceID(), shopItem);
    }


    //on target lost
    public void unsetFocusedItem(GameObject shopItem) {

        detectedItems.Remove(shopItem.GetInstanceID());

        // if (onFocusItem.GetInstanceID() == shopItem.GetInstanceID()) {
        //     onFocusItem = null;
        // }
    }


    //Action of buy button
    // public void buyItem() {
    //     //buy when only one item focused
    //     if(detectedItems.Count == 1){
    //         List<GameObject> focusedItemList = new List<GameObject>(detectedItems.Values);
    //         GameObject focusedItem = focusedItemList[0];
            
    //         if(cartItemList.ContainsKey(focusedItem.name)){
    //             cartItemList[focusedItem.name] = cartItemList[focusedItem.name]+1;

    //             GameObject itemToRemove = contentContainer.transform.Find(focusedItem.name).gameObject;
    //             Destroy(itemToRemove);

    //             //public static Object Instantiate(Object original, Transform parent);
    //             //var obj = (GameObject)Instantiate(itemPrefab, contentContainer.transform);
    //             GameObject itemUI = Instantiate(itemPrefab,contentContainer);
    //             itemUI.name = focusedItem.name;
    //             // itemUI.transform.Find("Text (TMP) NameItem").GetComponent<Text>().text = focusedItem.name;
    //             // itemUI.transform.Find("Text (TMP) CountItem").GetComponent<Text>().text = "x " +cartItemList[focusedItem.name].ToString();
    //             //itemUI.transform.SetParent(contentContainer);

    //             TextMeshProUGUI[] textsItemUI = itemUI.GetComponentsInChildren<TextMeshProUGUI>();
    //             textsItemUI[0].text = focusedItem.name;
    //             textsItemUI[1].text =  "x " + cartItemList[focusedItem.name].ToString();
    //             textsItemUI[2].text = "xxxxx";

    //         }else{
    //             cartItemList.Add(focusedItem.name, 1); 

    //             GameObject itemUI = Instantiate(itemPrefab,contentContainer);
    //             itemUI.name = focusedItem.name;
    //             TextMeshProUGUI[] textsItemUI = itemUI.GetComponentsInChildren<TextMeshProUGUI>();
    //             textsItemUI[0].text = focusedItem.name;
    //             textsItemUI[1].text =  "x " + cartItemList[focusedItem.name].ToString();
    //             textsItemUI[2].text = "xxxxx";
    //             //itemUI.SetActive(true);
    //         }
    //     }
    // }



    //Rotate Item
    public void toggleItemRotation(){
        List<GameObject> focusedItemList = new List<GameObject>(detectedItems.Values);
        GameObject focusedItem = focusedItemList[0];
        focusedItem.GetComponent<RotateItem>().ToggleItemRotation();
    }


    //Scale
    public void onPressExpand() {
        List<GameObject> focusedItemList = new List<GameObject>(detectedItems.Values);
        GameObject focusedItem = focusedItemList[0];
        focusedItem.GetComponent<ScaleItem>().onPressScaleUp();
    }
    public void onReleaseExpand() {
        List<GameObject> focusedItemList = new List<GameObject>(detectedItems.Values);
        GameObject focusedItem = focusedItemList[0];
        focusedItem.GetComponent<ScaleItem>().onReleaseScaleUp();
    }

    public void onPressContract() {
        List<GameObject> focusedItemList = new List<GameObject>(detectedItems.Values);
        GameObject focusedItem = focusedItemList[0];
        focusedItem.GetComponent<ScaleItem>().onPressScaleDown();
    }
    public void onReleaseContract() {
        List<GameObject> focusedItemList = new List<GameObject>(detectedItems.Values);
        GameObject focusedItem = focusedItemList[0];
        focusedItem.GetComponent<ScaleItem>().onReleaseScaleDown();
    }




    // Start is called before the first frame update
    void Start()
    {
        cartItemList = new Dictionary<string, int>();
    }

    // Update is called once per frame
    void Update() {
        
        //show onFocusButtonList buttons only if one item tracked
        if(detectedItems.Count == 1){
            foreach (var button in onFocusButtonList){
                button.SetActive(true);
            }
        } else {
            foreach (var button in onFocusButtonList) {
                button.SetActive(false);
            }
        }

        //onFocusButtonList actions
        if(detectedItems.Count == 1){
            
            List<GameObject> focusedItemList = new List<GameObject>(detectedItems.Values);
            GameObject focusedItem = focusedItemList[0];
            
            //rotate item (doesnt work)
            // if(rotationEnabled){
            //     Debug.Log("Rotation = true");
            //     Vector3 rotationToAdd = new Vector3(0, 1, 0);
                
            //     Debug.Log("Rotation: "+ focusedItem.transform.localEulerAngles);
            //     //focusedItem.transform.Rotate(rotationToAdd, rotationSpeed*Time.deltaTime);
                
            //     focusedItem.transform.localEulerAngles = focusedItem.transform.localEulerAngles + rotationToAdd * rotationSpeed*Time.deltaTime;
                
                
            //     //transform.Rotate(new Vector3(0, degreesPerSecond, 0) * Time.deltaTime);

            // }else{
            //     Debug.Log("Rotation = false");
            // }

        }

       
    }

    //update cart UI
    public void ListItems(){
        //reset UI state
        foreach (Transform item in contentContainer){
            Destroy(item.gameObject);
        }
        //create new UI state
        foreach(var item in cartItemList){
            string name = item.Key;
            int count = item.Value;
             GameObject itemUI = Instantiate(itemPrefab,contentContainer);
                itemUI.name = name;
                TextMeshProUGUI[] textsItemUI = itemUI.GetComponentsInChildren<TextMeshProUGUI>();
                textsItemUI[0].text = name;
                textsItemUI[1].text =  "x " + count.ToString();
        }
        setInventoryItems();
    }

    public void setInventoryItems(){ //IventoryManager
        InventoryItems = contentContainer.GetComponentsInChildren<InventoryItemController>();

    

        for (int i = 0; i < cartItemList.Count; i++)
        {
            Debug.Log("InventoryItem "+i+": "+InventoryItems[i]);
            string name = cartItemList.ElementAt(i).Key;
            Debug.Log("name: "+InventoryItems[i].name);
            InventoryItems[i].AddItem(InventoryItems[i].name);
        }
    }

    public void AddToCart(){
        if(detectedItems.Count == 1){
            List<GameObject> focusedItemList = new List<GameObject>(detectedItems.Values);
            GameObject focusedItem = focusedItemList[0];
            
            if(cartItemList.ContainsKey(focusedItem.name)){
                cartItemList[focusedItem.name] = cartItemList[focusedItem.name]+1;
            }else{
                cartItemList.Add(focusedItem.name, 1);
            }
            //update state
            ListItems(); 
        }
    }


    public void removeItemFromCart(string itemName){
        Debug.Log("Remove called");
        cartItemList[itemName] = cartItemList[itemName]-1;
        if(cartItemList[itemName] == 0){
            cartItemList.Remove(itemName);
            GameObject itemToRemove = contentContainer.transform.Find(itemName).gameObject;
            Destroy(itemToRemove);
        }
        ListItems();
    }

    private void Awake(){
        Instance = this;
    }
}