using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkAwayState : IStudentState
{
    public WalkAwayState(StudentController aStudent) : base(aStudent) { }

    private bool walkAwayAnimationSet = false;

    public override void onEntry()
    {
        student.GetComponent<Animator>().SetTrigger("ReachOut");
        student.GetComponent<AudioSource>().clip = student.giveBookLine;
    }

    public override void onExit()
    {
    }

    public override void onFixedUpdate()
    {
    }

    public override void onUpdate()
    {
        if (!student.GetComponent<AudioSource>().isPlaying)
        {
            if (!walkAwayAnimationSet)
            {
                student.GetComponent<Animator>().SetTrigger("WalkAway");
            }
            student.GetComponent<NavMeshAgent>().destination = student.walkAwayPoint;
        }
    }
}
