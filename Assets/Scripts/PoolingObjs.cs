using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingObjs : MonoBehaviour
{
    public static PoolingObjs instance;
    private void Awake()
    {
        if(instance == null) { instance = this; }
        else                 { Destroy(gameObject); }
    }


    [SerializeField] private GameObject obj;

    [SerializeField] private GameObject movingObj;

    ///////
    [SerializeField] private GameObject apple;
    [SerializeField] private GameObject bananas;
    [SerializeField] private GameObject cherries;
    [SerializeField] private GameObject kiwi;
    [SerializeField] private GameObject melon;
    [SerializeField] private GameObject orange;
    [SerializeField] private GameObject pineapple;
    [SerializeField] private GameObject strawberry;
    ///////
    
    private List<GameObject> movingObjPool;
    ///////
    private List<GameObject> applePool;
    private List<GameObject> bananasPool;
    private List<GameObject> cherriesPool;
    private List<GameObject> kiwiPool;
    private List<GameObject> melonPool;
    private List<GameObject> orangePool;
    private List<GameObject> pineapplePool;
    private List<GameObject> strawberryPool;
    ///////

    private void Start() 
    {
        movingObjPool = new List<GameObject>();

        applePool = new List<GameObject>();
        bananasPool = new List<GameObject>();
        cherriesPool = new List<GameObject>();
        kiwiPool = new List<GameObject>();
        melonPool = new List<GameObject>();
        orangePool = new List<GameObject>();
        pineapplePool = new List<GameObject>();
        strawberryPool = new List<GameObject>();
    }

    public GameObject Pooling(string innerPool)
    {
        switch (innerPool)
        {
            case "movingObj":
                for (int i = 0; i < movingObjPool.Count; i++)
                {
                    if (!movingObjPool[i].activeInHierarchy) { return movingObjPool[i]; }
                }
                obj = Instantiate(movingObj, transform);
                movingObjPool.Add(obj);
                return obj;
            case "apple":
                for (int i = 0; i < applePool.Count; i++)
                {
                    if (!applePool[i].activeInHierarchy) { return applePool[i]; }
                }
                obj = Instantiate(apple, transform);
                applePool.Add(obj);
                return obj;
            case "bananas":
                for (int i = 0; i < bananasPool.Count; i++)
                {
                    if (!bananasPool[i].activeInHierarchy) { return bananasPool[i]; }
                }
                obj = Instantiate(bananas, transform);
                bananasPool.Add(obj);
                return obj;
            case "cherries":
                for (int i = 0; i < cherriesPool.Count; i++)
                {
                    if (!cherriesPool[i].activeInHierarchy) { return cherriesPool[i]; }
                }
                obj = Instantiate(cherries, transform);
                cherriesPool.Add(obj);
                return obj;
            case "kiwi":
                for (int i = 0; i < kiwiPool.Count; i++)
                {
                    if (!kiwiPool[i].activeInHierarchy) { return kiwiPool[i]; }
                }
                obj = Instantiate(kiwi, transform);
                kiwiPool.Add(obj);
                return obj;
            case "melon":
                for (int i = 0; i < melonPool.Count; i++)
                {
                    if (!melonPool[i].activeInHierarchy) { return melonPool[i]; }
                }
                obj = Instantiate(melon, transform);
                melonPool.Add(obj);
                return obj;
            case "orange":
                for (int i = 0; i < orangePool.Count; i++)
                {
                    if (!orangePool[i].activeInHierarchy) { return orangePool[i]; }
                }
                obj = Instantiate(orange, transform);
                orangePool.Add(obj);
                return obj;
            case "pineapple":
                for (int i = 0; i < pineapplePool.Count; i++)
                {
                    if (!pineapplePool[i].activeInHierarchy) { return pineapplePool[i]; }
                }
                obj = Instantiate(pineapple, transform);
                pineapplePool.Add(obj);
                return obj;
            case "strawberry":
                for (int i = 0; i < strawberryPool.Count; i++)
                {
                    if (!strawberryPool[i].activeInHierarchy) { return strawberryPool[i]; }
                }
                obj = Instantiate(strawberry, transform);
                strawberryPool.Add(obj);
                return obj;
            default:
                return null;
        }
    }
}
