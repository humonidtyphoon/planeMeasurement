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
    public TextMeshPro BucketNumberMeshPro;
    public   float area ;
    public Text txt;
    // Start is called before the first frame update
    // List<PlaneAreaBehaviour> planeAreaBehaviour = new List<PlaneAreaBehaviour>();

    void Update()
    {
        BucketNumberMeshPro.transform.rotation = Quaternion.LookRotation(BucketNumberMeshPro.transform.position -  Camera.main.transform.position);
    }
    void Start()
    {
        
        arPlane.boundaryChanged += ArPlane_BoundaryChanged;
    }

    private void ArPlane_BoundaryChanged(ARPlaneBoundaryChangedEventArgs obj)
    {
      
          area = CalculatePlaneArea(arPlane);
        BucketNumberMeshPro.text = area.ToString();
         txt.text = area.ToString();
         
        
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

   
    // Update is called once per frame
    
    public void ToggleAreaView()
    {
        if(BucketNumberMeshPro.enabled)
            BucketNumberMeshPro.enabled = false;
        else
            BucketNumberMeshPro.enabled = true;
    }
}
