using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FunRace
{
    public class GameManager : PersistentSingleton<GameManager>
    {
        public GameObject Player;

        private int playerMoney = 0;

        protected override void Awake()
        {
            base.Awake();

            LoadPlayerMoney();
        }

        private void LoadPlayerMoney()
        {
            if (PlayerPrefs.HasKey("Money"))
            {
                playerMoney = PlayerPrefs.GetInt("Money");
                MainMenuUI.Instance.UpdateMoneyText(playerMoney);
            }
        }

        private void SavePlayerMoney()
        {
            PlayerPrefs.SetInt("Money", playerMoney);
        }

        public void AddMoney(int moneyAmount)
        {
            playerMoney += moneyAmount;

            MainMenuUI.Instance.UpdateMoneyText(playerMoney);

            SavePlayerMoney();
        }
    }
}

