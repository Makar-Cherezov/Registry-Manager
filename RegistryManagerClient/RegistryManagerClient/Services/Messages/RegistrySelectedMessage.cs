using RegistryManagerClient.Models.ViewModelObjects;
using RegistryManagerClient.Services;


namespace RegistryManagerClient.Services.Messages
{
    public class RegistrySelectedMessage
    {
        public RegistryViewModel SelectedRegistry { get; }
        public RegistrySelectedMessage (RegistryViewModel selectedRegistry)
        {
            SelectedRegistry = selectedRegistry;
            StatesService.Instance.SetState(selectedRegistry);
        }
    }
}