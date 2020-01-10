using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FunRace
{
    public class LevelFinishUI : Singleton<LevelFinishUI>
    {
        public TextMeshProUGUI WinnerText;
        public TextMeshProUGUI MoneyWonText;

        private CanvasGroup levelFinishedCanvas;

        private void Start()
        {
            levelFinishedCanvas = GetComponent<CanvasGroup>();
        }

        public void ShowLevelFinished(bool winner, int money)
        {
            if (levelFinishedCanvas != null)
            {
                levelFinishedCanvas.alpha = 1;
                levelFinishedCanvas.interactable = true;
                levelFinishedCanvas.blocksRaycasts = true;

                ShowWinnerText(winner);
                if(winner)
                {
                    ShowMoneyWon(money);
                }
            }
        }

        private void ShowWinnerText(bool winner)
        {
            string text = "You Lose!";

            if (winner)
            {
                text = "You Won!";
            }

            WinnerText.text = text;
        }

        private void ShowMoneyWon(int money)
        {
            MoneyWonText.enabled = true;
            MoneyWonText.text = money.ToString() + "$";
        }

        public void ResetLevel()
        {
            LoadSceneManager.Instance.ReloadScene();
        }
    }
}

