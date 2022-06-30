using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;

public class PlaneAreaBehaviour : MonoBehaviour
{
    
    public ARPlane arPlane;
    public   float area ;
    public Text txt;
     public TextMeshPro BucketNumberMeshPro;
    // Start is called before the first frame update
    void Update()
    {
        BucketNumberMeshPro.transform.rotation = Quaternion.LookRotation(BucketNumberMeshPro.transform.position -  Camera.main.transform.position);
        // textField.text = CalculatePlaneArea(arPlane).ToString();
        
    }
    void Start()
    {
        arPlane.boundaryChanged += ArPlane_BoundaryChanged;
    }
    
    private float CalculatePlaneArea(ARPlane plane)  
    {        
        return plane.size.x * plane.size.y;
    }

    public void setText()
    {
        float area = CalculatePlaneArea(arPlane);
          
        txt.text = area.ToString();
    }

    private void ArPlane_BoundaryChanged(ARPlaneBoundaryChangedEventArgs obj)
    {

        area = CalculatePlaneArea(arPlane);
        
        BucketNumberMeshPro.text = area.ToString();
         txt.text = area.ToString();
        
    }
    // Update is called once per frame
    
    public void ToggleAreaView()
    {
        if(BucketNumberMeshPro.enabled)
            BucketNumberMeshPro.enabled = false;
        else
            BucketNumberMeshPro.enabled = true;
    }
}
