using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EgzaminMauiApp
{
    internal class EgzaminViewModel : BindableObject
    {
        private Random losowanie = new Random();

        private int wynikGry;
        public int WynikGry
        {
            get { return wynikGry; }
            set
            {
                wynikGry = value;
                OnPropertChanged();
            }
        }

        private int wynikLosowania;
        public int WynikLosowania
        {
            get { return wynikLosowania; }
            set
            {
                wynikLosowania = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<string> Kosci { get; set; }

        public Command RzucKosciamiCommand { get; }
        public Command ResetWynikuCommand { get; }

        public EgzaminViewModel()
        {
            Kosci = new ObservableCollection<string> { "question.jpg", "question.jpg", "question.jpg", "question.jpg", "question.jpg" };

            RzucKosciamiCommand = new Command(RzucKosciami);
            ResetWynikuCommand = new Command(ResetWyniku);
        }
        private void RzucKosciami()
        {
            int wynikLosowania = 0;
            for (int i = 0; i < Kosci.Count; i++)
            {
                int wartoscKosci = losowanie.Next(1, 7);
                Kosci[i] = $"k{wartoscKosci}.jpg";
                wynikLosowania += wynikLosowania;
            }
            WynikLosowania = wynikLosowania;
            WynikGry += wynikLosowania;
        }
        private void ResetWyniku()
        {
            for (int i = 0; i < Kosci.Count; i++)
            {
                Kosci[1] = "question.jpg";
            }
            WynikGry = 0;
            WynikLosowania = 0;
        }
    }
}
