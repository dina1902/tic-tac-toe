using UnityEngine;
using UnityEngine.UI;

namespace TicTacToe
{
    public class UndoButton : MonoBehaviour
    {
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.interactable = false;
            _button.onClick.AddListener(() => GameEvents.UndoRequested?.Invoke());
        }

        private void OnEnable()
        {
            GameEvents.UndoAvailabilityChanged += OnUndoAvailabilityChanged;
        }

        private void OnDisable()
        {
            GameEvents.UndoAvailabilityChanged -= OnUndoAvailabilityChanged;
        }

        private void OnUndoAvailabilityChanged(bool isAvailable)
        {
            _button.interactable = isAvailable;
        }
    }
}
