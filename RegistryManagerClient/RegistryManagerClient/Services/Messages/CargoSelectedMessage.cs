using RegistryManagerClient.Models.ViewModelObjects;
using RegistryManagerClient.Services;

public class CargoSelectedMessage
{
    public CargoVM SelectedCargo { get; }

    public CargoSelectedMessage(CargoVM selectedCargo)
    {
        SelectedCargo = selectedCargo;
        StatesService.Instance.SetState(selectedCargo);
    }
}
