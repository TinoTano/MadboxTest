using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FunRace
{
    public class BarrierObstacle : LevelObstacle
    {
        [Header("Bounds")]
        public float MinBound;
        public float MaxBound;

        private enum MovementState
        {
            MovingLeft, MovingRight
        }
        MovementState movementState;


        private void Start()
        {
            minPosition = transform.position.x - MinBound;
            maxPosition = transform.position.x + MaxBound;

            obstacleState = ObstacleState.Moving;

            speed = Random.Range(Obstacle.MinSpeed, Obstacle.MaxSpeed);
        }

        // Update is called once per frame
        void Update()
        {
            if(obstacleState == ObstacleState.Waiting)
            {
                if(waitTimer > 0)
                {
                    waitTimer -= Time.deltaTime;
                    return;
                }
                else
                {
                    obstacleState = ObstacleState.Moving;
                }
            }

            if(movementState == MovementState.MovingLeft)
            {
                transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));

                if (transform.position.x < minPosition)
                {
                    movementState = MovementState.MovingRight;
                    NewWaitTime();
                }
            }
            else if(movementState == MovementState.MovingRight)
            {
                transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));

                if (transform.position.x > maxPosition)
                {
                    movementState = MovementState.MovingLeft;
                    NewWaitTime();
                }
            }
        }
    }
}


