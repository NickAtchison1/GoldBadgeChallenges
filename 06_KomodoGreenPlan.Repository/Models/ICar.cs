using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_KomodoGreenPlan.Repository.Models
{
    public interface ICar
    {
        string Make { get; }
        string Model { get; }
        int ModelYear { get; }
        decimal CarValue { get; }

    }

}

