using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.XR.ARFoundation;

public class AreaController : MonoBehaviour
{
    public TextMeshPro BucketNumberMeshPro;

   
    public void setName()
    {
        BucketNumberMeshPro.text = "AAa";
    }
}
