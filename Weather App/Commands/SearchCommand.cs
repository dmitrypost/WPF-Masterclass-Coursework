using System;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows.Input;
using Weather.ViewModels;

namespace Weather.Commands
{
    public class SearchCommand : ICommand
    {
        public WeatherViewModel WeatherViewModel { get; set; }

        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public SearchCommand(WeatherViewModel viewModel)
        {
            WeatherViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            if (!(parameter is string queryParameter)) return false;
            return !string.IsNullOrWhiteSpace(queryParameter);
        }

        public void Execute(object parameter)
        {
            WeatherViewModel.QueryCities();
        }

        
    }
}
