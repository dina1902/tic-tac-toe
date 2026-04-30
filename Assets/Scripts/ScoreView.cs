using TMPro;
using UnityEngine;

namespace TicTacToe
{
    public class ScoreView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _scoreXText;
        [SerializeField] private TMP_Text _scoreOText;

        private void OnEnable()
        {
            GameEvents.ScoreChanged += OnScoreChanged;
        }

        private void OnDisable()
        {
            GameEvents.ScoreChanged -= OnScoreChanged;
        }

        private void OnScoreChanged(int scoreX, int scoreO)
        {
            _scoreXText.text = $"X: {scoreX}";
            _scoreOText.text = $"O: {scoreO}";
        }
    }
}
