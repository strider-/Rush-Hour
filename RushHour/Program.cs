using System;

namespace RushHour {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args) {
            using(RushHour game = new RushHour()) {
                game.Run();
            }
        }
    }
}

