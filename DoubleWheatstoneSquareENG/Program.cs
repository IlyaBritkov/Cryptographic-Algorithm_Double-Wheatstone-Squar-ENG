using System;
using DoubleWheatstoneSquareENG.Logic;

namespace DoubleWheatstoneSquareENG {
    class Program {
        static void Main(string[] args) {
            DoubleWheatstoneSquare doubleWheatstoneSquare = new DoubleWheatstoneSquare();
            doubleWheatstoneSquare.setDencryptedString("Game-S");
            doubleWheatstoneSquare.encrypt();
            Console.WriteLine("Dencrypted string = " + doubleWheatstoneSquare.getDencryptedString());
            Console.WriteLine("Encrypted string = " + doubleWheatstoneSquare.getEncryptedString());
            doubleWheatstoneSquare.dencrypt();
            Console.WriteLine("Dencrypted string = " + doubleWheatstoneSquare.getDencryptedString());

            Console.WriteLine();
            
            // DoubleWheatstoneSquare doubleWheatstoneSquare2 = new DoubleWheatstoneSquare();
            // doubleWheatstoneSquare2.setEncryptedString("Sma@-G");
            // doubleWheatstoneSquare2.dencrypt();
            // Console.WriteLine("Encrypted string = " + doubleWheatstoneSquare2.getEncryptedString());
            // Console.WriteLine("Dencrypted string = " + doubleWheatstoneSquare2.getDencryptedString());
            // doubleWheatstoneSquare2.encrypt();
            // Console.WriteLine("Encrypted string = " + doubleWheatstoneSquare2.getEncryptedString());


        }
    }
}