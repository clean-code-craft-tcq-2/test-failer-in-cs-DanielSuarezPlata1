using misaligned;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MisalignedSpace {
    class Misaligned {
        static List<PrintedColorLine> PrintColorMap() {

            List<PrintedColorLine> printedColorLines = new List<PrintedColorLine>();

            string[] majorColors = {"White", "Red", "Black", "Yellow", "Violet"};
            string[] minorColors = {"Blue", "Orange", "Green", "Brown", "Slate"};
            int majorColorIndex = 0, minorColorIndex = 0;
            for(majorColorIndex = 0; majorColorIndex < 5; majorColorIndex++) {

                for(minorColorIndex = 0; minorColorIndex < 5; minorColorIndex++) {

                    string lineToPrint = String.Format("{0,7} | {1,7} | {2,7}", majorColorIndex * 5 + minorColorIndex + 1, majorColors[majorColorIndex], minorColors[minorColorIndex]);

                    printedColorLines.Add(new PrintedColorLine { majorColor = majorColors[majorColorIndex], minorColor = minorColors[minorColorIndex],  printedLine =lineToPrint });

                    Console.WriteLine(lineToPrint);
                }
            }
            return printedColorLines;
        }
        static void Main(string[] args) {
            List<PrintedColorLine> result = PrintColorMap();

            string[] majorColors = { "White", "Red", "Black", "Yellow", "Violet" };
            string[] minorColors = { "Blue", "Orange", "Green", "Brown", "Slate" };

            int numberOfPairs = majorColors.Length * minorColors.Length;

            Debug.Assert(result.Count == numberOfPairs);

            //Check if the alignment is correct
            Debug.Assert(result[0].printedLine.Length == result[numberOfPairs-1].printedLine.Length);

            Debug.Assert(ColorsPrintedCorrectly(result));

            Console.WriteLine("All is well (maybe!)");
        }

        static bool ColorsPrintedCorrectly(List<PrintedColorLine> printedColorLines)
        {
            string latestMinorColor = "";

            bool isCorrectlyPrinted = true;

            for (int i = 0; i < printedColorLines.Count; i++)
            {
                if (latestMinorColor == printedColorLines[i].minorColor)
                {
                    isCorrectlyPrinted = false;

                    break;
                }

                latestMinorColor = printedColorLines[i].minorColor;

            }

            return isCorrectlyPrinted;
        }
    }
}
