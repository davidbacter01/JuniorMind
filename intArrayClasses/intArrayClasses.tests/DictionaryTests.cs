﻿using System.Collections.Generic;
using System.Net.Http.Headers;
using Xunit;

namespace intArrayClasses.tests
{
    public class DictionaryTests
    {
        [Fact]
        public void AddsKeyValuePairsToDictionary()
        {
            var dict = new Dictionary<string, string>();
            dict.Add("lapte", "120l");
            dict.Add("apa", "200l");
            dict.Add("paa", "conflict");
            var juice = new KeyValuePair<string, string>("suc", "300l");
            dict.Add(juice);
            Assert.Equal("120l", dict["lapte"]);
            Assert.Equal("200l", dict["apa"]);
            Assert.Equal("300l", dict["suc"]);
            Assert.Equal("conflict", dict["paa"]);
        }

        [Fact]
        public void AddsAnElementIfSetOnNonExistentKey()
        {
            var dict = new Dictionary<string, string>
            {
                { "lapte", "120l" },
                { "apa", "200l" },
                { "paa", "conflict" }
            };

            dict["lapte"] = "130l";
            dict["ulei"] = "300l";
            Assert.Equal("130l", dict["lapte"]);
            Assert.Equal("300l", dict["ulei"]);
        }

        [Fact]
        public void ClearsPositionsInDictionary()
        {
            var dict = new Dictionary<string, string>
            {
                { "lapte", "120l" },
                { "apa", "200l" },
                { "paa", "conflict" }
            };

            int expected = 0;
            dict.Clear();
            Assert.Equal(expected, dict.Count);
        }

        [Fact]
        public void ValidatesIfDictionaryContainsKey()
        {
            var dict = new Dictionary<string, string>
            {
                { "lapte", "120l" },
                { "apa", "200l" },
                { "paa", "conflict" }
            };

            Assert.True(dict.ContainsKey("lapte"));
            Assert.False(dict.ContainsKey("mar"));
        }

        [Fact]
        public void ValidatesIfDictionaryContainsKeyValuePair()
        {
            var dict = new Dictionary<string, string>
            {
                { "lapte", "120l" },
                { "apa", "200l" },
                { "paa", "conflict" }
            };
            var lapte = new KeyValuePair<string, string>("lapte", "120l");
            Assert.True(dict.Contains(lapte));
        }

        [Fact]
        public void RemovesElementFromDictionary()
        {
            var dict = new Dictionary<string, string>
            {
                { "lapte", "120l" },
                { "apa", "200l" },
                { "paa", "conflict" }
            };
            var lapte = new KeyValuePair<string, string>("lapte", "120l");
            dict.Remove("apa");
            dict.Remove(lapte);
            Assert.False(dict.ContainsKey("apa"));
            Assert.False(dict.ContainsKey("lapte"));
            Assert.DoesNotContain(lapte, dict);
        }

        [Fact]
        public void CopiesKeyValuePairsToArray()
        {
            KeyValuePair<string, string>[] ar =
            {
                new KeyValuePair<string, string>("a", "a"),
                new KeyValuePair<string, string>("b", "b"),
                new KeyValuePair<string, string>("c","c")
            };
            var dict = new Dictionary<string, string>
            {
                { "lapte", "120l" },
                { "apa", "200l" },
                { "paa", "conflict" }
            };
            dict.CopyTo(ar, 0);
            Assert.Contains(new KeyValuePair<string,string>("lapte","120l"),ar);
            Assert.Contains(new KeyValuePair<string,string>("apa","200l"),ar);
            Assert.Contains(new KeyValuePair<string,string>("paa","conflict"),ar);
        }

        [Fact]
        public void TriesToGetValueFromDictionary()
        {
            var dict = new Dictionary<string, string>
            {
                { "lapte", "120l" },
                { "apa", "200l" },
                { "paa", "conflict" }
            };

            Assert.True(dict.TryGetValue("lapte", out string value));
            Assert.False(dict.TryGetValue("mar", out string mar));
        }

        [Fact]
        public void WorksForMultipleDeletes()
        {
            var dict = new Dictionary<string, string>
            {
                { "lapte", "120l" },
                { "apa", "200l" },
                { "paa", "conflict" },
                {"ab","b" },
                {"ba","d" },
                {"e","f" }
            };

            dict.Remove("lapte");
            dict.Remove("paa");
            dict.Remove("apa");
            dict.Remove(new KeyValuePair<string, string>("ab", "b"));
            dict.Remove(new KeyValuePair<string, string>("ba", "d"));
            Assert.False(dict.ContainsKey("lapte"));
            Assert.False(dict.ContainsKey("apa"));
            Assert.False(dict.ContainsKey("paa"));
            Assert.False(dict.ContainsKey("ab"));
            Assert.False(dict.ContainsKey("ba"));
        }
    }
}
