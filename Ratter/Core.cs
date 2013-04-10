using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EveComFramework;

namespace Ratter
{
    class Core : EveComFramework.Core.State
    {
        #region Instantiation
        static Core _Instance;
        public static Core Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new Core();
                }
                return _Instance;
            }
        }

        private Core()
            : base()
        {

        }

        #endregion

        #region Actions

        public void Start()
        {
            if (Idle)
            {
                
            }

        }

        public void Stop()
        {
            Clear();
        }

        #endregion
    }
}
