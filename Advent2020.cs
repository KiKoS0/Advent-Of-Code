﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Util.Utility;

namespace Advent
{
    /// <summary>
    /// Advent of code 2020 solutions https://adventofcode.com/
    /// Puzzle inputs are compressed(bzip) and base64 encoded 
    /// </summary>
    public static class Advent2020
    {
        public static void Day1()
        {
            IList<int> data = (IList<int>)DecodeBase64(Base64Db[0], '\n');
            var count = data.Count;
            for (var i = 0; i < count; ++i)
                for (var j = i + 1; j < count; ++j)
                    for (var k = i + 2; k < count; k++)
                        if (data[j] + data[i] + data[k] == 2020)
                            Console.WriteLine($"Result: {data[j] * data[i] * data[k]}");
        }
        public static void Day2()
        {
            IList<string> data = (IList<string>)DecodeBase64AsStr(Base64Db[1], '\n');
            var count = data.Count;
            var sum = 0;
            for (var i = 0; i < count; ++i)
            {
                var item = data[i].Split(' ');
                var str = item[2];
                var chr = item[1].Trim()[0];
                var pos = item[0].Split('-').Select(x => int.Parse(x)).ToList();

                if (str[pos[0] - 1] == chr ^ str[pos[1] - 1] == chr)
                    sum++;
            }
            Console.WriteLine($"Result: {sum}");
        }
        public static void Day3()
        {
            IList<string> data = (IList<string>)DecodeBase64AsStr(Base64Db[2], '\n');
            long HowManyTrees(int down, int right)
            {
                long trees = 0;
                for (int i = down, j = right; i < data.Count; i += down, j = (j + right) % data[0].Length)
                    trees += data[i][j] == '#' ? 1 : 0;
                return trees;
            }
            var result = (new[] { (1, 1), (1, 3), (1, 5), (1, 7), (2, 1) })
                .Aggregate((long)1, (acc, next) => acc * HowManyTrees(next.Item1, next.Item2));
            Console.WriteLine($"Result: {result}");
        }
        public static void Day4()
        {
            IList<string> data = (IList<string>)DecodeBase64AsStr(Base64Db[3], '\n');
            if (data.Last() != "") data.Add("");
            int line = 0, valid_fields = 0, valid_pass = 0;
            var hasCid = false;
            while (line < data.Count)
            {
                if (string.IsNullOrWhiteSpace(data[line]))
                {
                    if (valid_fields == 8 || (valid_fields == 7 && !hasCid)) ++valid_pass;
                    line++; valid_fields = 0; hasCid = false; continue;
                }

                static bool CheckField(string str, out bool isCid)
                {
                    static bool IsValidDigit(string str, int len, int lower, int upper) =>
                        str.Length == len &&
                        int.TryParse(str, out int res) &&
                        res >= lower &&
                        res <= upper;
                    isCid = false;
                    var temp = str.Split(':');
                    var (id, val) = (temp[0], temp[1]);
                    return (id, val.Length > 1 ? val[^2..] : val) switch
                    {
                        ("hgt", "cm") => IsValidDigit(val[..^2], 3, 150, 193),
                        ("hgt", "in") => IsValidDigit(val[..^2], 2, 59, 76),
                        ("cid", _) => isCid = true,
                        ("hcl", _) => (new Regex(@"^#(\d|[a-f]){6}$")).IsMatch(val),
                        ("ecl", _) => (new Regex(@"^amb|blu|brn|gry|grn|hzl|oth$")).IsMatch(val),
                        ("pid", _) => (new Regex(@"^\d{9}$")).IsMatch(val),
                        ("byr", _) => IsValidDigit(val, 4, 1920, 2002),
                        ("iyr", _) => IsValidDigit(val, 4, 2010, 2020),
                        ("eyr", _) => IsValidDigit(val, 4, 2020, 2030),
                        (_, _) => false,
                    };
                }
                var (h, cid) = data[line].Split().Aggregate((valid_fields, hasCid), (acc, next) =>
                    (CheckField(next, out bool isCid) ? ++acc.valid_fields : acc.valid_fields, acc.hasCid | isCid));
                valid_fields = h; ++line; hasCid = cid;
            }
            Console.WriteLine($"Result {valid_pass}");
        }

        public static void Day5()
        {
            IList<string> data = (IList<string>)DecodeBase64AsStr(Base64Db[4], '\n');
            int StrBitsToNumber(string str, char up, char down)
                => str.Aggregate(
                    (0, 0),
                    (acc, next) => (acc.Item1 + 1, acc.Item2 |
                    (next == up ? 1 : 0) << str.Length - 1 - acc.Item1)
                    , x => x.Item2);
            int SeatId(string str)
                => StrBitsToNumber(str[..7], 'B', 'F') * 8 + StrBitsToNumber(str[7..], 'R', 'L');
            Console.WriteLine($"Result: {data.Max(SeatId)}");
            var lst = new List<int>();
            foreach (var i in data)
                lst.Add(SeatId(i));
            long MissingSeat(IList<int> lst)
            {
                long n = lst.Count, total = (n + 1) * (n + 2 * lst.Min()) / 2;
                for (var i = 0; i < n; i++) total -= lst[i];
                return total;
            }
            Console.WriteLine($"Empty Seat: {MissingSeat(lst)}");
        }

        public static void Day6()
        {
            IList<string> data = (IList<string>)DecodeBase64AsStr(Base64Db[5], '\n');
            if (data.Last() != "") data.Add("");
            void Part1()
            {
                int line = 0;
                var quest = new HashSet<char>();
                var sum = 0;
                while (line < data.Count)
                {
                    if (string.IsNullOrWhiteSpace(data[line]))
                    {
                        sum += quest.Count; quest.Clear(); line++;
                        continue;
                    }
                    foreach (var i in data[line])
                        quest.Add(i);
                    line++;
                }
                Console.WriteLine($"Result: {sum}");
            }
            void Part2()
            {
                int line = 0;
                var quest = new Dictionary<char, int>();
                var sum = 0;
                var pers = 0;
                while (line < data.Count)
                {
                    if (string.IsNullOrWhiteSpace(data[line]))
                    {
                        sum += quest.Where(x => x.Value == pers).Count();
                        quest.Clear();
                        line++;
                        pers = 0;
                        continue;
                    }
                    foreach (var i in data[line])
                        quest[i] = quest.ContainsKey(i) ? quest[i] + 1 : 1;
                    line++;
                    pers++;
                }
                Console.WriteLine($"Result: {sum}");
            }
            Part1();
            Part2();
        }
        public static void Day7()
        {
            IList<string> data = (IList<string>)DecodeBase64AsStr(Base64Db[6], '\n');
            var bags = new Dictionary<string, IList<(string, int)>>();
            foreach (var i in data)
            {
                var str = i.Split("bag");
                var reg = new Regex(@"(\d+)\s+(\w+\s+\w+)");
                var contain = str[1..]
                    .Where(x => reg.IsMatch(x))
                    .Select(x =>
                    {
                        var res = reg.Match(x);
                        return (res.Groups[2].Value, int.Parse(res.Groups[1].Value));
                    })
                    .ToList();
                bags[str[0].Trim()] = contain;
            }
            bool CanHoldGoldBag(
                string bag,
                Dictionary<string, IList<(string, int)>> bags) =>
                bag switch
                {
                    "shiny gold" => true,
                    _ => bags[bag].Any(x => CanHoldGoldBag(x.Item1, bags))
                };
            var res1 = bags.Aggregate(0,
                (acc, next) => acc += CanHoldGoldBag(next.Key, bags) ? 1 : 0) - 1;
            int HowManyBagsInBag(string bag, Dictionary<string, IList<(string, int)>> bags) =>
                bags[bag].Count == 0 ? 0 :
                bags[bag].Aggregate(0,
                    (acc, next) => acc + HowManyBagsInBag(next.Item1, bags) * next.Item2 + next.Item2);
            var res2 = HowManyBagsInBag("shiny gold", bags);
            Console.WriteLine($"Result Part1: {res1}");
            Console.WriteLine($"Result Part2: {res2}");

        }
        public static void Day8()
        {
            IList<string> data = (IList<string>)DecodeBase64AsStr(Base64Db[7], '\n');
            bool Run(IList<string> data)
            {
                var ip = 0;
                var executed = new List<int>();
                var acc = 0;
                while (!executed.Contains(ip) && ip < data.Count)
                {
                    executed.Add(ip);
                    var match = (new Regex(@"(\w+)\s(\+|-)(\d+)")).Match(data[ip]);
                    switch (match.Groups[1].Value)
                    {
                        case "jmp":
                            {
                                ip += match.Groups[2].Value == "+" ? int.Parse(match.Groups[3].Value) : int.Parse(match.Groups[3].Value) * -1;
                            }
                            break;
                        case "acc":
                            {
                                acc += match.Groups[2].Value == "+" ? int.Parse(match.Groups[3].Value) : int.Parse(match.Groups[3].Value) * -1;
                                ip++;
                            }
                            break;
                        default:
                            {
                                ip++;
                            }
                            break;
                    }
                }
                var res = ip == data.Count;
                if (res)
                    Console.WriteLine($"Result(acc): {acc}");
                return res;
            }
            for (var i = 0; i < data.Count; i++)
            {
                var cpy = new List<string>(data);
                if (data[i].Contains("nop"))
                {
                    cpy[i] = cpy[i].Replace("nop", "jmp");
                    Run(cpy);
                }
                else if (data[i].Contains("jmp"))
                {
                    cpy[i] = cpy[i].Replace("jmp", "nop");
                    Run(cpy);
                }
            }
        }
        public static void Day9()
        {
            IList<string> data = (IList<string>)DecodeBase64AsStr(Base64Db[8], '\n');
            long num = 0;
            var pre = 25;
            for (var i = pre; i < data.Count; ++i)
            {
                var res = false;
                for (var j = i - 1; j >= i - pre; --j)
                {
                    for (var k = i - 2; k >= i - pre; --k)
                    {
                        if (!res)
                            res = long.Parse(data[i]) == long.Parse(data[j]) + long.Parse(data[k]);
                        else
                            break;
                    }
                    if (res) break;
                }
                if (!res)
                {
                    Console.WriteLine($"Result Part1 :{data[i]}");
                    num = long.Parse(data[i]);
                    break;
                }
            }
            for (var i = 0; i < data.Count; ++i)
            {
                var sum = long.Parse(data[i]);
                var test = new List<long>();
                test.Add(sum);
                for (var j = i + 1; j < data.Count; ++j)
                {
                    test.Add(long.Parse(data[j]));
                    sum += long.Parse(data[j]);
                    if (sum >= num)
                        break;
                }
                if (sum == num)
                {
                    var min = test.Min();
                    var max = test.Max();
                    Console.WriteLine($"Result Part2 :{min + max}");
                    break;
                }
            }
        }

        private static string[] Base64Db = {
            "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",
        };
    }
}
