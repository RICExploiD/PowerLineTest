namespace PowerLineTest.Services
{
    public enum TypeCar
    {
        Passenger,
        Cargo,
        Sport
    }
    class Program
    {
        static void Main(string[] args)
        {
            Hero elf = new Hero(new ElfFactory());
            elf.Hit();
            elf.Run();

            Hero voin = new Hero(new VoinFactory());
            voin.Hit();
            voin.Run();

            Console.ReadLine();
        }
    }
    abstract class Weapon { public abstract void Hit(); }
    abstract class Movement { public abstract void Move(); }

    class Arbalet : Weapon { public override void Hit() { Console.WriteLine("Стреляем из арбалета"); } }
    class Sword : Weapon { public override void Hit() { Console.WriteLine("Бьем мечом"); } }

    class FlyMovement : Movement { public override void Move() { Console.WriteLine("Летим"); } }
    class RunMovement : Movement { public override void Move() { Console.WriteLine("Бежим"); } }

    abstract class HeroFactory { public abstract Movement CreateMovement(); public abstract Weapon CreateWeapon(); }

    class ElfFactory : HeroFactory
    {
        public override Movement CreateMovement() { return new FlyMovement(); }
        public override Weapon CreateWeapon() { return new Arbalet(); }
    }

    class VoinFactory : HeroFactory
    {
        public override Movement CreateMovement() { return new RunMovement(); }
        public override Weapon CreateWeapon() { return new Sword(); }
    }

    class Hero
    {
        private Weapon weapon; private Movement movement;

        public Hero(HeroFactory factory)
        {
            weapon = factory.CreateWeapon();
            movement = factory.CreateMovement();
        }
        public void Run() { movement.Move(); }
        public void Hit() { weapon.Hit(); }
    }


























    class sProgram
    {
        static void Main(string[] args)
        {
            Developer dev = new PanelDeveloper("ООО КирпичСтрой");
            House house2 = dev.Create();

            dev = new WoodDeveloper("Частный застройщик");
            House house = dev.Create();

            Console.ReadLine();
        }
    }
    // абстрактный класс строительной компании
    abstract class Developer
    {
        public string Name { get; set; }

        public Developer(string n) { Name = n; }

        abstract public House Create();
    }
    class PanelDeveloper : Developer
    {
        public PanelDeveloper(string n) : base(n) { }

        public override House Create() { return new PanelHouse(); }
    }
    class WoodDeveloper : Developer
    {
        public WoodDeveloper(string n) : base(n) { }

        public override House Create() { return new WoodHouse(); }
    }

    abstract class House { }

    class PanelHouse : House { public PanelHouse() { Console.WriteLine("Панельный дом построен"); } }
    class WoodHouse : House
    {
        public WoodHouse() { Console.WriteLine("Деревянный дом построен"); }

    }
}
