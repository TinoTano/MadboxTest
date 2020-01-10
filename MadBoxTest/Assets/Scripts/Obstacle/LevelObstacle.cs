using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FunRace
{
    public abstract class LevelObstacle : MonoBehaviour
    {
        [Header("Obstacle")]
        public Obstacle Obstacle;

        protected float minPosition;
        protected float maxPosition;

        protected enum ObstacleState
        {
            Waiting, Moving
        }
        protected ObstacleState obstacleState;

        protected float waitTimer;

        protected float speed;



        protected void NewWaitTime()
        {
            waitTimer = Random.Range(Obstacle.WaitingTimeMin, Obstacle.WaitingTimeMax);
            obstacleState = ObstacleState.Waiting;
        }
    }
}

