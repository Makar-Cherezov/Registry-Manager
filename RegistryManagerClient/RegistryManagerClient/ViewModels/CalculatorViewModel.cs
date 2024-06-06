using CommunityToolkit.Mvvm.ComponentModel;
using RegistryManagerClient.Models.ViewModelObjects;
using RegistryManagerClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryManagerClient.ViewModels
{
    public partial class CalculatorViewModel : ObservableObject
    {
        private bool _isInitialized = false;
        [ObservableProperty]
        private string _targetCity;
        [ObservableProperty]
        private string _transport;
        [ObservableProperty]
        private DateOnly _shippingDate;
        [ObservableProperty]
        private DateOnly _arrivalDate;
        [ObservableProperty]
        private bool _isCombined;
        [ObservableProperty]
        private string _status;
        [ObservableProperty]
        private CargoVM _cargo;
        public CalculatorViewModel() 
        {
            if (!_isInitialized)
            {
                InitializeViewModel();
            }
        }
        private void InitializeViewModel()
        {
            _isInitialized = true;
            UpdateRegistry();
            UpdateCargo();

        }
        private void UpdateRegistry()
        {
            FullRegistryVM reg = StatesService.Instance.GetState<FullRegistryVM>();
            TargetCity = reg.TargetCity;
            Transport = reg.ContainerCode;
            ShippingDate = (DateOnly)reg.ShippingDate;
            ArrivalDate = (DateOnly)reg.ArrivalDate;
            IsCombined = reg.IsCombined;
            Status = reg.Status;
        }

        private void UpdateCargo()
        {
            Cargo = StatesService.Instance.GetState<CargoVM>(); ;
        }
    }
}
