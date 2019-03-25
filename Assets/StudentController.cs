using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StudentController : MonoBehaviour
{
    public Vector3[] wayPoints;
    private int wayPointIndex = 0;

    private NavMeshAgent agent;

    bool movingToStart = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = wayPoints[wayPointIndex];
        if(wayPoints[wayPointIndex].x == transform.position.x && wayPoints[wayPointIndex].z == transform.position.z)
        {
            ++wayPointIndex;
            if(wayPointIndex == wayPoints.Length)
            {
                wayPointIndex = 0;
            }
        }
    }
}
