namespace PowerLineTest.CarModels.Domain;

using PowerLineTest.CarModels.Composition;

/// <summary>
/// Грузовой автомобиль. Доступна перевозка грузов.
/// </summary>
public abstract class CargoCar : Car
{
    private List<Cargo> cargos = new();

    public double MaximumCargos { get; protected set; } = 500d;

    protected CargoCar(double tankFuelCapacity, double averageFuelExpend, int accelerationSpeed) 
        : base(tankFuelCapacity, averageFuelExpend, accelerationSpeed) { }

    protected CargoCar(double tankFuelCapacity, double averageFuelExpend, int accelerationSpeed, double maximumCargos) 
        : base(tankFuelCapacity, averageFuelExpend, accelerationSpeed) => MaximumCargos = maximumCargos;

    public override sealed double AverageFuelExpend
    {
        get
        {
            var pow = (int)cargos.Sum(x => x.Weight) / 200;
            return averageFuelExpend * Math.Pow(0.96, pow);
        }
        protected set => averageFuelExpend = value;
    }

    public double GetDistanceFullTankWithCargos() => GetDistanceFullTankWithContent();
    public double GetDistanceCurrentTankWithCargos() => GetDistanceCurrentTankWithContent();

    public void AddCargo(Cargo cargo) 
    { 
        if (cargos.Sum(x => x.Weight) + cargo.Weight <= MaximumCargos) 
            cargos.Add(cargo); 
    }
    public void RemoveCargo(Cargo cargo) => cargos.Remove(cargo);
    public void RemoveAllCargos() => cargos.Clear();

    public List<Cargo> GetCargos() => cargos;
}
