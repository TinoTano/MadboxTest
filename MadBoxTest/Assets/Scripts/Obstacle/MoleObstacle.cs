using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FunRace
{
    public class MoleObstacle : LevelObstacle
    {
        [Header("Bounds")]
        public float MinBound;
        public float MaxBound;

        private enum MovementState
        {
            MovingUp, MovingDown
        }
        MovementState movementState;


        private void Start()
        {
            minPosition = transform.position.y - MinBound;
            maxPosition = transform.position.y + MaxBound;

            obstacleState = ObstacleState.Moving;

            speed = Random.Range(Obstacle.MinSpeed, Obstacle.MaxSpeed);
        }

        void Update()
        {
            if (obstacleState == ObstacleState.Waiting)
            {
                if (waitTimer > 0)
                {
                    waitTimer -= Time.deltaTime;
                    return;
                }
                else
                {
                    obstacleState = ObstacleState.Moving;
                }
            }

            if (movementState == MovementState.MovingDown)
            {
                transform.Translate(new Vector3(0, -speed * Time.deltaTime, 0));

                if (transform.position.y < minPosition)
                {
                    movementState = MovementState.MovingUp;
                    NewWaitTime();
                }
            }
            else if (movementState == MovementState.MovingUp)
            {
                transform.Translate(new Vector3(0, speed * Time.deltaTime, 0));

                if (transform.position.y > maxPosition)
                {
                    movementState = MovementState.MovingDown;
                    NewWaitTime();
                }
            }
        }
    }
}

