using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;

namespace Ninject
{
    interface IWeapon
    {
        void Kill();
    }

    class Bazuka : IWeapon
    {
        public void Kill()
        {
            Console.WriteLine("BIG BADABUM!");
        }
    }

    class Sword : IWeapon
    {
        public void Kill()
        {
            Console.WriteLine("Chunk-chunk");
        } 
    }

    class Warior
    {
        readonly IWeapon weapon;

        public Warior(IWeapon weapon)
        {
            this.weapon = weapon;
        }

        public void Kill()
        {
              weapon.Kill();
        }
    }

    class OtherWarrior
    {
        /// <summary>
        /// Метод с получением интерфейса при необходимости обращается 
        /// к сервис локатору и получает его
        /// </summary>
        private IWeapon _weapon;

        public IWeapon Weapon
        {
            get
            {
                if (_weapon == null)
                {
                    _weapon = Program.AppKernel.Get<IWeapon>();
                }
                return _weapon;
            }
        }

        public void Kill()
        {
            Weapon.Kill();
        }
    }

    class AnotherWarrior
    {
        /// <summary>
        /// То же самое с помощью [Inject] при создании класса 
        /// через AppKernel.Get<>
        /// поле инициализируется сервис локатором.
        /// </summary>
        [Inject]
        public IWeapon Weapon { get; set; }

        public void Kill()
        {
            Weapon.Kill();
        } 
    }

    class WeaponNinjectModule : NinjectModule
    {
        /// <summary>
        /// Привязка интерфейса к классу с помощью Ninject 
        /// </summary>
        public override void Load()
        {
            this.Bind<IWeapon>().To<Sword>();
        }
    }
    class Program
    {
        public static IKernel AppKernel; 
        static void Main(string[] args)
        {
            AppKernel= new StandardKernel(new WeaponNinjectModule());
            Warior warior = AppKernel.Get<Warior>();
            warior.Kill();

            OtherWarrior otherWarrior = new OtherWarrior();
            otherWarrior.Kill();

            AnotherWarrior anotherWarrior = AppKernel.Get<AnotherWarrior>();
            anotherWarrior.Kill();

            Console.ReadLine();
        }
    }
}
