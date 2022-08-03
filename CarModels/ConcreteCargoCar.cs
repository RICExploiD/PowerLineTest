using PowerLineTest.CarModels.Domain;

namespace PowerLineTest.CarModels
{
    public class ConcreteCargoCar : CargoCar
    {
        public ConcreteCargoCar(double TankFuelCapacity, double AverageFuelExpend, int AccelerationSpeed)
            : base(TankFuelCapacity, AverageFuelExpend, AccelerationSpeed) { }

        public ConcreteCargoCar(double TankFuelCapacity, double AverageFuelExpend, int AccelerationSpeed, int MaximumCargos)
            : base(TankFuelCapacity, AverageFuelExpend, AccelerationSpeed, MaximumCargos) { }
    }
}
