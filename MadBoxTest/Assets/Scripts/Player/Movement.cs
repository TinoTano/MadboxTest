using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FunRace
{
    public class Movement : MonoBehaviour
    {
        public float Speed = 5;

        private PlayerPath path;
        private Vector3 currentPathPoint;

        protected void Move()
        {
            if (Vector3.Distance(transform.position, currentPathPoint) < 0.1f)
            {
                currentPathPoint = path.GetNextPoint();
            }

            Vector3 movement = currentPathPoint - transform.position;

            transform.Translate(movement * Time.deltaTime * Speed);
        }

        public void SetPlayerPath(PlayerPath path)
        {
            this.path = path;

            currentPathPoint = path.pathPoints[0].transform.position;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.CompareTag("Obstacle"))
            { 
                transform.position = path.pathPoints[0].transform.position;
            }
        }
    }
}

