using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FunRace
{
    public class PlayerInput : MonoBehaviour
    {
        public struct Button
        {
            private string buttonName;

            public Button(string ButtonName)
            {
                buttonName = ButtonName;
            }

            public bool IsPressed()
            {
                return Input.GetButtonDown(buttonName);
            }

            public bool IsHoldDown()
            {
                return Input.GetButton(buttonName);
            }

            public bool IsReleased()
            {
                return Input.GetButtonUp(buttonName);
            }
        }

        public Button Move;

        private void Start()
        {
            Move = new Button("Move");
        }
    }
}

