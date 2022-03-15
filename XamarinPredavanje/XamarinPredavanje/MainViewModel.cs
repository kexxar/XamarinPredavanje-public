﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace XamarinPredavanje
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private string _labelText;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel()
        {
            LabelText = "Hello from ViewModel";
            ButtonClickCommand = new Command(OnButtonClicked);
            NumericClickCommand = new Command<int>(OnNumberClicked);
            Numeric2ClickCommand = new Command<int>(OnNumberClicked);
        }

        private void OnNumberClicked(int number)
        {
            LabelText = $"{number} + 1 = {number + 1}";
        }

        private void OnButtonClicked()
        {
            LabelText = "Hello from the other side";
        }

        public string LabelText
        {
            get => _labelText;
            set
            {
                _labelText = value;
                PropertyChanged?.Invoke(
                    this, 
                    new PropertyChangedEventArgs(nameof(LabelText)));
            }
        }

        public ICommand ButtonClickCommand { get; }

        public ICommand NumericClickCommand { get; }
        public ICommand Numeric2ClickCommand { get; }
    }
}
