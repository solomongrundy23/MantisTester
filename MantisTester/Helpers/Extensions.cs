﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MantisTester.Helpers
{
    public static class Extensions
    {
        public static string CombineParams(string splitter, params string[] paramList)
        {
            return string.Join(splitter, paramList.Select(x => x ?? string.Empty).Where(x => x != string.Empty));
        }

        public static T Random<T>(this List<T> list)
        {
            if (list.Count == 0) throw new Exception("List is Empty");
            return list[new Random().Next(list.Count - 1)];
        }
        public static string AsString<T>(this List<T> list, string splitter = "\r\n") => string.Join(splitter, list);
        public static string AsString<T>(this IEnumerable<T> list, string splitter = "\r\n") => string.Join(splitter, list);
        public static string FirstLetterToUpperCase(this string s)
        {
            if (string.IsNullOrEmpty(s)) return s;
            var firstChar = s[0].ToString().ToUpper();
            if (s.Length > 1)
                return firstChar + s.Substring(1);
            else
                return firstChar.ToString();
        }

        public static bool ExistsElement(this IWebDriver driver, string name) => driver.ExistsElement(By.Name(name));

        public static bool ExistsElement(this IWebDriver driver, By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException ex)
            {
                return false;
            }
        }
    }
}
