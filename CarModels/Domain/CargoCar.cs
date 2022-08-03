using PowerLineTest.CarModels.Composition;

namespace PowerLineTest.CarModels.Domain
{
    /// <summary>
    /// Грузовой автомобиль. Доступна перевозка грузов.
    /// </summary>
    public abstract class CargoCar : Car
    {
        private List<Cargo> cargos = new();

        public double MaximumCargos { get; protected set; } = 500d;

        protected CargoCar(double TankFuelCapacity, double AverageFuelExpend, int AccelerationSpeed) 
            : base(TankFuelCapacity, AverageFuelExpend, AccelerationSpeed) { }

        protected CargoCar(double TankFuelCapacity, double AverageFuelExpend, int AccelerationSpeed, double MaximumCargos) 
            : base(TankFuelCapacity, AverageFuelExpend, AccelerationSpeed) { this.MaximumCargos = MaximumCargos; }

        public override sealed double AverageFuelExpend
        {
            get
            {
                var tmpAverageFuelExpend = averageFuelExpend;

                for (var i = 0; i != (int)cargos.Sum(x => x.Weight) / 200; i++) tmpAverageFuelExpend /= 0.96;

                return tmpAverageFuelExpend;
            }
            protected set { averageFuelExpend = value; }
        }

        public double GetDistanceFullTankWithCargos() => GetDistanceFullTankWithContent();
        public double GetDistanceCurrentTankWithCargos() => GetDistanceCurrentTankWithContent();

        public void AddCargo(Cargo cargo) { if (cargos.Sum(x => x.Weight) + cargo.Weight <= MaximumCargos) cargos.Add(cargo); }
        public void RemoveCargo(Cargo cargo) => cargos.Remove(cargo);
        public void RemoveAllCargos() => cargos.Clear();

        public List<Cargo> GetCargos() => cargos;
    }
}
