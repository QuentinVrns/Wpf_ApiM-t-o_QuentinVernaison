using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_ApiMétéo_QuentinVernaison
{
    
    
        internal class WeatherService
        {
            public MainWindow mainwindow { get; set; }
            public string chemin = @"ListeVille\Ville.txt";
            private List<string> cityList = new List<string>();

            public void AjouterLaVille(string Ville)
            {
                // Ajoute la ville à la liste
                cityList.Add(Ville);

                // Met à jour la source de la ComboBox avec la liste mise à jour
                mainwindow.Cb_Ville.ItemsSource = cityList;
                mainwindow.Cb_Ville.Items.Refresh(); // Rafraîchit la ComboBox

                // Ajoute la ville au fichier Ville.txt
                string chemin = @"ListeVille\Ville.txt"; // Spécifiez le chemin complet du fichier
                using (StreamWriter sw = new StreamWriter(chemin, true))
                {
                    sw.WriteLine(Ville);
                }
            }

            public void SupprimerUneVille(string Ville)
            {

                {

                    // Supprime la ville de la liste
                    cityList.Remove(Ville);

                    // Met à jour la source de la ComboBox avec la liste mise à jour
                    mainwindow.Cb_Ville.ItemsSource = cityList;
                    mainwindow.Cb_Ville.Items.Refresh(); // Rafraîchit la ComboBox

                    // Efface le contenu de la TextBox Tb_Ajouter
                    mainwindow.Tb_Ajouter.Text = "";

                    // Supprime la ville du fichier Ville.txt
                    string chemin = @"ListeVille\Ville.txt"; // Spécifiez le chemin complet du fichier
                    var lines = File.ReadAllLines(chemin);
                    File.WriteAllLines(chemin, lines.Where(line => line != Ville).ToArray());

                }

            }

            // Méthode qui permet d'initialiser la ComboBox
            public void InitializeComboBox()
            {
                // Lire le fichier Ville.txt
                string[] lines = File.ReadAllLines(chemin);

                // Ajouter les villes du fichier Ville.txt à la liste des villes
                foreach (string line in lines)
                {
                    cityList.Add(line);
                }

                // Associer la liste des villes à la ComboBox
                mainwindow.Cb_Ville.ItemsSource = cityList;
            }


        }
    }

