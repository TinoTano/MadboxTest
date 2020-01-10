using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FunRace
{
    public class CountdownUI : Singleton<CountdownUI>
    {
        public TextMeshProUGUI CountdownText;

        private CanvasGroup countdownCanvas;

        private void Start()
        {
            countdownCanvas = GetComponent<CanvasGroup>();
        }

        public void ShowCountdown()
        {
            if (countdownCanvas != null)
            {
                countdownCanvas.alpha = 1;
            }
        }

        public void HideCountdown()
        {
            if (countdownCanvas != null)
            {
                countdownCanvas.alpha = 0;
            }
        }

        public void UpdateCountdownText(int countdown)
        {
            CountdownText.text = countdown.ToString();
        }
    }
}

