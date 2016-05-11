using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

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

    class OtherWarrior
    {
        IWeapon _weapon;

        public IWeapon Weapon
        {
            get
            {
                if (_weapon == null)
                {
                    _weapon = ServiceLocator.Current.GetInstance<IWeapon>();
                }
                return _weapon;
            }
        }

        public void Kill()
        {
            Weapon.Kill();
        }
    }

    class Program
    {
        public static IUnityContainer Container;
        static void Main(string[] args)
        {
            // Инициализация сервиса локатора(Container)
            Container = new UnityContainer();
            // Регистрация типа 
            Container.RegisterType(typeof (IWeapon), typeof (Bazuka));
            // Получение объекта и использование:
            var warrior = Container.Resolve<Warrior>();
            warrior.Kill();

            //Кроме того, у Unity есть класс-одиночка (Singleton) ServiceLocator, 
            //который регистрирует контейнер и позволяет получить доступ к сервисам из любого места.
            var serviceProvider = new UnityServiceLocator(Container);
            ServiceLocator.SetLocatorProvider(() => serviceProvider);

            // Получение объекта и использование:
            OtherWarrior otherWarrior = new OtherWarrior();
            otherWarrior.Kill();

            Console.ReadLine();
        }
    }
}
