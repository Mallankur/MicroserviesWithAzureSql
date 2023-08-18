using Vehicele.Model;

namespace Vehicele.InfraStructure
{
    public interface IVichelecs
    {
        Task<List<Vihicle>> GetAll();    
        Task<Vihicle>GetVihicleBynAME(string name);
        Task<Vihicle>GetById(int id);
        Task<Vihicle> UpdateVihicle(int id, Vihicle newvihele);
        Task<int > DeleteVihicle(int id);
        Task PostVihicle(Vihicle addnewvihicle);


    }
}
