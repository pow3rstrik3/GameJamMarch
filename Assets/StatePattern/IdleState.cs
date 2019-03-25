using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : IStudentState
{
    public IdleState(StudentController aStudent) : base(aStudent) { }

    public override void onEntry()
    {
        student.setState(new TalkingState(student));
    }

    public override void onExit()
    {

    }

    public override void onFixedUpdate()
    {

    }

    public override void onUpdate()
    {

    }
}
