using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2SIO_FSI_Adminstration.Classe.BO
{
    public class Section
    {
        private int idSection;
        private string lilbelleSection;

        public int IdSection { get => idSection; set => idSection = value; }
        public string LilbelleSection { get => lilbelleSection; set => lilbelleSection = value; }

        public Section(int id, string libelle) 
        {
            this.idSection = id;
            this.lilbelleSection= libelle;
        }
        public Section() { }
    }
}
