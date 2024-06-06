using RegistryManagerClient.Models.ViewModelObjects;

public class CargoSelectedMessage
{
    public CargoVM SelectedCargo { get; }

    public CargoSelectedMessage(CargoVM selectedCargo)
    {
        SelectedCargo = selectedCargo;
    }
}
