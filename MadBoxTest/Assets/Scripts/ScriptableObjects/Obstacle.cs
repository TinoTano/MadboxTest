using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FunRace
{
    [CreateAssetMenu(fileName = "Obstacle", menuName = "FunRace/Obstacle")]
    public class Obstacle : ScriptableObject
    {
        [Header("Random Speed")]
        public float MinSpeed = 2;
        public float MaxSpeed = 5;

        [Header("Random Waiting Time")]
        public float WaitingTimeMin;
        public float WaitingTimeMax;
    }
}

