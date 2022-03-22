using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;

    public List<Transform> waypoints;

    public List<Material> materials;
    // Start is called before the first frame update
    void Start()
    {
        enemy.GetComponent<Enemy>().waypoints = waypoints;
        enemy.GetComponent<Enemy>().materials = materials;
        enemy.transform.position = this.transform.position;
        Instantiate(enemy);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            enemy.GetComponent<Enemy>().waypoints = waypoints;
            enemy.GetComponent<Enemy>().materials = materials;
            enemy.transform.position = this.transform.position;
            Instantiate(enemy);
        }
    }
}
