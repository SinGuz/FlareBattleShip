using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlareBattleShip.Data
{
    /// <summary>
    /// NOT REQUIRED - Leave it in here for potential improvements to automatically
    /// configure board, ships, sizes etc.
    /// Config class that contains information about the game
    /// this could probably include information about the number and size of ships
    /// it could be populated from a json file instead of being hard coded like here
    /// </summary>
    public sealed class Config
    {
        private static Config cnfg = null;
        private static int matrixSize = 10;

        private Config()
        {
        }

        public static Config Cnfg
        {
            get
            {
                if (cnfg == null)
                    cnfg = new Config();
                return cnfg;
            }
        }

        public int MatrixSize
        {
            get
            {
                return matrixSize;
            }
        }

    }
}
