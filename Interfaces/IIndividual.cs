using Project_IA.Entities;
using System.Collections.Generic;

namespace Project_IA.Interfaces
{
    public interface IIndividual<TEntity>
    {
        List<TEntity> Recombine(TEntity ind);
        TEntity Mutate();
        double Avaliar();
    }
}
