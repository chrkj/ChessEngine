using Chess.UI;
using UnityEngine;

namespace Chess.Core
{
    public class GameManager : MonoBehaviour
    {
        private enum State { Playing, Over }

        private Board _board;
        private Player _whitePlayer;
        private Player _blackPlayer;
        private Player _playerTurn;
        private State _gameState;
        private BoardUI _boardUI;


        private void Start()
        {
            _boardUI = FindObjectOfType<BoardUI>();
            _boardUI.InitBoard();
            NewGame();
        }
        
        private void NewGame()
        {
            _board = new Board();
            _board.LoadStartPosition();

            _boardUI.UpdateUI(_board);
            
            _whitePlayer = new HumanPlayer(_board);
            _blackPlayer = new HumanPlayer(_board);
            _playerTurn = _whitePlayer;
            _gameState = State.Playing;
            
            _whitePlayer.ONMoveChosen += MakeMove;
            _blackPlayer.ONMoveChosen += MakeMove;
        }

        private void Update()
        {
            if (_gameState == State.Playing)
                _playerTurn.Update();
            if (Input.GetKeyDown(KeyCode.R))
                NewGame();
        }

        private void MakeMove(Move move)
        {
            _board.MakeMove(move);
            _boardUI.MakeMove(move);
            if (_gameState == State.Playing)
                _playerTurn = (_board.GetColorToMove() == Piece.White) ? _whitePlayer : _blackPlayer;
        }

    }
}