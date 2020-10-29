using System;
using DoubleWheatstoneSquareENG.Logic;

namespace DoubleWheatstoneSquareENG {
    class Program {
        static void Main(string[] args) {
            DoubleWheatstoneSquare doubleWheatstoneSquare = new DoubleWheatstoneSquare();
            doubleWheatstoneSquare.setDencryptedString("game");
            doubleWheatstoneSquare.encrypt();
        }
    }
}