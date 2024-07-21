using System;
using System.Collections.Generic;

namespace Core.Data.Progress
{
    [Serializable]
    public class Progress
    {
        public LinkedList<string> EquationHistory;
        public string CurrentEquation;

        public Progress()
        {
            EquationHistory = new LinkedList<string>();
        }
    }
}