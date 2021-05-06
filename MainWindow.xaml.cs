using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Jeu_du_devin
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            private void Proposition_CanExecuted(object sender, ExecutedRoutedEventArgs e)
            {
                e.CanExecuted = true;
            }

            private void Nouveau_Executed(object sender, ExecutedRoutedEventArgs e)
            {
                Nouveau = TextBlockText.Text;
            }

            private void Nouveau_CanExecuted(object sender, ExecutedRoutedEventArgs e)
            {
                e.CanExecuted = true;
            }


            const int nombreMystereMin = 1;
            const int nombreMystereMax = 10000;
            Random random = new Random();
            int nombreMystere = random.Next(nombreMystereMin, nombreMystereMax);
            const int nb_Essais = 10;
            int nombreDeVies = nb_Essais;

            while (nombreDeVies > 0)
            {

                Console.Write("Devinez le nombre mystère entre " + nombreMystereMin + " et " + nombreMystereMax + " (il vous reste " + nombreDeVies + " vies): ");
                String resultat = Console.ReadLine();

                int nombreUtilisateur = 0;
                if (int.TryParse(resultat, out nombreUtilisateur))
                {
                    // La convertion s'est bien passée

                    if ((nombreUtilisateur < nombreMystereMin) || (nombreUtilisateur > nombreMystereMax))
                    {
                        Console.WriteLine("ERREUR: Vous devez rentrer un nombre entre " + nombreMystereMin + " et " + nombreMystereMax);
                    }
                    else
                    {
                        if (nombreUtilisateur < nombreMystere)
                        {
                            Console.WriteLine("Le nombre mystère est plus grand.");
                        }
                        else if (nombreUtilisateur > nombreMystere)
                        {
                            Console.WriteLine("Le nombre mystère est plus petit.");
                        }
                        else
                        {
                            // Egalité : c'est gagné
                            Console.WriteLine("BRAVO: Vous avez trouvé le nombre mystère");
                            break;
                        }
                        nombreDeVies--;
                    }
                }
                else
                {
                    // Erreur de la conversion
                    Console.WriteLine("ERREUR: Vous devez rentrer un nombre.");
                }

                Console.WriteLine("");
            }

            // Sortie de la boucle
            if (nombreDeVies == 0)
            {
                Console.WriteLine("Désolé, vous avez perdu, le nombre mystère était: " + nombreMystere);
            }
        }

        private void Proposition_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Proposition = TextBlockText.Text;
            TextBlockText.Text = string.Empty;
        }
    }

}

   