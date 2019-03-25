using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StudentController : MonoBehaviour
{
    public Vector3[] wayPoints;

    public NavMeshAgent agent;

    private IStudentState currentState;

    public int viewAngle;
    public float maxViewDistance;
    public float caughtPlayerDistance;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        setState(new WanderState(this));
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState != null)
        {
            currentState.onUpdate();
        }
    }

    private void FixedUpdate()
    {
        if(currentState != null)
        {
            currentState.onFixedUpdate();
        }
    }

    public void setState(IStudentState newState)
    {
        if(currentState != null)
        {
            currentState.onExit();
        }
        currentState = newState;
        currentState.onEntry();
    }

    //Checks if target is in view of the Student
    public bool isInFieldOfView(Vector3 target)
    {
        Debug.Log("Angle to center: " + Vector3.Angle(target - transform.position, transform.forward));
        //Check if within view angle
        if (Vector3.Angle(target - transform.position, transform.forward) <= viewAngle)
        {
            //Check if within view range
            return Vector3.Distance(target, transform.position) <= maxViewDistance;
        }
        return false;
    }
}
