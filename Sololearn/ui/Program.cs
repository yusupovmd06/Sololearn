using Sololearn.entity;
using SoloLearn.payload;
using Sololearn.service.contract;
using Sololearn.service.impls;
using Sololearn.ui;
using Sololearn.utils;

namespace Sololearn
{
    public class Program
    {
        private static readonly IAuthService authService = new AuthService();

        public static void Main(string[] args)
        {
            Answer answer = new Answer();
            
            Console.WriteLine("welcome to the sololearn");
            if (ContextHolder.CurrentUser == null)
            {
                Console.WriteLine("1. register");
                Console.WriteLine("2. sign in");
            }
            else
                Console.WriteLine("3. sign out");

            int chosen = int.Parse(Console.ReadLine());

            switch (chosen)
            {
                case 1: Register(); break;
                case 2: if (ContextHolder.CurrentUser == null) SignIn(); break;
                case 3: SignOut(); break;
            }
            Main(args);
        }


        static void SignOut()
        {
            authService.SignOut();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Signing out..");
            Thread.Sleep(2000);

        }

        static void SignIn()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Please enter your email");
            string? email = Console.ReadLine();

            Console.WriteLine("Please enter your password");
            string? password = Console.ReadLine();

            var res = authService.SignIn(email, password);

            if (res.Success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Signing in...");
                Thread.Sleep(2000);
                if (res.Data.Role.Name.Equals("ADMIN"))
                    AdminMenu.Menu();
                else
                    UserMenu.Menu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (string s in res.Errors) Console.WriteLine(s);
            }

        }

        static void Register()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine("Please enter your name");
            string? name = Console.ReadLine();

            Console.WriteLine("Please enter your email");
            string? email = Console.ReadLine();

            Console.WriteLine("Please enter your password");
            string? password = Console.ReadLine();

            UserRegisterDto dto = new UserRegisterDto(name, email, password);
            var response = authService.Register(dto);

            if (response.Success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You are successfully registered");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                foreach (string s in response.Errors) Console.WriteLine(s);
            }

        }
    }
}