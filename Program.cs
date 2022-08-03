using PowerLineTest.CarModels;
using PowerLineTest.CarModels.Composition;
using PowerLineTest.CarModels.Domain;
using PowerLineTest.CarModels.Domain.Interfaces;

Console.WriteLine("-=-=-=-= Program starts =-=-=-=-=-");

var passCar = new ConcretePassengerCar(20d, 7d, 3);

var roadTimeStart = passCar.GetRoadTime(50);

passCar.FillFuelTank(20);

var counter = 4;

passCar.AddPassenger(new Passenger());
passCar.AddPassenger(new Passenger());

passCar.StartMove();

for (var i = 0; i != counter; i++)
{
    Console.WriteLine("------------Speed inc change---------------");
    passCar.IncreaseSpeed();
    Console.WriteLine(passCar.CurrentSpeed + "\t км\\ч");
    Console.WriteLine(String.Format("{0:f2}", passCar.GetDistanceCurrentTank()) + "\t км в остатке");
    Console.WriteLine(String.Format("{0:f2}", passCar.GetDistanceCurrentTankWithPassengers()) + "\t км в остатке c наполнением");
    Console.WriteLine(String.Format("{0:f2}", passCar.TankFuelLevel) + $"\t литров в баке. Расход {passCar.AverageFuelExpend} л");
}

var roadTimeStop = passCar.GetRoadTime(50);

passCar.StopMove();

Console.WriteLine("------------Speed inc change---------------");
passCar.IncreaseSpeed();
Console.WriteLine(passCar.CurrentSpeed + "\t км\\ч");
Console.WriteLine(String.Format("{0:f2}", passCar.GetDistanceCurrentTank()) + "\t км в остатке");
Console.WriteLine(String.Format("{0:f2}", (passCar as PassengerСar).GetDistanceCurrentTankWithPassengers()) + "\t км в остатке c наполнением");
Console.WriteLine(String.Format("{0:f2}", passCar.TankFuelLevel) + $"\t литров в баке. Расход {passCar.AverageFuelExpend} л");


Console.ReadKey();