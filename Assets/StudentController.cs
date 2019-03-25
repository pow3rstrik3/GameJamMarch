using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StudentController : MonoBehaviour
{
    public Vector3[] wayPoints;

    public NavMeshAgent agent;

    private IStudentState currentState;

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

    void setState(IStudentState newState)
    {
        if(currentState != null)
        {
            currentState.onExit();
        }
        currentState = newState;
        currentState.onEntry();
    }
}
