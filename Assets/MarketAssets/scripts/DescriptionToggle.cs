using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DescriptionToggle : MonoBehaviour
{
    bool hiddenDescription = false; //private
    [SerializeField] GameObject[] descriptionCanvasList; //private //SerializeField shows property in inspector


    public void toggleDescription()
    {
        if (hiddenDescription) {
            foreach (var canvas in descriptionCanvasList)
            {
                canvas.SetActive(true);
            }
            hiddenDescription = false;
        } 
        else {
            foreach (var canvas in descriptionCanvasList)
            {
                canvas.SetActive(false);
            }
            hiddenDescription = true;
        }
    }

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // // Update is called once per frame
    // void Update()
    // {
        
    // }
}
