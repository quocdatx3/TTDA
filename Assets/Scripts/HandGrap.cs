using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandGrap : MonoBehaviour
{
    [SerializeField] private Vector3 mousePosition;
    [SerializeField] private GameObject hander;
    [SerializeField] private GameObject poolingObj;
    [SerializeField] private Vector2 handerPos;
    [SerializeField] private float speed;
    [SerializeField] private bool getItem = false;

    [SerializeField] private GameObject gameManager;
    enum GrapState
    {
        IDLE,
        GRAP,
        RETURN
    }

    [SerializeField] private GrapState CurrentState;

    private void Start()
    {
        CurrentState = GrapState.IDLE;
    }
    private void MouseClick()
    {
        if (CurrentState == GrapState.IDLE)
        {
            Vector2 direction = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
            Debug.Log(direction);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90f));
            CurrentState = GrapState.GRAP;
            handerPos = hander.transform.position;
            hander.GetComponent<Grap>().avtiveState = true;
        }
    }

    private void moveDown()
    {
        hander.transform.position += -transform.up * speed * Time.deltaTime;
    }

    private void moveUp()
    {
        hander.transform.position += transform.up * speed * Time.deltaTime;
        if (Vector2.Distance(hander.transform.position, transform.position) < 1.4f)
        {
            CurrentState = GrapState.IDLE;
            if (getItem)
            {
                PointCounting();
            }
        }
    }

    private void PointCounting()
    {
        string fruitName = hander.transform.GetChild(0).GetComponent<Fruit>().getName();


        hander.transform.GetChild(0).gameObject.SetActive(false);
        hander.transform.GetChild(0).SetParent(poolingObj.transform);
        getItem = false;
    }

    public void PullTrigger(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            other.gameObject.transform.SetParent(hander.transform);
            getItem= true;
        }
        CurrentState = GrapState.RETURN;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            MouseClick();
        if (CurrentState == GrapState.GRAP)
            moveDown();
        if (CurrentState == GrapState.RETURN)
        {
            moveUp();
            hander.GetComponent<Grap>().avtiveState = false;
        }

    }
}
