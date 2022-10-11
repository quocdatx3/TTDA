using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjGenerator : MonoBehaviour
{
    [SerializeField]private GameObject movingObj;
    [SerializeField]private float CDTime=0f;
    [SerializeField]private float minCDTime;
    [SerializeField]private float maxCDTime;

    // Start is called before the first frame update
    void Start()
    {   
        CDTime = Random.Range(minCDTime,maxCDTime);
    }

    // Update is called once per frame
    void Update()
    {
        CDTime-=Time.deltaTime;
        if(CDTime<=0f){
            CDTime = Random.Range(minCDTime,maxCDTime);
            Instantiate(movingObj, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
