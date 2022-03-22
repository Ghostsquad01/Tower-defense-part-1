using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // todo #1 set up properties
    //   health, speed, coin worth
    //   waypoints
    //   delegate event for outside code to subscribe and be notified of enemy death
    public int health = 4;
    public float speed = 1;
    public int coinValue = 1;

    public List<Transform> waypoints;
    public List<Material> materials;

    private GameObject gm;
    private UI_manager ui;
    private int targetWaypointIndex;
    private int changeMaterial;
    // NOTE! This code should work for any speed value (large or small)

    //-----------------------------------------------------------------------------
    void Start()
    {
        // todo #2
        transform.position = waypoints[0].position;
        targetWaypointIndex = 1;
        changeMaterial = 0;
        gm = GameObject.FindWithTag("UI_manager");
        ui = gm.gameObject.GetComponent<UI_manager>();
        //   Place our enemy at the starting waypoint
    }

    //-----------------------------------------------------------------------------
    void Update()
    {
        if (targetWaypointIndex == 8)
        {
            Debug.Log("Enemy has reached your gates! You lost!");
            return;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 200))
            {
                if (hit.collider.gameObject.CompareTag("Enemy_1"))
                {
                    health--;
                    if (health == 0)
                    {
                        Destroy(gameObject);
                        AddToPurse();
                    }
                    else
                    {
                        changeMaterial++;
                        GetComponent<MeshRenderer>().material = materials[changeMaterial];
                    }
                    Debug.Log("Enemy hit! HP: " + health); 
                }
            }
        }
        
        
        // todo #3 Move towards the next waypoint
        Vector3 targetPosition = waypoints[targetWaypointIndex].position;
        Vector3 movementDir = (targetPosition - transform.position).normalized;

        Vector3 newPosition = transform.position;
        newPosition += movementDir * Time.deltaTime;

        transform.position = newPosition;

        // todo #4 Check if destination reaches or passed and change target
        if (transform.position == waypoints[targetWaypointIndex].position)
        {
            targetWaypointIndex++;
        }

        
    }

    //-----------------------------------------------------------------------------
    private void TargetNextWaypoint()
    {
    }

    private void AddToPurse()
    {
        ui.addCoins();
    }
}
