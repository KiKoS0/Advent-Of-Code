using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static Util.Utility;
using static Util.Input;

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
        public static void Day10()
        {
            List<int> data = (List<int>)DecodeBase64(Base64Db[9], '\n');

            void Part1(List<int> data)
            {
                data.Sort();
                int dif1 = 0;
                int dif3 = 1;
                if (data[0] > 1) dif3++; else dif1++;
                for (var i = 0; i < data.Count - 1; ++i)
                {
                    if (data[i + 1] - data[i] == 1) dif3++;
                    else dif1++;
                }
                Console.WriteLine($"Result Part1: {dif1 * dif3}");
            }
            void Part2(List<int> data)
            {
                data.Add(data.Max()+3); data.Insert(0, 0); data.Sort();
                long Find(long val,IList<int> data,Dictionary<long, long> mem)
                {
                    if (!data.Contains((int)val)) return 0;
                    if (val == data[data.Count-1]) return 1;
                    if (!mem.ContainsKey(val))
                        mem[val] = Find(val + 1, data, mem) + Find(val + 2, data, mem) + Find(val + 3, data, mem);
                    return mem[val];
                }
                Console.WriteLine($"Result Part2: {Find(0, data, new Dictionary<long, long>())}");
            }
            Part1(new List<int>(data));
            Part2(new List<int>(data));
        }
    }
}
