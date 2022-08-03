using PowerLineTest.CarModels.Composition;

namespace PowerLineTest.CarModels.Domain
{
    /// <summary>
    /// Легковой автомобиль. Возможна перевозка пассажиров.
    /// </summary>
    public abstract class PassengerСar : Car
    {
        private List<Passenger> passengers = new();

        public int MaximumPassengers { get; protected set; } = 4;

        protected PassengerСar(double TankFuelCapacity, double AverageFuelExpend, int AccelerationSpeed) 
            : base(TankFuelCapacity, AverageFuelExpend, AccelerationSpeed) { }
        
        protected PassengerСar(double TankFuelCapacity, double AverageFuelExpend, int AccelerationSpeed, int MaximumPassengers) 
            : base(TankFuelCapacity, AverageFuelExpend, AccelerationSpeed) { this.MaximumPassengers = MaximumPassengers; }

        public override sealed double AverageFuelExpend
        {
            get
            {
                var tmpAverageFuelExpend = averageFuelExpend;

                foreach (var passenger in passengers) tmpAverageFuelExpend /= 0.94;

                return tmpAverageFuelExpend;
            }
            protected set { averageFuelExpend = value; }
        }

        public double GetDistanceFullTankWithPassengers() => GetDistanceFullTankWithContent();
        public double GetDistanceCurrentTankWithPassengers() => GetDistanceCurrentTankWithContent();

        public void AddPassenger(Passenger passenger) { if (passengers.Count != MaximumPassengers) passengers.Add(passenger); }
        public void RemovePassenger(Passenger passenger) => passengers.Remove(passenger);
        public void RemoveAllPassengers() => passengers.Clear();

        public List<Passenger> GetPassengers() => passengers;
    }
}
