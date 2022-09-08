using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateItem : MonoBehaviour
{
    public GameObject objectToRotate;

    public float rotationSpeed = 10.0f;
    bool rotationEnabled = false;

    public void ToggleItemRotation() {

        if (!rotationEnabled) {
            rotationEnabled = true;
        }
        else {
            rotationEnabled =false;
        }
    }

    // Update is called once per frame
    void Update() {
        
        
        if(rotationEnabled){
            //Debug.Log("rotationEnabled = true");
            Vector3 rotationToAdd = new Vector3(0, 200, 0);
            //objectToRotate.transform.Rotate(rotationToAdd, rotationSpeed*Time.deltaTime);
            objectToRotate.transform.localEulerAngles = objectToRotate.transform.localEulerAngles + rotationToAdd * rotationSpeed*Time.deltaTime;
        }else{
            //Debug.Log("rotationEnabled = false");
        }
    }
}
