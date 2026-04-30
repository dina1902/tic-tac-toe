using UnityEngine;

namespace TicTacToe
{
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _successClip;
        [SerializeField] private AudioClip _errorClip;
        [SerializeField] private AudioClip _resultClip;

        private void OnEnable()
        {
            GameEvents.MoveMade += OnMoveMade;
            GameEvents.InvalidMove += OnInvalidMove;
            GameEvents.GameWon += OnGameWon;
            GameEvents.GameDrawn += OnGameDrawn;
        }

        private void OnDisable()
        {
            GameEvents.MoveMade -= OnMoveMade;
            GameEvents.InvalidMove -= OnInvalidMove;
            GameEvents.GameWon -= OnGameWon;
            GameEvents.GameDrawn -= OnGameDrawn;
        }

        private void OnMoveMade()
        {
            _audioSource.PlayOneShot(_successClip);
        }

        private void OnInvalidMove()
        {
            _audioSource.PlayOneShot(_errorClip);
        }

        private void OnGameWon(string winner)
        {
            _audioSource.PlayOneShot(_resultClip);
        }

        private void OnGameDrawn()
        {
            _audioSource.PlayOneShot(_resultClip);
        }
    }
}
