using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayerState : IStudentState
{
    private Transform player;

    public ChasePlayerState(StudentController aStudent, Transform aPlayer) : base(aStudent)
    {
        player = aPlayer;
    }

    public override void onEntry()
    {
    }

    public override void onExit()
    {
    }

    public override void onFixedUpdate()
    {
    }

    public override void onUpdate()
    {
        // Chase player
        student.agent.destination = player.position;
        if (!student.isInFieldOfView(player.position))
        {
            student.setState(new WanderState(student));
            return;
        }

        if (Vector3.Distance(student.transform.position, player.position) <= student.caughtPlayerDistance)
        {
            // Player was caught
            // TODO: publish event?
        }
    }
}
