using EarthEscape.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;

namespace EarthEscape.Managers
{
    [Export(typeof(ISolverManager))]
    public class SolverManager : ISolverManager
    {
        [ImportMany]
        IEnumerable<ISolver> Solvers;

        public SolverManager()
        { 
        }
        public string Process(string input)
        {
            string answer = string.Empty;
            foreach (var solver in Solvers)
            {
                answer = solver.solve(input);
                if (!string.IsNullOrEmpty(answer))
                    break;
            }
            return answer;
        }
    }
}