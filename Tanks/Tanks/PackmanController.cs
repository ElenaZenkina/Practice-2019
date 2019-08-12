using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tanks
{
    public delegate void SendStat(List<string> stats);
    public delegate void SendGameOver();
    public delegate void SendScore();

    class PackmanController
    {
        private MainForm mainForm;
        private StatForm formStat;

        private SendStat sendStat;
        private SendScore sendScore;
        private SendGameOver sendGameOver;

        public Game game;
        public KolobokView kolobokView;
        public TankView tankView;

        public PackmanController(MainForm mainForm)
        {
            this.mainForm = mainForm;
            formStat = new StatForm();
            //formStat.MdiParent = this;
            formStat.Show();

            sendGameOver = mainForm.GameOver;
            sendScore = mainForm.UpdateScore;
            sendStat = formStat.AddData;

            game = new Game(sendScore, sendGameOver);

            kolobokView = new KolobokView(game.kolobok);
            tankView = new TankView();
        }


        public void Move()
        {
            game.Move(sendStat);
        }

        public void TurnKolobok(EDirection direction)
        {
            game.kolobok.Turn(direction);
        }

        public void FireKolobok()
        {
            game.FireKolobok();
        }

    }
}
