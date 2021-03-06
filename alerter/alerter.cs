using System;
using System.Diagnostics;

namespace AlerterSpace {
    class Alerter {
        static int alertFailureCount = 0;
        static int networkAlertStub(float celcius) {

            if(celcius >= 100f)
            {
                Console.WriteLine("ALERT: Temperature is {0} celcius", celcius);

                return 500;
            }

            // Return 200 for ok
            // Return 500 for not-ok
            // stub always succeeds and returns 200
            return 200;
        }

        static float ConvertFarenheitToCelcius(float farenheit)
        {

            float celcius = (farenheit - 32) * 5 / 9;

            return celcius;

        }

        static void alertInCelcius(float farenheit) {
            float celcius = ConvertFarenheitToCelcius(farenheit);
            int returnCode = networkAlertStub(celcius);
            if (returnCode != 200) {
                // non-ok response is not an error! Issues happen in life!
                // let us keep a count of failures to report
                // However, this code doesn't count failures!
                // Add a test below to catch this bug. Alter the stub above, if needed.
                alertFailureCount += 1;
            }
        }
        static void Main(string[] args) {
            alertInCelcius(400.5f);
            alertInCelcius(303.6f);
            Console.WriteLine("{0} alerts failed.", alertFailureCount);

            Debug.Assert(alertFailureCount == 2);

            Console.WriteLine("All is well (maybe!)\n");
        }
    }
}
