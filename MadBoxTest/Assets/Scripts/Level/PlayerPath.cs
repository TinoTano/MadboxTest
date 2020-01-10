using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FunRace
{
    public class PlayerPath : MonoBehaviour
    {
        public GameObject[] pathPoints;

        private int currentPathIndex = 0;

        public void SetPlayer(GameObject player)
        {
            player.GetComponent<Movement>().SetPlayerPath(this);
        }

        public Vector3 GetNextPoint()
        {
            currentPathIndex++;

            return pathPoints[currentPathIndex].transform.position;
        }
    }
}

