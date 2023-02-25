using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero S { get; private set; }

    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;


    private GameObject lastTri = null;
    //[Header("Dynamic")]
    private float _shieldLevel = 1;

    public float shieldLevel 
    {
        get { return (_shieldLevel); }
        private set {
            _shieldLevel = Mathf.Min(value, 4);
            if (value < 0) 
            {
                Destroy(this.gameObject);
                Main.HERO_DIED();
            }
        }
    }


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


    private void OnTriggerEnter(Collider other)
    {
        Transform roott = other.gameObject.transform.root;
        GameObject gogo = roott.gameObject;
        if (gogo==lastTri) 
        {
            return;
        }lastTri= gogo;

        Enemy enemyu= gogo.GetComponent<Enemy>();
        if (enemyu != null)
        {
            shieldLevel--;
            Destroy(gogo);
        }
        else 
        {
            Debug.LogWarning("Shield trigger hit by non-Enemy: "+gogo.name);
        }
        //Debug.Log("Shield trigger hit by: "+ gogo.gameObject.name);
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
