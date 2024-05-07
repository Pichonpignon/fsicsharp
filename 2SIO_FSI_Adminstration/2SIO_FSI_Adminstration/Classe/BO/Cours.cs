using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2SIO_FSI_Adminstration.Classe.BO
{
    public class Cours
    {
        private int idCours;
        private string libelleCours;
        private string descriptionCours;
        private Section sectionCours;

        public int IdCours { get => idCours; set => idCours = value; }
        public string LibelleCours { get => libelleCours; set => libelleCours = value; }
        public string DescriptionCours { get => descriptionCours; set => descriptionCours = value; }
        public Section SectionCours { get => sectionCours; set => sectionCours = value; }

        public Cours(int id, string libelle, string description, Section section) {
            this.idCours = id;
            this.libelleCours= libelle;
            this.descriptionCours= description;
            SectionCours = section;
        }
    }
}
