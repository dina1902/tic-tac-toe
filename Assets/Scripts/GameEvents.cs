using System;
using UnityEngine;

namespace TicTacToe
{
    public static class GameEvents
    {
        public static Action<Cell> CellClicked;
        public static Action MoveMade;
        public static Action InvalidMove;
        public static Action<string> GameWon;
        public static Action GameDrawn;
        public static Action<int, int> ScoreChanged;
        public static Action<string> ResultReady;
        public static Action UndoRequested;
        public static Action<bool> UndoAvailabilityChanged;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void ResetOnPlay()
        {
            CellClicked = null;
            MoveMade = null;
            InvalidMove = null;
            GameWon = null;
            GameDrawn = null;
            ScoreChanged = null;
            ResultReady = null;
            UndoRequested = null;
            UndoAvailabilityChanged = null;
        }
    }
}
