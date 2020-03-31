using PetGreen.Domain.DTO.Register;

namespace PetGreen.Domain.Entities.Register.Interfaces
{
    public interface ICaterer
    {
        /// <summary>
        /// Converte o objeto CatererDTO para a entidade Caterer
        /// </summary>
        /// <param name="caterer"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        Caterer FillCaterer(Caterer caterer, CatererDTO dto);
    }
}
