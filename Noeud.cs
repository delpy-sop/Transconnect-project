using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbres
{
    class Noeud
    {
        int valeur;
        Noeud filsDroit;
        Noeud filsGauche;

        public Noeud()
        {
            this.valeur = 0;
            this.filsDroit = null;
            this.filsGauche = null;
        }
        public Noeud(int v )
        {
            this.valeur = v;
            this.filsDroit = null;
            this.filsGauche = null;
        }

        public Noeud(int v, Noeud x, Noeud y)
        {
            this.valeur = v;
            this.filsDroit = x;
            this.filsGauche = y;
        }

        public int Valeur
        {
            get { return this.valeur; }
            set { this.valeur = value; }
        }

        public Noeud FilsDroit
        {
            get { return this.filsDroit; }
            set { this.filsDroit = value; }
        }
        public Noeud FilsGauche
        {
            get { return this.filsGauche; }
            set { this.filsGauche = value; }
        }

      

        public bool AssocierNoeudFilsGauche(Noeud enfant)
        {
            bool ok = false;
            if (this != null)
            {
                //  Noeud enfant = new Noeud(v);

                //si pas déjà de fils gauche et si paramètre non null
                if (this.FilsGauche == null && enfant != null)
                {
                    this.FilsGauche = enfant;
                    ok = true;
                }


            }
            return ok;
        }

        public bool AssocierNoeudFilsDroite(Noeud enfant)
        {
            bool ok = false;
            if (this != null)
            {
                //si pas déjà de fils droite et si paramètre non null
                if (this.FilsDroit == null && enfant != null)
                {
                    this.FilsDroit = enfant;
                    ok = true;
                }

            }

            return ok;
        }

        //vérifier si un noeud est une feuille
        public bool EstFeuille()
        {
            bool ok = false;
            if (this.FilsDroit == null && this.FilsGauche == null)
            {
                ok = true;
            }
            return ok;
        }

        //méthode qui retourne le nombre d'enfants du noeud courant >>> au max un noeud a deux enfants
        
        public int NombreEnfants()
        {
            int nb = 0;
            if (this.FilsDroit != null) nb++;
            if (this.FilsGauche != null) nb++;
            return nb;
        }
        public void SupprimerNoeud()
        {
            this.FilsDroit = null;
            this.FilsGauche = null;
        }
    }
}
