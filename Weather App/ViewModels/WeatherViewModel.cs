using Autofac;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using Weather.Commands;
using Weather.Interfaces;
using Weather.Models;

namespace Weather.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private readonly IAccuWeatherService _accuWeatherService;

        public WeatherViewModel()
        {
            SearchCommand = new SearchCommand(this);
            Cities = new ObservableCollection<City>();

            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                _accuWeatherService = App.IocContainer.Resolve<IAccuWeatherService>();
                return;
            }

            City = new City {Name = "Evansville"};
            CurrentConditions = new CurrentConditions
            {
                WeatherText = "Bipolar",
                Temperature = new Temperature
                {
                    Metric = new TemperatureUnit { Value = "21" },
                    Imperial = new TemperatureUnit { Value = "21" }
                }
            };
        }

        private string _query;

        public string Query
        {
            get => _query;
            set
            {
                _query = value;
                OnPropertyChanged(nameof(Query));
            }
        }

        private CurrentConditions _currentConditions;

        public CurrentConditions CurrentConditions
        {
            get => _currentConditions;
            set
            {
                _currentConditions = value;
                OnPropertyChanged(nameof(CurrentConditions));
            }
        }

        private City _city;

        public City City
        {
            get => _city;
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
                GetCurrentConditions();
            }
        }

       
        public ObservableCollection<City> Cities { get; set; }

        public SearchCommand SearchCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async void QueryCities()
        {
            Cities.Clear();

            var cities = (await _accuWeatherService.GetCitiesAutoComplete(Query));
            
            foreach (var city in cities) Cities.Add(city);
        }

        private async void GetCurrentConditions()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject())) return;
            Query = string.Empty;
            //Cities.Clear();
            CurrentConditions = await _accuWeatherService.GetCurrentConditions(City.Key);
        }

    }
}
