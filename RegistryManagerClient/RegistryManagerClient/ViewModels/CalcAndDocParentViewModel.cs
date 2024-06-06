using CommunityToolkit.Mvvm.ComponentModel;
using RegistryManagerClient.Models.ViewModelObjects;
using RegistryManagerClient.Models.Entities;
using RegistryManagerClient.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegistryManagerClient.ViewModels
{
    public partial class CalcAndDocParentViewModel : ObservableObject
    {
        private bool _isInitialized = false;
        [ObservableProperty]
        private FullRegistryVM _registry;
        [ObservableProperty]
        private int _selectedCargo;

        
        public CalcAndDocParentViewModel(long regID)
        {
            if (!_isInitialized)
            {
                InitializeViewModel(regID);
            }
        }
        private void InitializeViewModel(long regID)
        {
            _isInitialized = true;
            SelectedCargo = 0;
            Registry = FullRegistryVM.FindByKey(regID);
        }

    }
}
