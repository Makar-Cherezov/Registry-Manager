using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using RegistryManagerClient.Models.ViewModelObjects;
using RegistryManagerClient.Services;
using RegistryManagerClient.Models.Entities;
using RegistryManagerClient.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ObjectiveC;
using System.Text;
using System.Threading.Tasks;

namespace RegistryManagerClient.ViewModels
{
    public partial class CalculatorViewModel : ObservableRecipient
    {
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
        [ObservableProperty]
        private ClientVM _client;

        [ObservableProperty]
        private float _totalCost;
        [ObservableProperty]
        private float _cargoCost;
        public CalculatorViewModel() 
        {
            WeakReferenceMessenger.Default.Register<CargoSelectedMessage>(this, (r, message) =>
            {
                //Cargo = message.SelectedCargo;
                //Client = Cargo.SenderClientVM;
                InitializeViewModel();
            });
            InitializeViewModel();
            
        }
        private void InitializeViewModel()
        {
            UpdateRegistry();
            UpdateCargo();
            UpdateClient();
            CalculateCost();

        }

        private void CalculateCost()
        {
            CargoCost = 0;
            CalculateEntrances();
            CalculateCargoCost();
            TotalCost = CargoCost;
        }

        private void CalculateCargoCost()
        {
            float wprice = 0;
            float vprice = 0;
            foreach (CargoPlaceVM p in Cargo.CargoPlaces)
            {
                wprice += Client.WeightPrice * p.Weight.GetValueOrDefault() * p.PlacesCount;
                vprice += Client.VolumePrice * p.Volume.GetValueOrDefault() * p.PlacesCount;
            }
            CargoCost += Math.Max(wprice, vprice);
        }

        private void CalculateEntrances()
        {
            CargoCost =+ Cargo.EntrancesCount * 250;
        }

        private void UpdateClient()
        {
            Client = StatesService.Instance.GetState<CargoVM>().SenderClientVM;
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
            Cargo = StatesService.Instance.GetState<CargoVM>(); 
        }
        partial void OnCargoChanged(CargoVM value)
        {
            InitializeViewModel();
        }
        [RelayCommand]
        private void OnCtrlRPressed(object sender)
        {
            CalculateCost();
        }
        [RelayCommand]
        private void SaveCargo(object sender)
        {
            ViewModelObjectsService.Instance.SaveCargo(Cargo);
        }
        [RelayCommand]
        private void OnAddCargoPlace(object sender)
        {
            CargoPlaceVM cp = new CargoPlaceVM();
            cp.CargoId = Cargo.CargoId;
            cp.PlaceId = null;
            cp.CategoryId = 0;
            Cargo.CargoPlaces.Add(cp);
            WeakReferenceMessenger.Default.Send(new CargoSelectedMessage(StatesService.Instance.GetState<CargoVM>()));
        }
    }
}
