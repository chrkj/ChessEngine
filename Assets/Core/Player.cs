using System;

namespace Chess.Core
{
    public abstract class Player
    {
        public event Action<Move> ONMoveChosen;
        
        public abstract void Update();

        protected void ChooseMove(Move move)
        {
            ONMoveChosen?.Invoke(move);
        }
    }
}