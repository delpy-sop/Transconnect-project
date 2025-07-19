using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arbres
{
    class Program
    {
        static ArbreBinaire ArbreBinaireTest()
        {
            ArbreBinaire ab = new ArbreBinaire();
            ab.AssocierRacine(1); //créer la racine de l'AB
                                  //sous arbre droite     
            Noeud n1 = new Noeud(2);
            n1.AssocierNoeudFilsDroite(new Noeud(4));
            n1.AssocierNoeudFilsGauche(new Noeud(5));

            //sous arbre gauche
            Noeud n2 = new Noeud(3);
            n2.AssocierNoeudFilsGauche(new Noeud(6));
            n2.AssocierNoeudFilsDroite(new Noeud(7));

            //assemblage final avec la racine
            ab.AssocierFilsDroite(ab.Racine, n2);
            ab.AssocierFilsGauche(ab.Racine, n1);

            return ab;
        }

        static void Exercice1()
        {
            ArbreBinaire x = ArbreBinaireTest();

            Console.WriteLine("Affichage Prefixe\n");
            x.AffichagePrefixe(x.Racine);
            Console.WriteLine("\nAffichage Postfixe\n");
            x.AffichagePostfixe(x.Racine);
            Console.WriteLine("\nAffichage Infixe\n");
            x.AffichageInfixe(x.Racine);

            Console.WriteLine("\nLe nombre d'éléments dans l'arbre " + x.NombreElements(x.Racine));
            Console.WriteLine("le nombre de feuilles de l'arbre " + x.NombreFeuilles(x.Racine));
            Console.WriteLine("La hauteur de l'arbre est " + x.Hauteur(x.Racine));
        }

        static void Creation_Arbre()
        {
            Console.WriteLine("Vous allez créer un arbre");
            ArbreBinaire ab = new ArbreBinaire();
            Console.WriteLine("Entrer la valeur de la racine:");
            Noeud n = new Noeud(Convert.ToInt32(Console.ReadLine()));
            ab.Racine = n;

            n.FilsDroit = filsd(n);
            n.FilsGauche = filsg(n);

            Console.WriteLine("Affichage de l'arbre:");
            AfficherArbre(ab.Racine, 0);
            Console.WriteLine("\nLe nombre d'éléments dans l'arbre " + ab.NombreElements(ab.Racine));
            Console.WriteLine("le nombre de feuilles de l'arbre " + ab.NombreFeuilles(ab.Racine));
            Console.WriteLine("La hauteur de l'arbre est " + ab.Hauteur(ab.Racine));
        }

        static Noeud filsd(Noeud A)
        {
            Console.WriteLine("Entrer le fils droit de " + A.Valeur + " (laisser vide pour aucun):");
            string a = Console.ReadLine();
            if (a != "")
            {
                Noeud c = new Noeud(Convert.ToInt32(a));
                c.FilsDroit = filsd(c);
                c.FilsGauche = filsg(c);
                return c;
            }
            else return null;
        }

        static Noeud filsg(Noeud A)
        {
            Console.WriteLine("Entrer le fils gauche de " + A.Valeur + " (laisser vide pour aucun):");
            string a = Console.ReadLine();
            if (a != "")
            {
                Noeud b = new Noeud(Convert.ToInt32(a));
                b.FilsDroit = filsd(b);
                b.FilsGauche = filsg(b);
                return b;
            }
            else return null;
        }

        static void AfficherArbre(Noeud racine, int niveau = 0)
        {
            if (racine == null)
                return;

            Console.WriteLine(new String(' ', niveau * 4) + racine.Valeur);
            AfficherArbre(racine.FilsGauche, niveau + 1);
            AfficherArbre(racine.FilsDroit, niveau + 1);
        }

        static void Main(string[] args)
        {
            ArbreBinaire x = ArbreBinaireTest();
            AfficherArbre(x.Racine);
            x.SupprimerArbre();
            AfficherArbre(x.Racine);
            Console.ReadKey();
        }
    }
}
