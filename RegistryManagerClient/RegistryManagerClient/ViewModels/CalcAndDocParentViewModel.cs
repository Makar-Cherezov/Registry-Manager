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
    public partial class CalcAndDocParentViewModel : ObservableObject
    {
        private bool _isInitialized = false;
        public CalcAndDocParentViewModel(long regID)
        {
            if (!_isInitialized)
            {
                InitializeViewModel();
            }
        }
        private void InitializeViewModel()
        {
            _isInitialized = true;
            
        }
    }
}
