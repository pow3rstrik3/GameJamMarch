using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR

public class WanderState : IStudentState
{
    public WanderState(StudentController aStudent) : base(aStudent) { }

    private int wayPointIndex = 0;
    private Vector3[] waypoints;

    public override void onEntry()
    {
        waypoints = student.wayPoints;
        //Set current way point to closest waypoint
        float closestWaypointDistance = 0;
        for (int i = 0; i < waypoints.Length; ++i)
        {
            if(i == 0)
            {
                closestWaypointDistance = Vector3.Distance(student.transform.position, waypoints[i]);
            }
            else
            {
                if(Vector3.Distance(student.transform.position, waypoints[i]) < closestWaypointDistance)
                {
                    closestWaypointDistance = Vector3.Distance(student.transform.position, waypoints[i]);
                    wayPointIndex = i;
                }
            }
        }
    }

    public override void onExit()
    {
    }

    public override void onFixedUpdate()
    {
    }

    public override void onUpdate()
    {
        // Move towards waypoint
        student.agent.destination = waypoints[wayPointIndex];

        // Set next waypoint if waypoint is reached
        if (student.wayPoints[wayPointIndex].x == student.transform.position.x && waypoints[wayPointIndex].z == student.transform.position.z)
        {
            ++wayPointIndex;
            if (wayPointIndex == waypoints.Length)
            {
                wayPointIndex = 0;
            }
        }

        // Check if player is within field of view
        Transform player = Camera.main.transform;
        if (student.isInFieldOfView(player.position))
        {
            // Switch to chase state
            student.setState(new ChasePlayerState(student, player));
        }
    }
}
