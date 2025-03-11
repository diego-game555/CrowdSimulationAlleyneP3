using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropCylinder : MonoBehaviour
{
    public GameObject obstacle;
    GameObject[] agents;

    void Start()
    {
        agents = GameObject.FindGameObjectWithTag("agent");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointtoRay(Input.mousePosition);
            if (Physics.Raycasr(ray.origin, ray.direction, out hitInfo))
            {
                Instantiate(obstacle, hitInfo.point, obstacle.transform.rotation);
                foreach (GameObject a in agents)
                {
                    a.GetComponent<AIControl>().DetectNewObstacle(hitInfo.point);
                }
            }
        }
    }
}
