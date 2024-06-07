using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RegistryManagerClient.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegistryManagerClient.Models.ViewModelObjects;
using RegistryManagerClient.Services;
using CommunityToolkit.Mvvm.Messaging;
using RegistryManagerClient.Services.Messages;

namespace RegistryManagerClient.ViewModels
{
    public partial class HomePageViewModel : ObservableRecipient
    {
        private bool _isInitialized = false;
        [ObservableProperty]
        private List<RegistryViewModel> _registries = new List<RegistryViewModel>();

        [ObservableProperty]
        private RegistryViewModel? _selectedRegistry;

        public HomePageViewModel()
        {
            if (!_isInitialized)
            {
                InitializeViewModel();
            }
        }
        private void InitializeViewModel()
        {
            _isInitialized = true;
            Registries = ViewModelObjectsService.Instance.LoadViewModels<RegistryViewModel, Registry>(includeProperties: new string[] { "Status", "AuthorNavigation" });
        }
        partial void OnSelectedRegistryChanged(RegistryViewModel? value)
        {
            WeakReferenceMessenger.Default.Send(new RegistrySelectedMessage(value));

        }

    }
}
