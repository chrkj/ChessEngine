using System;
using Chess.UI;
using UnityEngine;

namespace Chess.Core
{
    public class Player
    {
        private Board _board;
        private Camera _mainCam;
        private BoardUI _boardUI;
        private InputState _currentState;
        private enum InputState { None, PieceDragging }
        private int selectedFile;
        private int selectedRank;
        private int selectedPiece;
        private SpriteRenderer selectedPieceRenderer;
        
        public Player(Board board)
        {
            _board = board;
            _boardUI = GameObject.FindObjectOfType<BoardUI>();
            _mainCam = Camera.main;
            _currentState = InputState.None;
        }

        public void Update()
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
                // Calculate file and rank from world position
                var file = (int) Math.Floor(mousePosition.x) + 4;
                var rank = (int) Math.Floor(mousePosition.y) + 4;

                selectedFile = file;
                selectedRank = rank;
                
                // Return if invalid file or rank found
                var isValidSquare = 0 <= file & file < 8 & 0 <= rank & rank < 8;
                if (!isValidSquare) return;
                
                // Get piece renderer at position
                var pieceRenderer = _boardUI.PieceRenderers[Board.GetBoardIndex(file, rank)];
                
                // Return if piece renderer has no sprite
                if (pieceRenderer.sprite == null) return;
                
                // Set selected piece to piece renderer sprite
                selectedPiece = _board.GetPiece(file, rank);
                selectedPieceRenderer = pieceRenderer;

                // Set InputState to Dragging
                _currentState = InputState.PieceDragging;
            }
        }

        // TODO: Refactor, Create data structure for selected and targeted squares 
        // TODO: Set flags piece flags for each move
        private void HandlePieceDragging(Vector3 mousePosition)
        {
            // Move selected piece according to mousePosition
            selectedPieceRenderer.transform.position = new Vector3(mousePosition.x, mousePosition.y, -0.2f);
            
            if (Input.GetButtonUp("Fire1"))
            {
                // Calculate file and rank from world position
                var file = (int) Math.Floor(mousePosition.x) + 4;
                var rank = (int) Math.Floor(mousePosition.y) + 4;
                
                // Cancel move if invalid file or rank found
                var isValidSquare = 0 <= file & file < 8 & 0 <= rank & rank < 8;
                if (!isValidSquare) return;
                
                // Get piece renderer at position
                var pieceAtTargetSquare = _board.GetPiece(file, rank);
                var targetPieceRenderer = _boardUI.PieceRenderers[Board.GetBoardIndex(file, rank)];
                
                // Cancel move if piece renderer has sprite of same color
                var isValid = Piece.GetType(pieceAtTargetSquare) == Piece.None || !Piece.IsSameColor(selectedPiece, pieceAtTargetSquare);
                if (!isValid)
                {
                    selectedPieceRenderer.transform.position = new Vector3(selectedPieceRenderer.transform.parent.position.x, selectedPieceRenderer.transform.parent.position.y, -0.1f);
                    _currentState = InputState.None;
                    return;
                }
                
                // Place sprite at current square
                targetPieceRenderer.sprite = selectedPieceRenderer.sprite;
                
                // Remove sprite from selected piece renderer and reset
                selectedPieceRenderer.sprite = null;
                selectedPieceRenderer.transform.position = new Vector3(selectedPieceRenderer.transform.parent.position.x, selectedPieceRenderer.transform.parent.position.y, -0.1f);

                // Update board
                _board._board[Board.GetBoardIndex(file, rank)] = (byte) selectedPiece;
                _board._board[Board.GetBoardIndex(selectedFile, selectedRank)] = Piece.None;
                
                // Set InputState to None
                _currentState = InputState.None;
            }
        }

    }
}