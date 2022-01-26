using misaligned;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MisalignedSpace {
    class Misaligned {
        static List<PrintedColorLine> printColorMap() {

            List<PrintedColorLine> printedColorLines = new List<PrintedColorLine>();

            string[] majorColors = {"White", "Red", "Black", "Yellow", "Violet"};
            string[] minorColors = {"Blue", "Orange", "Green", "Brown", "Slate"};
            int i = 0, j = 0;
            for(i = 0; i < 5; i++) {
                for(j = 0; j < 5; j++) {

                    string lineToPrint = String.Format("{0} | {1} | {2}", i * 5 + j, majorColors[i], minorColors[i]);

                    printedColorLines.Add(new PrintedColorLine { majorColor = majorColors[i], minorColor = minorColors[i],  printedLine =lineToPrint });

                    Console.WriteLine(lineToPrint);
                }
            }
            return printedColorLines;
        }
        static void Main(string[] args) {
            List<PrintedColorLine> result = printColorMap();

            string[] majorColors = { "White", "Red", "Black", "Yellow", "Violet" };
            string[] minorColors = { "Blue", "Orange", "Green", "Brown", "Slate" };

            int numberOfPairs = majorColors.Length * minorColors.Length;

            Debug.Assert(result.Count == numberOfPairs);

            //Check if the alignment is correct
            Debug.Assert(result[0].printedLine.Length == result[numberOfPairs-1].printedLine.Length);

            Debug.Assert(colorsPrintedCorrectly(result));

            Console.WriteLine("All is well (maybe!)");
        }

        static bool colorsPrintedCorrectly(List<PrintedColorLine> printedColorLines)
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
