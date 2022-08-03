using PowerLineTest.CarModels.Domain;

namespace PowerLineTest.CarModels
{
    public class ConcreteSportCar : Car
    {
        public ConcreteSportCar(double TankFuelCapacity, double AverageFuelExpend, int AccelerationSpeed) 
            : base(TankFuelCapacity, AverageFuelExpend, AccelerationSpeed) { }
    }
}
