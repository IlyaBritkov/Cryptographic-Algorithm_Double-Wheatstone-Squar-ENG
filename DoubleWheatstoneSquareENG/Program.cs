using System;
using DoubleWheatstoneSquareENG.Logic;

namespace DoubleWheatstoneSquareENG {
    class Program {
        static void Main(string[] args) {
            DoubleWheatstoneSquare doubleWheatstoneSquare = new DoubleWheatstoneSquare();
            doubleWheatstoneSquare.setDencryptedString("Game");
            Console.WriteLine("Dencrypted string = " + doubleWheatstoneSquare.getDencryptedString());
            doubleWheatstoneSquare.encrypt();
            Console.WriteLine("Encrypted string = " + doubleWheatstoneSquare.getEncryptedString());
            doubleWheatstoneSquare.dencrypt();
            Console.WriteLine("Dencrypted string = " + doubleWheatstoneSquare.getDencryptedString());

            Console.WriteLine();

        }
    }
}