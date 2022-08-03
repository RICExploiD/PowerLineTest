namespace PowerLineTest.CarModels.Domain.Interfaces
{
    /// <summary>
    /// Интерфейс обеспечивающий доступ к основным показателям и фукнциям автомобиля.
    /// </summary>
    public interface ICar
    {
        /// <summary>
        /// Текущая скорость автомобиля.
        /// </summary>
        int CurrentSpeed { get; }
        
        /// <summary>
        /// Скорость ускорения автомобиля.
        /// </summary>
        int AccelerationSpeed { get; }


        /// <summary>
        /// Показатель текущего уровня топлива в баке автомобиля.
        /// </summary>
        double TankFuelLevel { get; }

        /// <summary>
        /// Объем топливного бака автомобиля.
        /// </summary>
        double TankFuelCapacity { get; }

        /// <summary>
        /// Расход топлива автомобилем - литры разделенные на у.е расстояния.
        /// </summary>
        double AverageFuelExpend { get; }

        /// <summary>
        /// Действие движения автомобиля с текущей скоростью.
        /// </summary>
        void Move();

        /// <summary>
        /// Действие обеспечивающее начало движения автомобиля.
        /// </summary>
        void StartMove();

        /// <summary>
        /// Действие обеспечивающее окончание движения автомобиля.
        /// </summary>
        void StopMove();


        /// <summary>
        /// Действие движения автомобиля с увеличением скорости.
        /// </summary>
        void IncreaseSpeed();

        /// <summary>
        /// Действие движения автомобиля с уменьшением скорости.
        /// </summary>
        void DecreaseSpeed();


        /// <summary>
        /// Событие расхода топлива.
        /// </summary>
        void FuelConsumption();

        /// <summary>
        /// Действие пополнения бака топливом.
        /// </summary>
        /// <param name="fuelQty">
        /// Количество наполняемого топлива.
        /// </param>
        void FillFuelTank(double fuelQty);

        /// <summary>
        /// Расчет расстояния с текущей скоростью и расходом топлива при полном баке.
        /// </summary>
        /// <returns>Ожидаемое расстояние при полном баке.</returns>
        double GetDistanceFullTank();

        /// <summary>
        /// Расчет расстояния с текущей скоростью и расходом топлива при текущем уровне топлива в баке.
        /// </summary>
        /// <returns>Ожидаемое расстояние при текущем уровне топлива баке.</returns>
        double GetDistanceCurrentTank();

        /// <summary>
        /// Расчет времени в условных единицах (у.е.) необходимое для прохождения указаного расстояния с текущей скоростью.
        /// </summary>
        /// <returns>
        /// Время в у.е необходимое для преодоления указанного расстояния. 
        /// При невозможном преодолении указанного расстояния возвращает -1.
        /// </returns>
        double GetRoadTime(double distance);
    }
}