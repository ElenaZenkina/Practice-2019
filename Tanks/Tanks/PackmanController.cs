﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace Tanks
{
    public delegate void SendStat(List<string> stats);
    public delegate void SendGameOver();
    public delegate void SendScore(Point appleEating, Point appleNew);

    class PackmanController
    {
        private MainForm mainForm;
        private StatForm formStat;
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

            game = new Game(sendScore, sendGameOver);

            kolobokView = new KolobokView(game.kolobok);
            tankView = new TankView();
        }


        public void LoadIni()
        {
            Ini.Init();
        }

        public void StartGame()
        {
            SendStat sendStat = formStat.AddData;

            game.Move(sendStat);
        }

        public void TurnKolobok(EDirection direction)
        {
            game.kolobok.Turn(direction);
        }

    }
}
