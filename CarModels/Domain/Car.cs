namespace PowerLineTest.CarModels.Domain;

using PowerLineTest.CarModels.Domain.Interfaces;

/// <summary>
/// Абстрактный класс автомобиля. Реализует основную логику выполнения объекта.
/// </summary>
public abstract class Car : ICar
{
    private bool isMoving;
    private double tankFuelLevel;
    private int currentSpeed;
    private int accelerationSpeed;

    protected double averageFuelExpend;

    protected Car(double tankFuelCapacity, double averageFuelExpend, int accelerationSpeed)
    {
        TankFuelCapacity = tankFuelCapacity;
        AverageFuelExpend = averageFuelExpend;
        AccelerationSpeed = accelerationSpeed;
    }

    public int CurrentSpeed 
    {
        get => currentSpeed; 
        protected set 
        { 
            if (value < 0) 
                return;

            currentSpeed = value; 
            isMoving = value > 0; 
        }
    }

    public double TankFuelLevel
    {
        get => tankFuelLevel; 
        protected set => tankFuelLevel = value > TankFuelCapacity 
            ? TankFuelCapacity 
            : value <= 0 
                ? 0 
                : value; 
    }

    public virtual int AccelerationSpeed
    {
        get => accelerationSpeed; 
        protected set => accelerationSpeed = value; 
    }

    public virtual double AverageFuelExpend 
    {
        get => averageFuelExpend; 
        protected set => averageFuelExpend = value; 
    }

    public double TankFuelCapacity { get; }

    public void Move() 
    { 
        if (!isMoving) 
            return;
            
        FuelConsumption(); 
        
        if (IsFuelEnough()) 
            return;
        
        StopMove(); 
    }

    public void StopMove() 
    { 
        while (currentSpeed != 0) 
            currentSpeed--; 
        
        isMoving = false; 
    }
    public void StartMove() => isMoving = tankFuelLevel > accelerationSpeed / 100 * averageFuelExpend; 

    public void IncreaseSpeed()
    { 
        if (isMoving) 
            ChangeSpeed(true);
    }
    private void ChangeSpeed(bool isIncrease)
    {
        CurrentSpeed += AccelerationSpeed * (isIncrease ? 1 : -1);
        Move(); 
    }
    public void DecreaseSpeed() 
    { 
        if (isMoving) 
            ChangeSpeed(false);
    }

    public void FuelConsumption() => tankFuelLevel -= AverageFuelExpend * currentSpeed / 100; 

    public void FillFuelTank(double fuelQty) => TankFuelLevel += fuelQty > 0 ? fuelQty : 0;

    public double GetRoadTime(double distance) => (!isMoving) 
        ? -1 
        : IsFuelEnough((int)distance / currentSpeed) 
            ? Math.Ceiling(distance / currentSpeed) 
            : -1;

    public double GetDistanceFullTank() => TankFuelCapacity / averageFuelExpend * 100;
    public double GetDistanceCurrentTank() => tankFuelLevel / averageFuelExpend * 100;

    /// <returns>
    /// Оставшееся расстояние при наполненом автомобиле и полном топливном баке.
    /// </returns>
    protected double GetDistanceFullTankWithContent() => TankFuelCapacity / AverageFuelExpend * 100;
    /// <returns>
    /// Оставшееся расстояние при наполненом автомобиле и полном топливном баке.
    /// </returns>
    protected double GetDistanceCurrentTankWithContent() => tankFuelLevel / AverageFuelExpend * 100;

    /// <returns>
    /// Является ли текущий уровень топлива достаточным для работы автомобиля на протяжении указанного времени,
    /// если истино - True в ином случае - False
    /// </returns>
    private bool IsFuelEnough(int time = 1) => currentSpeed / 100 * AverageFuelExpend * time <= tankFuelLevel;

}
