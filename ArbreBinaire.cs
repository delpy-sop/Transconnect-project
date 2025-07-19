using System;

namespace Arbres
{
    class ArbreBinaire
    {
        Noeud racine;
        public ArbreBinaire()
        {
            this.racine = new Noeud();
        }
        public ArbreBinaire(Noeud n)
        {
            this.racine = n;
        }
        public Noeud Racine
        {
            set { this.racine = value; }
            get { return this.racine; }
        }
        public bool AssocierRacine(int valeur)
        {
            bool ok = false;
            //si arbre vide et si paramètre non null
            if (this.EstArbreVide())
            {
                Noeud n = new Noeud(valeur);
                this.racine = n;
                ok = true;
            }

            return ok;
        }
        public bool AssocierFilsGauche(Noeud parent, Noeud enfant)
        {
            bool ok = false;
            if (parent != null)
            {

                //si pas déjà de fils gauche et si paramètre non null
                if (parent.FilsGauche == null && enfant != null)
                {
                    parent.FilsGauche = enfant;
                    ok = true;
                }
            }
            return ok;
        }

        public bool AssocierFilsDroite(Noeud parent, Noeud enfant)
        {
            bool ok = false;
            if (parent != null)
            {

                //si pas déjà de fils droite et si paramètre non null
                if (parent.FilsDroit == null && enfant != null)
                {
                    parent.FilsDroit = enfant;
                    ok = true;
                }
            }

            return ok;
        }

        public bool EstArbreVide()
        {
            return this.racine == null;
        }

        public void AffichagePrefixe(Noeud n)
        {
            if (n != null)
            {
                Console.Write(n.Valeur + " ");
                AffichagePrefixe(n.FilsGauche);
                AffichagePrefixe(n.FilsDroit);
            }
        }
        public void AffichageInfixe(Noeud n)
        {
            if (n != null)
            {
                AffichageInfixe(n.FilsGauche);
                Console.Write(n.Valeur + " ");
                AffichageInfixe(n.FilsDroit);
            }
        }
        public void AffichagePostfixe(Noeud n)
        {
            if (n != null)
            {
                AffichagePostfixe(n.FilsGauche);
                AffichagePostfixe(n.FilsDroit);
                Console.Write(n.Valeur + " ");
            }
        }   


        public int NombreDescendants(Noeud n)
        {
            if (n == null) return 0;
            return 1 + NombreDescendants(n.FilsGauche) + NombreDescendants(n.FilsDroit);
        }

        public int NombreElements(Noeud n)
        {
            if(n.FilsGauche == null && n.FilsDroit == null) return 0;
            return 1 + NombreDescendants(n.FilsGauche) + NombreDescendants(n.FilsDroit);
        }
        public int NombreFeuilles(Noeud n)
        {
            if (n == null) return 0;
            if (n.EstFeuille()) return 1;
            return NombreFeuilles(n.FilsDroit) + NombreFeuilles(n.FilsGauche);
        }
        public int Hauteur(Noeud n)
        {
            if (n == null) return 0;
            return 1 + Math.Max(Hauteur(n.FilsGauche), Hauteur(n.FilsDroit));
        }

        //Cet algorithme supprime tout l'arbre en supposant que l'on parte de la racine.
        //Il descend jusqu'au feuilles et les supprime puis remonte les branches en les supprimants une à une.
        public void SupprimerArbre()
        {
            SupprimerArbre_rec(this.racine);
            this.racine = null;
        }
        private void SupprimerArbre_rec(Noeud n)
        {
            if (n != null)
            {
                SupprimerArbre_rec(n.FilsGauche);
                SupprimerArbre_rec(n.FilsDroit);
                n.SupprimerNoeud();
                n = null;
            }
        }
    }
}