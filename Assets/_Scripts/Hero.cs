using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero S { get; private set; }

    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;

    //[Header("Dynamic")]
    public float shieldLevel = 1;
    // Start is called before the first frame update
    void Awake()
    {
        if (S == null)
        {
            S = this;
        }
        else 
        {
            Debug.LogError("Hero.Awake()-Attempted tp assign second Hero.S!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        Vector3 pos=transform.position;
        pos.x += speed * hAxis * Time.deltaTime;
        pos.y += speed * vAxis * Time.deltaTime;
        transform.position = pos;

        transform.rotation=Quaternion.Euler(vAxis*pitchMult,hAxis*rollMult,0);
    }
}
