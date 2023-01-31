using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] private string fruitName;

    public string getName(){
        return this.fruitName;
    }
}
