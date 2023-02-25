using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static private Main S;

    public GameObject[] preFabEnemies;
    public float enemyInsetDefault = 1.5f;
    public float enemySpawnPerSecond = 0.4f;

    private BoundsCheck bndCheck;

    private void Awake()
    {
        S= this;
        bndCheck=GetComponent<BoundsCheck>();
        Invoke(nameof(SpawnEnemy), 1f / enemySpawnPerSecond);
    }

    public void SpawnEnemy() 
    {
        int ndx = Random.Range(0,preFabEnemies.Length);
        GameObject gop = Instantiate<GameObject>(preFabEnemies[ndx]);
        float enemyInset = enemyInsetDefault;
        if (gop.GetComponent<BoundsCheck>()!=null) 
        {
            enemyInset = Mathf.Abs(gop.GetComponent<BoundsCheck>().radius);
        }

        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.cameraWidth + enemyInset;
        float xMax=bndCheck.cameraWidth-enemyInset;
        pos.x=Random.Range(xMin,xMax);
        pos.y=bndCheck.cameraHeight+enemyInset;
        gop.transform.position=pos;
        Invoke(nameof(SpawnEnemy), 1f / enemySpawnPerSecond);
    }
}
