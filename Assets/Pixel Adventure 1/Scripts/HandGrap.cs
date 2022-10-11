using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrap : MonoBehaviour
{
    [SerializeField]private Vector3 mousePosition;
    [SerializeField]private GameObject hander;
    [SerializeField]private Vector2 handerPos;
    [SerializeField]private float speed;
    enum GrapState
    {
        IDLE,
        GRAP,
        RETURN
    }

    [SerializeField]private GrapState CurrentState; 

private void Start() {
    CurrentState = GrapState.IDLE;
}
    private void MouseClick() {
        if (CurrentState == GrapState.IDLE){
            Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            Debug.Log(direction);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle+90f));
            CurrentState = GrapState.GRAP;
            handerPos = hander.transform.position;
        }
    }

    private void moveDown(){
        hander.transform.position += -transform.up * speed * Time.deltaTime;
    }

    private void moveUp(){
        hander.transform.position += transform.up * speed * Time.deltaTime;
        if (Vector2.Distance(hander.transform.position, transform.position) < .4f){
            CurrentState = GrapState.IDLE;
            PointCounting();
        }
    }

    private void PointCounting(){
        Debug.Log("add Point!");
    }

    public void PullTrigger(Collider2D other) {
        
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.transform.SetParent(hander.transform);
        }
        CurrentState = GrapState.RETURN;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) 
            MouseClick();
        if (CurrentState == GrapState.GRAP)
            moveDown();
        if (CurrentState == GrapState.RETURN)
            moveUp();
    }
}
