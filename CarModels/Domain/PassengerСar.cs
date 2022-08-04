namespace PowerLineTest.CarModels.Domain;

using PowerLineTest.CarModels.Composition;

/// <summary>
/// Легковой автомобиль. Возможна перевозка пассажиров.
/// </summary>
public abstract class PassengerСar : Car
{
    private List<Passenger> passengers = new();

    public int MaximumPassengers { get; protected set; } = 4;

    protected PassengerСar(double tankFuelCapacity, double averageFuelExpend, int accelerationSpeed) 
        : base(tankFuelCapacity, averageFuelExpend, accelerationSpeed) { }

    protected PassengerСar(double tankFuelCapacity, double averageFuelExpend, int accelerationSpeed, int maximumPassengers) 
        : base(tankFuelCapacity, averageFuelExpend, accelerationSpeed) => MaximumPassengers = maximumPassengers;

    public override sealed double AverageFuelExpend
    {
        get => averageFuelExpend * Math.Pow(0.94, passengers.Count());
        protected set => averageFuelExpend = value;
    }

    public double GetDistanceFullTankWithPassengers() => GetDistanceFullTankWithContent();
    public double GetDistanceCurrentTankWithPassengers() => GetDistanceCurrentTankWithContent();

    public void AddPassenger(Passenger passenger) 
    { 
        if (passengers.Count != MaximumPassengers) 
            passengers.Add(passenger); 
    }
    
    public void RemovePassenger(Passenger passenger) => passengers.Remove(passenger);
    public void RemoveAllPassengers() => passengers.Clear();

    public List<Passenger> GetPassengers() => passengers;
}
