﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rca.HueHook.Util
{
    /// <summary>
    /// Parse strings into true or false bools using relaxed parsing rules
    /// Inspired by: https://www.dotnetperls.com/bool-parse
    /// </summary>
    public static class BoolParser
    {
        /// <summary>
        /// Converts a string representation of a logical value to its <seealso cref="Boolean"/> object equivalent.
        /// </summary>
        /// <param name="value">A string representation of true (1, YES, T) or false (0, NO, F). </param>
        /// <returns>A Boolean value (true or false) that corresponds to the <paramref name="value"/> argument.</returns>
        public static bool ToBoolean(this string value)
        {
            return IsTrue(value);
        }

        /// <summary>
        /// Get the boolean value for this string
        /// </summary>
        public static bool GetValue(string value)
        {
            return IsTrue(value);
        }

        /// <summary>
        /// Determine whether the string is not True
        /// </summary>
        public static bool IsFalse(string value)
        {
            return !IsTrue(value);
        }

        /// <summary>
        /// Determine whether the string is equal to True
        /// </summary>
        public static bool IsTrue(string value)
        {
            try
            {
                // 1
                // Avoid exceptions
                if (value == null)
                {
                    return false;
                }

                // 2
                // Remove whitespace from string
                value = value.Trim();

                // 3
                // Lowercase the string
                value = value.ToLower();

                // 4
                // Check for word true
                if (value == "true")
                {
                    return true;
                }

                // 5
                // Check for letter true
                if (value == "t")
                {
                    return true;
                }

                // 6
                // Check for one
                if (value == "1")
                {
                    return true;
                }

                // 7
                // Check for word yes
                if (value == "yes")
                {
                    return true;
                }

                // 8
                // Check for letter yes
                if (value == "y")
                {
                    return true;
                }

                // 9
                // It is false
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
