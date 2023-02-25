using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Enemy : MonoBehaviour
{
    public float speed = 15f;
    public float fireRate = 0.33f;
    public float health = 10;
    public int score = 100;


    private BoundsCheck bndCheck;

    void Awake() 
    {
        bndCheck=GetComponent<BoundsCheck>();
    }

    public Vector3 pos 
    {
        get { return this.transform.position; }
        set { this.transform.position = value; }
    }
    // Start is called before the first frame update
    public virtual void Move()
    {
        Vector3 temPos = pos;
        temPos.y-=speed*Time.deltaTime;
        pos=temPos;
    }

    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log("xasasa");
        GameObject otherGoo = collision.gameObject;
        if (otherGoo.GetComponent<ProjectileHero>() != null)
        {
            Destroy(otherGoo);
            Destroy(gameObject);
        }
        else 
        {
            Debug.Log("xxxxx");
        }
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        if (bndCheck.LocIs(BoundsCheck.eScreenLocs.offDown)) 
        {
            Destroy(gameObject);
        }
    }
}
