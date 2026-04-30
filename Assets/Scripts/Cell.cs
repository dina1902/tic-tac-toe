using UnityEngine;
using UnityEngine.EventSystems;

namespace TicTacToe
{
    public class Cell : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private GameObject _xMark;
        [SerializeField] private GameObject _oMark;
        [SerializeField] private int _index;

        public int Index => _index;
        public string Mark { get; private set; } = "";

        public void OnPointerClick(PointerEventData eventData)
        {
            GameEvents.CellClicked?.Invoke(this);
        }

        public void SetMark(string mark)
        {
            Mark = mark;
            _xMark.SetActive(mark == "X");
            _oMark.SetActive(mark == "O");
        }

        public void Clear()
        {
            Mark = "";
            _xMark.SetActive(false);
            _oMark.SetActive(false);
        }

        public bool IsEmpty()
        {
            return Mark == "";
        }
    }
}
