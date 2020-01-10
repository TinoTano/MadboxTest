using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FunRace
{
    [CreateAssetMenu(fileName = "Level Info", menuName = "FunRace/Level Info")]
    public class LevelInfo : ScriptableObject
    {
        public int MoneyRewards;
    }
}

