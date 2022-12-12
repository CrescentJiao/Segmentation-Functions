using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBee : MonoBehaviour
{
    public Transform flowers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(BeeStGraph.yy <= 100 && Mytimer2.isPause == false)
        {
            transform.RotateAround(flowers.localPosition, flowers.up, BeeChangeSpeed.BeeSpeed * 10 * Time.deltaTime);
        }
       
    }
}
