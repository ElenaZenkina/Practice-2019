using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tanks
{
    public delegate void SendMessage(string name, int x, int y);

    class PackmanController
    {
        private StatForm formStat;

        public Game game;
        public KolobokView kolobokView;

        public PackmanController()
        {
            formStat = new StatForm();
            //formStat.MdiParent = this;
            formStat.Show();

            game = new Game();
            kolobokView = new KolobokView(game.kolobok);
        }


        public void LoadIni()
        {
            Ini.Init();
        }

        public void StartGame()
        {
            SendMessage sm = formStat.AddData;
            game.Move(sm);
        }

        public void TurnKolobok(EDirection direction)
        {
            game.kolobok.Turn(direction);
        }

    }
}
