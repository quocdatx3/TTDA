using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitsGenerator : MonoBehaviour
{
    [SerializeField]private GameObject[] Fruits;

    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0, Fruits.Length-1);
        if(Fruits.Length>0){
            GameObject gb = Instantiate(Fruits[index], new Vector3(0, 0, 0), Quaternion.identity);
            if (gb) {
                gb.transform.SetParent(transform);
                gb.transform.localPosition = new Vector3(0, 0, 0);
            }
        }
    }

}
