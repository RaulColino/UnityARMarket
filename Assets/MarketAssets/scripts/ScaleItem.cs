using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleItem : MonoBehaviour
{
    public GameObject shopItem;

    bool scaleUp; //variables private by default
    private bool scaleDown; //no need to put private as variables are private by default
    
    //Scale speed (scale per frame)
    public float scaleStep = 0.01f;

    const float MAX_SCALE = 2.0f;
    const float MIN_SCALE = 0.5f;

    // Update is called once per frame
    void Update() {

        Vector3 currentScale = shopItem.transform.localScale;

        if(scaleUp && currentScale.x < MAX_SCALE){
            //Debug.Log("ScaleUp: currentScale:" + shopItem.transform.localScale);
            shopItem.transform.localScale += new Vector3(scaleStep, scaleStep, scaleStep);
        }
        
        if(scaleDown && currentScale.x > MIN_SCALE) {
            //Debug.Log("ScaleDown: currentScale:" + shopItem.transform.localScale);
            shopItem.transform.localScale -= new Vector3(scaleStep, scaleStep, scaleStep);
        }
    }

    public void onPressScaleUp(){
        scaleUp = true;
    }
    public void onReleaseScaleUp(){
        scaleUp = false;
    }


    public void onPressScaleDown(){
        scaleDown = true;
    }
    public void onReleaseScaleDown(){
        scaleDown = false;
    }
}

// public class ScaleItem : MonoBehaviour
// {
//     public GameObject shopItem;

//     bool scaleUp; //variables private by default
//     private bool scaleDown; //no need to put private as variables are private by default
    
//     //Scale speed (scale per frame)
//     public float scaleStep = 0.005f;

//     const int MAX_SCALE_STEPS = 10;
//     const int MIN_SCALE_STEPS = -5;
//     int currentScaleSteps = 0;

//     // Update is called once per frame
//     void Update() {

//         if(scaleUp && currentScaleSteps < MAX_SCALE_STEPS){
//             shopItem.transform.localScale += new Vector3(scaleStep, scaleStep, scaleStep);
//             currentScaleSteps++;
//         }
        
//         if(scaleDown && currentScaleSteps > MIN_SCALE_STEPS) {
//             shopItem.transform.localScale -= new Vector3(scaleStep, scaleStep, scaleStep);
//             currentScaleSteps--;
//         }
//     }

//     public void onPressScaleUp(){
//         scaleUp = true;
//     }
//     public void onReleaseScaleUp(){
//         scaleUp = false;
//     }


//     public void onPressScaleDown(){
//         scaleDown = true;
//     }
//     public void onReleaseScaleDown(){
//         scaleDown = false;
//     }
// }
