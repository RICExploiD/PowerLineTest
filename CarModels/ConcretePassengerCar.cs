using PowerLineTest.CarModels.Domain;

namespace PowerLineTest.CarModels
{
    public class ConcretePassengerCar : PassengerСar
    {
        public ConcretePassengerCar(double TankFuelCapacity, double AverageFuelExpend, int AccelerationSpeed) 
            : base(TankFuelCapacity, AverageFuelExpend, AccelerationSpeed) { }

        public ConcretePassengerCar(double TankFuelCapacity, double AverageFuelExpend, int AccelerationSpeed, int MaximumPassengers) 
            : base(TankFuelCapacity, AverageFuelExpend, AccelerationSpeed, MaximumPassengers) { }
    }
}