using System;
using System.Collections.Generic;

namespace DoubleWheatstoneSquareENG.Logic {
/** For filling encrypt table there are '@' and '$' added to english alphabet **/
    public class DoubleWheatstoneSquare {
        private string encryptedString;
        private string dencryptedString;
        private string[,] leftTable; // fisrt encrypring table
        private string[,] rightTable; // second encrypring table
        private List<string> englishAlphabetList;
        private List<string> bigramsList; 


        public DoubleWheatstoneSquare() {
            // initialization and filling englishAlphabetList
            englishAlphabetList = new List<string>();
            bigramsList = new List<string>();
            for (char ch = 'A'; ch <= 'Z'; ch++) {
                englishAlphabetList.Add(ch + "");
            }

            englishAlphabetList.Add("$");
            englishAlphabetList.Add("@");


            // initialization and filling encrypring tables
            leftTable = new string[7, 4];
            rightTable = new string[7, 4];

            HashSet<string> lettersFirstTableSet = new HashSet<string>();
            HashSet<string> lettersSecondTableSet = new HashSet<string>();

            for (int i = 0; i < leftTable.GetLength(0); i++) {
                for (int j = 0; j < leftTable.GetLength(1); j++) {
                    Random generator = new Random();
                    string nextLeftCh = englishAlphabetList[generator.Next(0, englishAlphabetList.Count)];
                    string nextRightCh = englishAlphabetList[generator.Next(0, englishAlphabetList.Count)];

                    while (lettersFirstTableSet.Contains(nextLeftCh)) {
                        nextLeftCh = englishAlphabetList[generator.Next(0, englishAlphabetList.Count)];
                    }

                    lettersFirstTableSet.Add(nextLeftCh);

                    leftTable[i, j] = nextLeftCh;

                    while (lettersSecondTableSet.Contains(nextRightCh)) {
                        nextRightCh = englishAlphabetList[generator.Next(0, englishAlphabetList.Count)];
                    }

                    lettersSecondTableSet.Add(nextRightCh);

                    rightTable[i, j] = nextRightCh;
                }
            }
        }

        public DoubleWheatstoneSquare(string encryptedString, string dencryptedString) : this() {
            this.encryptedString = encryptedString;
            this.dencryptedString = dencryptedString;
        }

        public void setEncryptedString(string encryptedString) {
            this.encryptedString = encryptedString;
        }

        public string getEncryptedString() {
            return encryptedString;
        }

        public void setDencryptedString(string dencryptedString) {
            this.dencryptedString = dencryptedString;
        }

        public string getDencryptedString() {
            return dencryptedString;
        }

        public string encrypt() {
            if (dencryptedString.Length == 0) {
                throw new Exception("there is not data for encryption");
            }
            
                createBigrams(dencryptedString);
                return null;
        }

        public string dencrypt() {
            if (encryptedString.Length == 0) {
                throw new Exception("there is not data for dencryption");
            }
            createBigrams(encryptedString);
            
            return null;
        }

        private void createBigrams(string s) {
            foreach (var letter in s) {
                if (englishAlphabetList.Contains((letter+"").ToUpper())) {
                    bigramsList.Add(letter+"");
                }
            }
        }
    }
}