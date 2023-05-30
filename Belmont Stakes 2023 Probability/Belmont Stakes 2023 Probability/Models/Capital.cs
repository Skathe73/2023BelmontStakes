using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belmont_Stakes_2023_Probability.Models
{
    public sealed class Capital
    {
        public double InitialCapital { get; set; }

        private double _currentCapital;

        public double CurrentCapital 
        {
            get { return _currentCapital; }

            set
            {
                _currentCapital = value;

                if (CurrentCapital > MaxCapital)
                {
                    MaxCapital = CurrentCapital;
                }

                if (CurrentCapital < MinCapital)
                {
                    MinCapital = CurrentCapital;
                }
            }
        }
        public double MinCapital { get; private set; }
        public double MaxCapital { get; private set; }
        public double TotalCapitalChange => CurrentCapital - InitialCapital;

        public Capital(double intialCapital)
        {
            InitialCapital = intialCapital;
            CurrentCapital = intialCapital;
            MinCapital = intialCapital;
            MaxCapital = intialCapital;
        }
    }
}
