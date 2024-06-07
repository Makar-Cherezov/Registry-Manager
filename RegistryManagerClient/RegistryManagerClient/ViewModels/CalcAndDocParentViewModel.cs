using CommunityToolkit.Mvvm.ComponentModel;
using RegistryManagerClient.Models.ViewModelObjects;
using RegistryManagerClient.Models.Entities;
using RegistryManagerClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Messaging;
using RegistryManagerClient.Services.Messages;

namespace RegistryManagerClient.ViewModels
{
    public partial class CalcAndDocParentViewModel : ObservableRecipient
    {
        private bool _isInitialized = false;
        [ObservableProperty]
        private FullRegistryVM _registry;
        [ObservableProperty]
        private int _selectedCargoIndex;
        [ObservableProperty]
        private List<CargoVM> _cargos;
        [ObservableProperty]
        private string _clientNotes;
        [ObservableProperty]
        private string _cargoNotes;
        public CalcAndDocParentViewModel()
        {
            WeakReferenceMessenger.Default.Register<RegistrySelectedMessage>(this, (r, message) =>
            {
                InitializeViewModel();
            });
            if (!_isInitialized)
            {
                InitializeViewModel();
            }
        }
        private void InitializeViewModel()
        {
            try
            {
                _isInitialized = true;
            SelectedCargoIndex = 0;
            RegistryViewModel reg = StatesService.Instance.GetState<RegistryViewModel>();
                if (reg != null)
                {
                    StatesService.Instance.SetState<FullRegistryVM>(FullRegistryVM.FindByKey(reg.RegistryId));
                    Registry = StatesService.Instance.GetState<FullRegistryVM>();
                    Cargos = Registry.Cargos;
                    UpdateNotes();
                    UpdateCargo();
                }
            }
            catch (Exception ex) { }
        }

        private void UpdateCargo()
        {
            if (SelectedCargoIndex < 0)
                SelectedCargoIndex = 0;
            StatesService.Instance.SetState<CargoVM>(Registry.Cargos[SelectedCargoIndex]);
        }

        partial void OnSelectedCargoIndexChanged(int value)
        {
            UpdateNotes();
            UpdateCargo();
            WeakReferenceMessenger.Default.Send(new CargoSelectedMessage(StatesService.Instance.GetState<CargoVM>()));
        }
        private void UpdateNotes()
        {
            if (SelectedCargoIndex >= 0 && SelectedCargoIndex < Cargos.Count)
            {
                CargoNotes = Cargos[SelectedCargoIndex].Notes;
                ClientNotes = Cargos[SelectedCargoIndex].SenderClientVM.Notes;
            }
            else
            {
                CargoNotes = string.Empty;
                ClientNotes = string.Empty;
            }
        }

    }
}
