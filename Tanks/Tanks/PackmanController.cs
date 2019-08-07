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

        public PackmanController()
        {
            game = new Game();

            formStat = new StatForm();
            //formStat.MdiParent = this;
            formStat.Show();

        }


        public void LoadIni()
        {
            Ini.Init();
        }

        public void StartGame()
        {
            game.Move();
        }

    }
}
