using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class MoveBookCase2 : MonoBehaviour
{
    public float MoveBy = 0.1f;
    public int MoveNumberOfTimes = 10;
    void OnEnable()
    {
        EventManager.StartListening("MoveBookCase", SomeFunction);
    }

    void SomeFunction()
    {
        StartCoroutine("MoveBookCase");
    }

    IEnumerator MoveBookCase()
    {
        float timePassed = 0;
        while (timePassed < MoveNumberOfTimes)
        {
            transform.Translate(new Vector3(transform.position.x - MoveBy, transform.position.y, transform.position.z));
            timePassed += Time.deltaTime;

            yield return null;
        }
    }
}
