using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grap : MonoBehaviour
{
    public bool avtiveState;
    private void OnTriggerEnter2D(Collider2D other) {
        if (avtiveState){
            gameObject.GetComponentInParent<HandGrap>().PullTrigger(other);
        }
    }
}
