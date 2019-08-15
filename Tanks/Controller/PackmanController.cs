using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Model;
using Common;

namespace Controller
{
    public class PackmanController
    {
        private Game game;

        public PackmanController()
        {
        }

        public void StartGame(EventAddScore sendScore, EventUpdateView sendUpdateView, EventGameOver sendGameOver)
        {
            game = new Game();
            game.OnAddScore += sendScore;
            game.OnUpdateView += sendUpdateView;
            game.OnGameOver += sendGameOver;
            game.NewGame();
        }

        public void Move()
        {
            game.Move();
        }

        public void TurnKolobok(EDirection direction)
        {
            game.TurnKolobok(direction);
        }

        public void FireKolobok()
        {
            game.FireKolobok();
        }

    }
}

