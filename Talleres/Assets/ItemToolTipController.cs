using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemToolTipController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Vector3 direction = transform.position - Input.mousePosition;
        //Physics.Raycast(transform.position, direction,out )
        
    }
}
