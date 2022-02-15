using Chess.UI;
using UnityEngine;

namespace Chess.Core
{
    public class GameManager : MonoBehaviour
    {
        
        private Board _board;
        // Player whitePlayer;
        // Player blackPlayer;
        private Player _playerTurn;
        // State gameState;
        private BoardUI _boardUI;

        private void Start()
        {
            _board = new Board();
            _playerTurn = new Player();
            _boardUI = FindObjectOfType<BoardUI>();
            
            _boardUI.InitBoard();
            _board.LoadStartPosition();
            _boardUI.UpdateUI(_board);
        }

        private void Update()
        {
            _playerTurn.Update();
        }
    }
}