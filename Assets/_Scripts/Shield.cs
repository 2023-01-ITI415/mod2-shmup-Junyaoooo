using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    public int levelShown = 0;
    public float rotationsPerSecond = 0.1f;

    Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material; 
    }

    // Update is called once per frame
    void Update()
    {
        int currLevel=Mathf.FloorToInt(levelShown);
        if (levelShown != currLevel) 
        {
            levelShown= currLevel;
            mat.mainTextureOffset= new Vector2(0.2f*levelShown, 0);
        }

        float rZ = -(rotationsPerSecond*Time.deltaTime*360)%360f;
        transform.rotation = Quaternion.Euler(0,0,rZ);
    }
}
