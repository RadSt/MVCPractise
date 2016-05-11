using System;
using Autofac;
using Autofac.Core;

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
            var builder = new ContainerBuilder();
            // Регистрация типов. Надо зарегистрировать все необходимые классы,
            // потому что создание экземпляров незарегистрированных классов тут не реализован.
            builder.RegisterType<Bazuka>();
            builder.RegisterType<Warrior>();
            builder.Register<IWeapon>(x => x.Resolve<Bazuka>());
            //Создание сервиса локатора (Container)
            var container = builder.Build();
            // Получение объекта и использование:
            var warrior = container.Resolve<Warrior>();
            warrior.Kill();
            Console.ReadLine();
        }
    }
}

