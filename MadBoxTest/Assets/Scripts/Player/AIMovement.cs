using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FunRace
{
    public class AIMovement : Movement
    {
        private float waitTime;
        private float waitTimer;

        private float runningTime;
        private float runningTimer;

        private enum State
        {
            Waiting, Running
        }

        private State state;

        private void Start()
        {
            NewRunningTime();
        }

        // Update is called once per frame
        void Update()
        {
            if (!LevelManager.Instance.LevelRunning)
            {
                return;
            }

            if (state == State.Waiting)
            {
                if(waitTimer > 0)
                {
                    waitTimer -= Time.deltaTime;
                }
                else
                {
                    NewRunningTime();
                }
            }
            else if (state == State.Running)
            {
                if (runningTimer > 0)
                {
                    runningTimer -= Time.deltaTime;
                    Move();
                }
                else
                {
                    NewWaitTime();
                }
            }
        }

        void NewWaitTime()
        {
            waitTime = Random.Range(1.0f, 3.0f);
            waitTimer = waitTime;
            state = State.Waiting;
        }

        void NewRunningTime()
        {
            runningTime = Random.Range(1f, 2.0f);
            runningTimer = runningTime;
            state = State.Running;
        }
    }
}

