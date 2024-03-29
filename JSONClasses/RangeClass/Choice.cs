﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Classes
{
    public class Choice : IPattern
    {
        private  IPattern[] patterns;
        public Choice(params IPattern[] patterns)
        {
            this.patterns = patterns;
        }

        public IMatch Match(string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return new FailMatch(text);
            }

            string remaining = text;
            foreach (IPattern pattern in patterns)
            {
                var match = pattern.Match(text);

                if (match.RemainingText().Length < remaining.Length)
                {
                    remaining = match.RemainingText();
                }

                if (match.Success())
                {
                    return match;
                }
            }

            return new FailMatch(remaining);
        }

        public void Add(IPattern pattern)
        {
            Array.Resize(ref patterns, patterns.Length + 1);
            patterns[^1] = pattern;
        }
    }
}
