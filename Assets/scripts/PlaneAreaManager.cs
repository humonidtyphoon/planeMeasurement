using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;


public class PlaneAreaManager : MonoBehaviour
{
     void Start()
    {
        
    

    }
    public Text txt;
    List<PlaneAreaBehaviour> planeAreaBehaviours = new List<PlaneAreaBehaviour>();
    // Update is called once per frame
    public void setEstimation(){
        float totalArea = 0;
        foreach( var plane in planeAreaBehaviours ) {
        totalArea  += plane.area;
        }

        txt.text = totalArea.ToString();
        
    }
    void Update()
    {
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Ended)
            {
                if (Input.touchCount == 1)
                {
                    Ray raycast = Camera.main.ScreenPointToRay(touch.position);
                        if (Physics.Raycast(raycast, out RaycastHit raycastHit)) {
                                var planeAreaBehaviour = raycastHit.collider.gameObject.GetComponent<PlaneAreaBehaviour>();

                                if (planeAreaBehaviour != null)
                                {
                                     planeAreaBehaviours.Add(planeAreaBehaviour);
                                    planeAreaBehaviour.ToggleAreaView();
                                }
                        }

                } 
            }
        }
    }
}
