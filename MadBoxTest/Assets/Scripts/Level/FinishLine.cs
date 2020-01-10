using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FunRace
{
    public class FinishLine : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            EventManager.TriggerEvent(new FinishLevelEvent(other.gameObject));
        }
    }
}

