using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FunRace
{
    public class MainMenuUI : Singleton<MainMenuUI>
    {
        public TextMeshProUGUI MoneyText;

        private CanvasGroup mainMenuCanvas;

        private void Start()
        {
            mainMenuCanvas = GetComponent<CanvasGroup>();
        }

        public void StartGame()
        {
            HideMainMenu();

            LevelManager.Instance.InitLevel();
        }

        public void ShowMainMenu()
        {
            if (mainMenuCanvas != null)
            {
                mainMenuCanvas.alpha = 1;
                mainMenuCanvas.interactable = true;
                mainMenuCanvas.blocksRaycasts = true;
            }
        }

        public void HideMainMenu()
        {
            if (mainMenuCanvas != null)
            {
                mainMenuCanvas.alpha = 0;
                mainMenuCanvas.interactable = false;
                mainMenuCanvas.blocksRaycasts = false;
            }
        }

        public void UpdateMoneyText(int money)
        {
            MoneyText.text = money.ToString();
        }
    }
}

