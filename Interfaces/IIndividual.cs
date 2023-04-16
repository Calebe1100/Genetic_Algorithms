using System.Collections.Generic;

namespace Project_IA.Interfaces
{
    public interface IIndividual<TEntity>
    {
        List<TEntity> Recombine(TEntity individual);
        TEntity Mutate();
        double Avaliar();
        List<TEntity> InvertedAvaliations(List<TEntity> individuals, int numberIndividuals);
    }
}
