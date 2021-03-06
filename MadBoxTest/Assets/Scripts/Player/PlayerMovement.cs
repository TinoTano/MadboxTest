﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FunRace
{
    public class PlayerMovement : Movement
    {
        private PlayerInput playerInput;


        // Start is called before the first frame update
        void Start()
        {
            playerInput = GetComponent<PlayerInput>();
        }

        // Update is called once per frame
        void Update()
        {
            if (!LevelManager.Instance.LevelRunning)
            {
                return;
            }

            if (playerInput.Move.IsPressed() || playerInput.Move.IsHoldDown())
            {
                Move();
            }
        }
    }
}
