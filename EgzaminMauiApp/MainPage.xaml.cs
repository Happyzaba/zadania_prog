﻿namespace EgzaminMauiApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new EgzaminViewModel();
        }

    }

}
