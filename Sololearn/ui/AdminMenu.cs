using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sololearn.ui
{
    internal static class AdminMenu
    {
        internal static void Menu()
        {
            Console.WriteLine("1. My profile");
            Console.WriteLine("2. Course Menu");
            Console.WriteLine("3. Module Menu");
            Console.WriteLine("4. Lesson Menu");

            int chosen = int.Parse(Console.ReadLine());

            switch (chosen)
            {
                case 1: Me(); break;
                case 2: CourseMenu(); break;
                case 3: ModuleMenu(); break;
                case 4: LessonMenu(); break;
            }

        }

        private static void LessonMenu()
        {
            throw new NotImplementedException();
        }

        private static void ModuleMenu()
        {
            throw new NotImplementedException();
        }

        private static void CourseMenu()
        {
            throw new NotImplementedException();
        }

        private static void Me()
        {

        }
    }
}
