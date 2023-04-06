using Project_IA.Interfaces;

namespace Project_IA.Factory
{
    public interface IIndividualFactory<TEntity> where TEntity : IIndividual<TEntity>
    {
        TEntity GetNewIndividual();
    }
}
