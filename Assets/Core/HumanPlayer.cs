using System;
using Chess.UI;
using UnityEngine;

namespace Chess.Core
{
    public class HumanPlayer : Player
    {
        private byte _selectedPiece;
        private int _selectedIndex;
        
        private readonly Board _board;
        private readonly Camera _mainCam;
        private readonly BoardUI _boardUI;
        private InputState _currentState;
        private enum InputState { None, PieceDragging }

        public HumanPlayer(Board board)
        {
            _board = board;
            _boardUI = GameObject.FindObjectOfType<BoardUI>();
            _mainCam = Camera.main;
            _currentState = InputState.None;
        }

        public override void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            var mousePosition = _mainCam.ScreenToWorldPoint(Input.mousePosition);
            switch (_currentState)
            {
                case InputState.None:
                    HandlePieceSelection(mousePosition);
                    break;
                case InputState.PieceDragging:
                    HandlePieceDragging(mousePosition);
                    break;
            }
        }

        private void HandlePieceSelection(Vector3 mousePosition)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                var selectedFile = (int) Math.Floor(mousePosition.x) + 4;
                var selectedRank = (int) Math.Floor(mousePosition.y) + 4;
                _selectedIndex = Board.GetBoardIndex(selectedFile, selectedRank);

                var isValidSquare = 0 <= selectedFile & selectedFile < 8 & 0 <= selectedRank & selectedRank < 8;
                if (!isValidSquare || !_boardUI.HasSprite(_selectedIndex)) return;

                _selectedPiece = _board.GetPiece(_selectedIndex);
                if (!_board.IsCurrentPlayerPiece(_selectedPiece)) return;

                _boardUI.HighlightSquare(_selectedIndex);
                _currentState = InputState.PieceDragging;
            }
        }
        
        private void HandlePieceDragging(Vector3 mousePosition)
        {
            _boardUI.HandleDragging(mousePosition, _selectedIndex);
            if (Input.GetButtonUp("Fire1"))
                HandlePlacement(mousePosition);
        }

        private void HandlePlacement(Vector3 mousePosition)
        {
            var file = (int)Math.Floor(mousePosition.x) + 4;
            var rank = (int)Math.Floor(mousePosition.y) + 4;
            var targetIndex = Board.GetBoardIndex(file, rank);
            var chosenMove = new Move(_selectedIndex, targetIndex, _selectedPiece);
            
            var isValidSquare = 0 <= file & file < 8 & 0 <= rank & rank < 8;
            if (!isValidSquare) return;

            # region Temp (To be replaced by check on generated valid moves
            var pieceAtTargetSquare = _board.GetPiece(file, rank);
            var isValid = Piece.IsEmpty(pieceAtTargetSquare) || !Piece.IsSameColor(_selectedPiece, pieceAtTargetSquare);
            if (!isValid)
            {
                _boardUI.ResetPiece(_selectedIndex);
                _currentState = InputState.None;
                return;
            }
            # endregion
            
            //// Generate all legal moves from current board
            //var legalMoves = MoveGenerator.GenerateLegalMoves(_board);
            //// Check of chosen move is contained in the set of legal moves
            //if (legalMoves.Contains(chosenMove))
            //else
            //    _boardUI.ResetPiece(_selectedIndex);

            var lastMove = _board.GetLastMove();
            if (lastMove != null)
            {
                _boardUI.UnhighlightSquare(lastMove.StartSquare);
                _boardUI.UnhighlightSquare(lastMove.TargetSquare);
            }
            ChooseMove(chosenMove);
            _boardUI.HighlightSquare(targetIndex);
            _currentState = InputState.None;
        }
    }
}