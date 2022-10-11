using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grap : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        gameObject.GetComponentInParent<HandGrap>().PullTrigger(other);
    }
}
