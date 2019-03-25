using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IStudentState : IState
{
    protected StudentController student;

    protected IStudentState(StudentController aStudent)
    {
        student = aStudent;
    }
}
