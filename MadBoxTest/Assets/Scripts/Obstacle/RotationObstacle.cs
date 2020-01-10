using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FunRace
{
    public class RotationObstacle : LevelObstacle
    {
        private float nextAngle = 0;

        // Start is called before the first frame update
        void Start()
        {
            obstacleState = ObstacleState.Moving;

            speed = Random.Range(Obstacle.MinSpeed, Obstacle.MaxSpeed);
        }

        // Update is called once per frame
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

                    if (nextAngle == 360)
                    {
                        nextAngle = 0;
                    }

                    nextAngle += 90;
                }
            }

            if(nextAngle == 360 && transform.rotation.eulerAngles.y < 270 || transform.rotation.eulerAngles.y >= nextAngle)
            {
                NewWaitTime();
            }
            else
            {
                transform.rotation *= Quaternion.Euler(new Vector3(0, speed * Time.deltaTime, 0));
            }
        }
    }
}

