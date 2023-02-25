using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsCheck : MonoBehaviour
{

    public enum eType 
    {
        center, inset,outset
    };

    public eType boundsType = eType.center;
    public float radius = 1.1f;
    public float cameraHeight;
    public float cameraWidth;
    // Start is called before the first frame update
    void Awake()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = Camera.main.aspect * cameraHeight;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        float checkRadius = 0;
        if (boundsType == eType.inset) 
        {
            checkRadius = -radius;
        }

        if (boundsType == eType.outset) 
        {
            checkRadius = radius;    
        }

        Vector3 popo = transform.position;

        if (popo.x > cameraWidth+ checkRadius) 
        {
            popo.x=cameraWidth+ checkRadius;
        }
        if (popo.x < -cameraWidth- checkRadius) 
        {
            popo.x=-cameraWidth- checkRadius;
        }

        if (popo.y > cameraHeight+ checkRadius) 
        {
            popo.y=cameraHeight+ checkRadius;
        }

        if (popo.y <-cameraHeight- checkRadius) 
        {
            popo.y = -cameraHeight- checkRadius;
        }


        transform.position = popo;

    }
}
