using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2SIO_FSI_Adminstration.Classe.BO
{
    public class Utilisateur
    {
        private int idUtilisateur;
        private string loginUtilisateur;
        private string mdpUtilisateur;

        public Utilisateur(int idUtilisateur, string loginUtilisateur, string mdpUtilisateur)
        {
            this.idUtilisateur = idUtilisateur;
            this.loginUtilisateur = loginUtilisateur;
            this.mdpUtilisateur = mdpUtilisateur;
        }
        public Utilisateur(int idUtilisateur, string loginUtilisateur)
        {
            this.idUtilisateur = idUtilisateur;
            this.loginUtilisateur = loginUtilisateur;
        }


        public int IdUtilisateur { get => idUtilisateur; set => idUtilisateur = value; }
        public string LoginUtilisateur { get => loginUtilisateur; set => loginUtilisateur = value; }
        public string MdpUtilisateur { get => mdpUtilisateur; set => mdpUtilisateur = value; }
    }
}

