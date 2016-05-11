using System;
using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Unity
{
    public interface IWeapon
    {
        void Kill();
    }
    public class Bazuka : IWeapon
    {
        public void Kill()
        {
            Console.WriteLine("BIG BADABUM!");
        }
    }
    public class Sword : IWeapon
    {
        public void Kill()
        {
            Console.WriteLine("Chuk-chuck");
        }
    }
    public class Warrior
    {
        readonly IWeapon _weapon;

        public Warrior(IWeapon weapon)
        {
            this._weapon = weapon;
        }

        public void Kill()
        {
            _weapon.Kill();
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            // Инициализация сервиса локатора(Container)
            var container = new WindsorContainer();
            // Регистрация типов. Надо зарегистрировать все необходимые классы,
            // потому что создание экземпляров незарегистрированных классов тут не реализован.
            container.Register(Component.For<IWeapon>().ImplementedBy<Bazuka>(),
            Component.For<Warrior>().ImplementedBy<Warrior>());
            // Получение объекта и использование:
            var warrior = container.Resolve<Warrior>();
            warrior.Kill();
            Console.ReadLine();
        }
    }
}

