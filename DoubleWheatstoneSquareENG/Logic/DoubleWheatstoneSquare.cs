using System;
using System.Collections.Generic;

namespace DoubleWheatstoneSquareENG.Logic {
    /** For filling encrypt table there are '@' and '$' added to english alphabet.
     * If amount of letters in input string is odd, added '$' symbol. 
     */
    public class DoubleWheatstoneSquare {
        private string encryptedString;
        private string dencryptedString;
        private string[,] leftTable; // fisrt encrypring table
        private string[,] rightTable; // second encrypring table
        private List<string> englishAlphabetList;
        private List<string> encryptedBigramsList;
        private List<string> dencryptedBigramsList;


        public DoubleWheatstoneSquare() {
            // initialization and filling englishAlphabetList
            englishAlphabetList = new List<string>();
            encryptedBigramsList = new List<string>();
            dencryptedBigramsList = new List<string>();
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

        private Point findPoint(string[,] array, string letter) {
            int x = 0;
            int y = 0;
            for (int i = 0; i < array.GetLength(0); i++) {
                for (int j = 0; j < array.GetLength(1); j++) {
                    if (array[i, j].ToLower().Equals(letter) || array[i, j].ToUpper().Equals(letter)) {
                        x = i;
                        y = j;
                    }
                }
            }

            return new Point(x, y);
        }

        private void createBigrams(List<string> list, string s) {
            foreach (var letter in s) {
                if (englishAlphabetList.Contains((letter + "").ToUpper()) ||
                    englishAlphabetList.Contains((letter + "").ToLower())) {
                    list.Add(letter + "");
                }
            }

            if (list.Count % 2 != 0) {
                list.Add("$");
            }
        }

        public string encrypt() {
            if (dencryptedString.Length == 0) {
                throw new Exception("there is not data for encryption");
            }

            createBigrams(dencryptedBigramsList, dencryptedString);
            encryptedString = "";
            int pointer = 0;
            
            string nonLetterPart1 = checkAndGetNonLetterOnIndex(dencryptedString, pointer);
            for (int i = 0; i < dencryptedBigramsList.Count - 1; i += 2) {
                string leftStartLetter = dencryptedBigramsList[i];
                string rightStartLetter = dencryptedBigramsList[i + 1];

                Point startLeftPoint = findPoint(leftTable, leftStartLetter);
                Point startRightPoint = findPoint(rightTable, rightStartLetter);

                string rightLetter;
                string leftLetter;
                if ((startLeftPoint.getX() == startRightPoint.getX()) ||
                    (startLeftPoint.getY() == startRightPoint.getY())) {
                    // both letter on same horizotnal string or on same vertical string 
                    rightLetter = rightTable[startLeftPoint.getX(), startLeftPoint.getY()];
                    leftLetter = leftTable[startRightPoint.getX(), startRightPoint.getY()];
                } else {
                    // both letter on different strings
                    rightLetter = rightTable[startLeftPoint.getX(), startRightPoint.getY()];
                    leftLetter = leftTable[startRightPoint.getX(), startLeftPoint.getY()];
                }

                nonLetterPart1 = checkAndGetNonLetterOnIndex(dencryptedString, pointer);
                pointer += nonLetterPart1.Length;
                rightLetter = getLetterInCorrectCase(dencryptedString, pointer, rightLetter);
                pointer++;

                string nonLetterPart2 = checkAndGetNonLetterOnIndex(dencryptedString, pointer);
                pointer += nonLetterPart2.Length;
                leftLetter = getLetterInCorrectCase(dencryptedString, pointer, leftLetter);
                pointer++;
                encryptedString += nonLetterPart1 + rightLetter + nonLetterPart2 + leftLetter;
            }
            encryptedString += checkAndGetNonLetterOnIndex(dencryptedString, pointer);
            return encryptedString;
        }

        public string dencrypt() {
            if (encryptedString.Length == 0) {
                throw new Exception("there is not data for dencryption");
            }

            createBigrams(encryptedBigramsList, encryptedString);

            encryptedString = "";
            int pointer = 0;
            foreach (var letter in encryptedBigramsList) {
                Point startLeftPoint = findPoint(leftTable, letter);
                Point startRightPoint = findPoint(rightTable, letter);

                string rightLetter = "";
                string leftLetter = "";
                if ((startLeftPoint.getX() == startRightPoint.getX()) ||
                    (startLeftPoint.getY() == startRightPoint.getY())) {
                    // both letter on same horizotnal string or on same vertical string
                    leftLetter = leftTable[startRightPoint.getX(), startRightPoint.getY()];
                    rightLetter = rightTable[startLeftPoint.getX(), startLeftPoint.getY()];
                } else {
                    // both letter on different strings
                    leftLetter = leftTable[startRightPoint.getX(), startLeftPoint.getY()];
                    rightLetter = rightTable[startLeftPoint.getX(), startRightPoint.getY()];
                }

                encryptedString += leftLetter + rightLetter;
            }

            return encryptedString;
        }

        private string checkAndGetNonLetterOnIndex(string sourse, int point) {
            string result = "";
            while (point >= 0 && point <= sourse.Length - 1) {
                string symbol = sourse[point++] + "";
                if (!englishAlphabetList.Contains(symbol.ToUpper()) && !englishAlphabetList.Contains(symbol.ToLower())) {
                    result += symbol;
                } else {
                    return result;
                }
            }
            return result;
        }

        private string getLetterInCorrectCase(string source, int position, string target) {
            if (position >= 0 && position <= source.Length - 1) {
                if ((source[position] + "").Equals((source[position] + "").ToUpper())) {
                    // primary letter in upper case
                    return target.ToUpper();
                } else {
                    // primary letter in lower case
                    return target.ToLower();
                }
            } else {
                return null;
            }
        }


        public void printEncryptedTables() {
            for (int x = 0; x < leftTable.GetLength(0); x += 1) {
                for (int y = 0; y < leftTable.GetLength(1); y += 1) {
                    Console.Write(leftTable[x, y]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine();
            for (int x = 0; x < rightTable.GetLength(0); x += 1) {
                for (int y = 0; y < rightTable.GetLength(1); y += 1) {
                    Console.Write(rightTable[x, y]);
                }
                Console.WriteLine();
            }
        }
    }
}