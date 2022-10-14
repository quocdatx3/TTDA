using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsFolower : MonoBehaviour
{
    [SerializeField]private List<GameObject> waypointsList;

    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;

    public void AddWaypoint(GameObject go) 
    {
        waypointsList.Add(go);
    }

    private void Update()
    {
        if (waypointsList.Count !=0){
            transform.position = Vector2.MoveTowards(transform.position, waypointsList[currentWaypointIndex].transform.position, speed * Time.deltaTime);
            if (Vector2.Distance(waypointsList[currentWaypointIndex].transform.position, transform.position) < .1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypointsList.Count)
                {
                    currentWaypointIndex = 0;
                    waypointsList.Clear();
                    if( transform.childCount > 0){
                        GameObject go = this.gameObject.transform.GetChild(0).gameObject;
                        go.SetActive(false);
                        go.transform.SetParent(this.transform.parent.transform);
                    }
                    gameObject.SetActive(false);
                }
            }
        }
    }
    private void OnEnable() {
        if(waypointsList.Count > 0){
            transform.position = waypointsList[currentWaypointIndex].transform.position;
        }
    }
}
