﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Factorialiser.Classes
{
    public static class Calculator
    {
        /// <summary>
        /// Calculates and returns the factorial of the input integer
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// 
        private static NLog.Logger nlogger = NLog.LogManager.GetCurrentClassLogger();

        public static int Factorial(int input)
            
        {
            nlogger.Trace("Calculating: " + input);
            try
            {
                if (input == 1)
                {
                    return 1;
                }
                else if (input < 1) throw new NumberTooLowException(input);
                else if (input > 30) throw new NumberTooHighException(input);
                else
                {
                    return input * Factorial(input - 1);
                }
            }
            catch(NumberTooLowException ex)
            {
                nlogger.Debug("Input too low: " + input);
                throw ex;
            }
            catch (NumberTooHighException ex)
            {
                nlogger.Debug("Input too high: " + input);
                throw ex;
            }

            // this method should:

            // return the factorial of the integer enetered (or a recursive step toward it)
            // in this normal operation, every step / recursion should be logged (Trace) in the following format
            // (if for example an input of 5 was received)
            // "Calcuator.Factorial: calculating: 5"

            // if the number entered is < 1 this should throw a NumberTooLowException.
            // if this occurs it should be logged (Debug) with the message as below:
            // "Calcuator.Factorial: input too low: -5"

            // if the number entered is >30 this should throw a NumberTooHighException.
            // if this occurs it should be logged (Debug) with the message as below:
            // "Calcuator.Factorial: input too high: 45"

        }
    }
}
