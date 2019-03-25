using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StudentController : MonoBehaviour
{
    public Vector3[] wayPoints;

    public NavMeshAgent agent;

    private IStudentState currentState;

    public bool wanderingPLayer = true;

    public int viewAngle;
    public float maxViewDistance;
    public float caughtPlayerDistance;

    public Vector3 walkAwayPoint;

    public AudioClip askForAnswersLine;
    public AudioClip thankYouLine;
    public AudioClip answerJeffLine;
    public AudioClip giveBookLine;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (wanderingPLayer)
        {
            setState(new WanderState(this));
        }
        else
        {
            setState(new IdleState(this));
        }
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
        //Check if within view angle
        if (Vector3.Angle(target - transform.position, transform.forward) <= viewAngle)
        {
            //Check if within view range
            return Vector3.Distance(target, transform.position) <= maxViewDistance;
        }
        return false;
    }

    public void talkToStudent()
    {
        if (!wanderingPLayer)
            setState(new TalkingState(this));
    }

    public void giveBookToStudent()
    {
        if (!wanderingPLayer)
            setState(new WalkAwayState(this));
    }
}
