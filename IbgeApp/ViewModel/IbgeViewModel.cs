using IbgeApp.Commands;
using IbgeApp.Interfaces;
using IbgeApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace IbgeApp.ViewModel
{
    public class IbgeViewModel : INotifyPropertyChanged
    {
        // Variáveis globais
        private readonly IIbgeService _ibgeService;
        private ObservableCollection<Locality> _localities;
        private string _searchCity;
        private string _searchState;
        private int _searchId;

        // Construtor
        public IbgeViewModel(IIbgeService ibgeService)
        {
            _ibgeService = ibgeService;
            LoadLocalitiesCommand = new RelayCommand(async () => await LoadLocalities());
            SearchCommand = new RelayCommand(async () => await Search());
            ImportExcelDataCommand = new RelayCommand(async () => await ImportExcelData());
        }

        // Propriedades
        public ObservableCollection<Locality> Localities
        {
            get => _localities;
            set
            {
                _localities = value;
                OnPropertyChanged(nameof(Localities));
            }
        }

        public string SearchCity
        {
            get => _searchCity;
            set
            {
                _searchCity = value;
                OnPropertyChanged(nameof(SearchCity));
            }
        }

        public string SearchState
        {
            get => _searchState;
            set
            {
                _searchState = value;
                OnPropertyChanged(nameof(SearchState));
            }
        }

        public int SearchId
        {
            get => _searchId;
            set
            {
                _searchId = value;
                OnPropertyChanged(nameof(SearchId));
            }
        }

        // Comandos

        public ICommand LoadLocalitiesCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand ImportExcelDataCommand { get; }

        private async Task LoadLocalities()
        {
            return;
        }

        private async Task Search()
        {
            return;
        }

        private async Task ImportExcelData()
        {
            return;
        }

        // Implementação do INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
