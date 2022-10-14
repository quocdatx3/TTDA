using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjGenerator : MonoBehaviour
{
    [SerializeField]private GameObject movingObj;
    [SerializeField]private GameObject fruitObj;
    [SerializeField]private float CdTime=0f;
    [SerializeField]private float minCdTime;
    [SerializeField]private float maxCdTime;
    [SerializeField]private int fruit;
    [SerializeField]private GameObject[] waypointsArray;
    
    // Update is called once per frame
    void Update()
    {
        CdTime-=Time.deltaTime;
        if(CdTime<=0f){
            CdTime = Random.Range(minCdTime,maxCdTime);
            movingObj = PoolingObjs.instance.Pooling("movingObj");
            fruit = Random.Range(0,7);
            switch (fruit)
            {
                case 0:
                    fruitObj = PoolingObjs.instance.Pooling("apple");
                    break;
                case 1:
                    fruitObj = PoolingObjs.instance.Pooling("bananas");
                    break;
                case 2:
                    fruitObj = PoolingObjs.instance.Pooling("cherries");
                    break;
                case 3:
                    fruitObj = PoolingObjs.instance.Pooling("kiwi");
                    break;
                case 4:
                    fruitObj = PoolingObjs.instance.Pooling("melon");
                    break;
                case 5:
                    fruitObj = PoolingObjs.instance.Pooling("orange");
                    break;
                case 6:
                    fruitObj = PoolingObjs.instance.Pooling("pineapple");
                    break;
                case 7:
                    fruitObj = PoolingObjs.instance.Pooling("strawberry");
                    break;
                default:
                    break;
            }
            fruitObj.transform.SetParent(movingObj.transform);
            fruitObj.transform.localPosition = new Vector3(0, 0, 0);
            for(int i=0;i<waypointsArray.Length;i++){
                movingObj.GetComponent<WaypointsFolower>().AddWaypoint(waypointsArray[i]);
            }
            movingObj.SetActive(true);
            fruitObj.SetActive(true);
        }
    }
}
