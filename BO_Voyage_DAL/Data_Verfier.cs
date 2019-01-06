using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO_Voyage_DTO;
namespace BO_Voyage_DAL
{
    public partial class DataPool
    {

        /*On ajoute dans chaque nouveau dto correspondant les données que l'on récupère dans la base grâce au contexte*/
        public IEnumerable<dtoListeContinent> GetListeContinent()
        {
            var data = BoVContext.GetListeContinent();
            var resultat = new List<dtoListeContinent>();       
            foreach (var lc in data)
            {
                resultat.Add(new dtoListeContinent { Id = lc.Id, Nom = lc.Nom });
            }
            return resultat;
        } 

        public IEnumerable<dtoListePays> GetListePays(int choixC)
        {
            var data = BoVContext.GetListePays(choixC);

            var resultat = new List<dtoListePays>();
            foreach (var lp in data)
            {
                resultat.Add(new dtoListePays { Id = lp.Id, Nom = lp.Nom });
            }
            return resultat;
        }
        public IEnumerable<dtoListeRegion> GetListeRegion(int choixP, int choixC)
        {
            var data = BoVContext.GetListeRegion(choixP, choixC);

            var resultat = new List<dtoListeRegion>();
            foreach (var lr in data)
            {
                resultat.Add(new dtoListeRegion { Id = lr.Id, Nom = lr.Nom });
            }
            return resultat;
        }

        public IEnumerable<dtoListeVoyage> GetListeVoyage(int choixC, int choixP, int choixR)
        {
            var data = BoVContext.GetListeVoyage(choixC, choixP, choixR);

            var resultat = new List<dtoListeVoyage>();
            foreach (var lv in data)
            {
                resultat.Add(new dtoListeVoyage { Id = lv.Id, Nom = lv.Nom, Description = lv.Description, Url = lv.Url });
            }
            return resultat;
        }
     
        public dtoListeVoyage GetVoyage(int IdV)
        {
            Voyage data = BoVContext.Voyages.Where(V => V.Id == IdV).ToList().FirstOrDefault();
            dtoListeVoyage voy = new dtoListeVoyage { Nom = data.Nom, Id = data.Id, Description = data.Description, Url = data.Url, Prix = data.Prix.Value, DateDepart = data.DateDepart.Value,DateRetour=data.DateRetour.Value };
            return voy;
        }

        public static string GeneratePassword(int lowercase, int uppercase, int numerics,int specials)
        {
            string lowers = "abcdefghijklmnopqrstuvwxyz";
            string uppers = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string number = "0123456789";
            string special = "_#+-*?!";
            Random random = new Random();

            string generated = "!";
            for (int i = 1; i <= lowercase; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    lowers[random.Next(lowers.Length - 1)].ToString()
                );

            for (int i = 1; i <= uppercase; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    uppers[random.Next(uppers.Length - 1)].ToString()
                );


            for (int i = 1; i <= specials; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    special[random.Next(special.Length - 1)].ToString()
                );

            for (int i = 1; i <= numerics; i++)
                generated = generated.Insert(
                    random.Next(generated.Length),
                    number[random.Next(number.Length - 1)].ToString()
                );

            return generated.Replace("!", string.Empty);

        }
     
    }

}
