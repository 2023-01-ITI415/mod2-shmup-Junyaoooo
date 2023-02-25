using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BoundsCheck : MonoBehaviour
{
    public enum eScreenLocs 
    {
        onscreen=0,
        offRight=1,
        offLeft=2,
        offUp=3,
        offDown=8,
        
    }


    public enum eType 
    {
        center, inset,outset
    };

    public eType boundsType = eType.center;
    public float radius = 1.1f;
    public float cameraHeight;
    public float cameraWidth;
    public bool keepOnScreen = true;
    //public bool isOnScreen = true;
    public eScreenLocs screenLocs=eScreenLocs.onscreen;
    // Start is called before the first frame update
    void Awake()
    {
        cameraHeight = Camera.main.orthographicSize;
        cameraWidth = Camera.main.aspect * cameraHeight;
    }


    public bool LocIs(eScreenLocs checkLoc) 
    {
        if (checkLoc == eScreenLocs.onscreen) return isOnScreen;
        return ((screenLocs & checkLoc) == checkLoc);
    }


    public bool isOnScreen 
    {
        get { return (screenLocs == eScreenLocs.onscreen); }
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
        screenLocs = eScreenLocs.onscreen;
       // isOnScreen = true;

        if (popo.x > cameraWidth+ checkRadius) 
        {
            popo.x=cameraWidth+ checkRadius;
            screenLocs |= eScreenLocs.offRight;
           // isOnScreen = false;
        }
        if (popo.x < -cameraWidth- checkRadius) 
        {
            popo.x=-cameraWidth- checkRadius;
            screenLocs |= eScreenLocs.offLeft;
            // isOnScreen = false;
        }

        if (popo.y > cameraHeight+ checkRadius) 
        {
            popo.y=cameraHeight+ checkRadius;
            screenLocs |= eScreenLocs.offUp;
            // isOnScreen = false;
        }

        if (popo.y <-cameraHeight- checkRadius)
        {
            popo.y = -cameraHeight - checkRadius;
            screenLocs |= eScreenLocs.offDown;
            // isOnScreen = false;
        }

        if (keepOnScreen && !isOnScreen)
        {
            transform.position = popo;
            screenLocs= eScreenLocs.onscreen;
            // isOnScreen= true;
        }
        //transform.position = popo;

    }
}
