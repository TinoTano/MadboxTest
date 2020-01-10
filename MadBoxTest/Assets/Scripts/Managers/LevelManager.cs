using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct FinishLevelEvent
{
    public GameObject Winner;

    public FinishLevelEvent(GameObject winner)
    {
        Winner = winner;
    }
}

namespace FunRace
{
    public class LevelManager : Singleton<LevelManager>, GameEventListener<FinishLevelEvent>
    {
        [Header("Level Info")]
        public LevelInfo info;

        [Header("Level AI Players")]
        public GameObject AIPlayer;

        [Header("Level Paths")]
        public PlayerPath[] PlayerPaths;

        public bool LevelRunning { get; set; } = false;

        // Start is called before the first frame update
        private void Start()
        {
            //Instantiate Players

            for (int i = 0; i < PlayerPaths.Length - 1; i++)
            {
                GameObject AiPlayer = Instantiate(AIPlayer, PlayerPaths[i].pathPoints[0].transform.position, Quaternion.identity);
                PlayerPaths[i].SetPlayer(AiPlayer);
            }

            GameObject Player = Instantiate(GameManager.Instance.Player, PlayerPaths[PlayerPaths.Length - 1].pathPoints[0].transform.position, Quaternion.identity);
            PlayerPaths[PlayerPaths.Length - 1].SetPlayer(Player);

            Camera.main.GetComponent<CameraFollow>().SetPlayerToFollow(Player);
        }

        private void OnEnable()
        {
            EventManager.AddListener(this);
        }

        private void OnDisable()
        {
            EventManager.RemoveListener(this);
        }

        public void InitLevel()
        {
            CountdownUI.Instance.ShowCountdown();

            StartCoroutine(StartCountDown());
        }

        private IEnumerator StartCountDown()
        {
            int seconds = 3;

            for(int i = seconds; i > 0; i--)
            {
                CountdownUI.Instance.UpdateCountdownText(i);
                yield return new WaitForSeconds(1);
            }

            CountdownUI.Instance.HideCountdown();
            LevelRunning = true;
        }

        public void SetWinner(GameObject winner)
        {
            bool winnerIsPlayer = false;

            if(winner.CompareTag("Player"))
            {
                GameManager.Instance.AddMoney(info.MoneyRewards);

                winnerIsPlayer = true;
            }

            LevelFinishUI.Instance.ShowLevelFinished(winnerIsPlayer, info.MoneyRewards);
        }
        
        public void OnGameEvent(FinishLevelEvent gameEvent)
        {
            LevelRunning = false;

            SetWinner(gameEvent.Winner);
        }
    }
}

