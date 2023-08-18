using Microsoft.EntityFrameworkCore;
using Vehicele.Data;
using Vehicele.Model;

namespace Vehicele.InfraStructure
{
    public class VihicleServieses : IVichelecs
    {
        private  ApiDbContext  _db  ;
        public VihicleServieses()
        {
          _db = new ApiDbContext();
        }

        public async Task<int> DeleteVihicle(int  id)
        {
            var res = await _db.vihicles.FindAsync(id);   
             if (res != null) {
                _db.vihicles.Remove(res);
                    }
             _db.SaveChanges();
            return res.Id;
        }

        public async  Task<List<Vihicle>> GetAll()
        {
           var vss= await _db.vihicles.ToListAsync();   
            
            return vss; 
        }

        public async Task<Vihicle> GetById(int id)
        {
           return  await _db.vihicles.FindAsync(id).ConfigureAwait(false);
        }

        public async Task<Vihicle> GetVihicleBynAME(string name)
        {
           return await _db.vihicles.FindAsync(name).ConfigureAwait(false);
        }

        public async Task  PostVihicle(Vihicle addnewvihicle)
        {
             await _db.vihicles.AddAsync(addnewvihicle); 
            await _db.SaveChangesAsync();   
        }

        public async Task<Vihicle> UpdateVihicle(int id, Vihicle newvihele)
        {
            var vuhecle = await _db.vihicles.FindAsync(id);
            if (vuhecle != null)
            {
               vuhecle.price = newvihele.price;
                vuhecle.Displacement = newvihele.Displacement;  
                vuhecle.Width = newvihele.Width;
                vuhecle.Height = newvihele.Height;  
            }
            await _db.SaveChangesAsync()
                .ConfigureAwait(false); 
            return newvihele;
        }
    }
}
