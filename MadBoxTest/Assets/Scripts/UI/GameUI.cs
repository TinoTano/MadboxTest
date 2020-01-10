using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace FunRace
{
    public class GameUI : Singleton<GameUI>
    {
        [Header("Main Menu")]
        public CanvasGroup MainMenuCanvas;
        public TextMeshProUGUI MoneyText;

        [Header("Countdown")]
        public CanvasGroup CountdownCanvas;
        public TextMeshProUGUI CountdowText;

        [Header("Level Finished")]
        public CanvasGroup LevelFinishedCanvas;
        public TextMeshProUGUI WinnerText;



        

        
    }
}

