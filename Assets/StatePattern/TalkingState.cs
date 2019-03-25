using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkingState : IStudentState
{
    public TalkingState(StudentController aStudent) : base(aStudent) { }
    private AudioSource audioSource;

    private AudioClip[] clips = new AudioClip[3];
    private int clipIndex = 0;

    public override void onEntry()
    {
        student.GetComponent<Animator>().SetTrigger("IsTalking");
        audioSource = student.GetComponent<AudioSource>();

        clips[0] = student.askForAnswersLine;
        clips[1] = student.answerJeffLine;
        clips[2] = student.thankYouLine;

        clipIndex = 0;
    }

    public override void onExit()
    {
    }

    public override void onFixedUpdate()
    {
    }

    public override void onUpdate()
    {
        if (!audioSource.isPlaying)
        {
            if(clipIndex == clips.Length)
            {
                student.setState(new IdleState(student));
            }
            audioSource.clip = clips[clipIndex];
            audioSource.Play();
            ++clipIndex;
        }
    }
}
