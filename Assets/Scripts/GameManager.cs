using UnityEngine;

namespace TicTacToe
{
    public class GameManager : MonoBehaviour
    {
        private int _scoreX;
        private int _scoreO;

        private void OnEnable()
        {
            GameEvents.GameWon += OnGameWon;
            GameEvents.GameDrawn += OnGameDrawn;
        }

        private void OnDisable()
        {
            GameEvents.GameWon -= OnGameWon;
            GameEvents.GameDrawn -= OnGameDrawn;
        }

        private void Start()
        {
            GameEvents.ScoreChanged?.Invoke(_scoreX, _scoreO);
        }

        private void OnGameWon(string winner)
        {
            if (winner == "X")
            {
                _scoreX++;
            }
            else
            {
                _scoreO++;
            }

            GameEvents.ScoreChanged?.Invoke(_scoreX, _scoreO);
            GameEvents.ResultReady?.Invoke($"{winner} wins!");
        }

        private void OnGameDrawn()
        {
            GameEvents.ResultReady?.Invoke("Draw!");
        }
    }
}
