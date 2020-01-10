using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FunRace
{
    public class CameraFollow : MonoBehaviour
    {
        public Vector3 Offset;
        public float Angle;
        
        private GameObject playerToFollow;

        private void Start()
        {
            SetNewAngle(Angle);
        }

        // Update is called once per frame
        void Update()
        {
            transform.position = playerToFollow.transform.position + Offset;
        }

        public void SetPlayerToFollow(GameObject player)
        {
            playerToFollow = player;
        }

        public void SetNewOffset(Vector3 offset)
        {
            Offset = offset;
        }

        public void SetNewAngle(float angle)
        {
            transform.rotation = Quaternion.Euler(angle, 0, 0);
        }
    }
}

