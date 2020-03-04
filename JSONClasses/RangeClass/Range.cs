﻿using System;

namespace RangeClass
{
    public class Range
    {
        private readonly char start;
        private readonly char end;
        public Range(char start, char end)
        {
            this.start = start;
            this.end = end;
        }
        public bool Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            foreach (char c in text)
            {
                if (!(c >= start) || !(c <= end))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
