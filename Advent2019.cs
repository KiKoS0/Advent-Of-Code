using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Util.Utility;

namespace Advent
{
    /// <summary>
    /// Advent of code 2019 solutions https://adventofcode.com/2019
    /// Puzzle inputs are compressed(bzip) and base64 encoded 
    /// </summary>
    public static class Advent2019
    {
        public static void Execute()
        {
            var data_b64 = "QlpoOTFBWSZTWQgWZ4cAARJIAEAQf+BAAbNzNa6GqemnoxUxFT/CNEkGqn+JpT2qmDTFMnqahqvhNjvUvH1ypTuAQH4E8SLiN5DG95unlyUopmXredZJuVabKq+kQ3e63TlopQa7X5Y9HnMKYwK1DxEaDIJW19Lx5FBmeD+HjVBEVDQ6a4WUCAFG6rSMNDpold2HYLXimNHF3CdyXcHUw4mZQemgKFsn3WetcJfR7hrBgVwFFAoPPsdN55bq7MlbBcgt14lJQdCg+wVA7EJPYuq5bc4w4g0wiu1FjCo6GGrsmL795kpRaZSh5bY7fGo610S7wvbO6E4FvvQYeFAkuIWO+kq7c3eMpprI+i+A7jzc73cTBSqPK88oAerwc6gNiwYqzvbCsTzsUebpju7Q7Q2uEMunTbuBwLhWEGtv3n+x5et8mfSd/F3JFOFCQCBZnhw=";
            var array = DecodeBase64(data_b64, '\n');
            int FuelForFuel(int i) => i switch
            {
                <= 0 => 0,
                _ => i + FuelForFuel(i / 3 - 2)
            };

            int ModuleFuelAmount(int i)
            {
                var moduleFuel = i / 3 - 2;
                var fuelForFuel = FuelForFuel(moduleFuel / 3 - 2);
                return moduleFuel + fuelForFuel;
            };

            var sum = 0;
            foreach (var i in array)
            {
                sum += ModuleFuelAmount(i);
            }

            // Console.WriteLine($"Result : {sum}");
            data_b64 = "QlpoOTFBWSZTWTyFeo0AAF8YAAAEf+AwARTCGp4IiCKe8ikASnpCU2UK8+O6xfVyBobIu4KYeW6SZ0WvMIc9uE7goSOoYpsUzYCYaYSkRpQrMD3Op9hGPEQ2A+86LNqqlmmZWy8chsL2mbZt30wEQRCXmb+gKcQ1MQuS2qjErWisGiqRoFUqkRE++6Sy/bPTJLucXk5IGCiKqKqJ2dnvaGK4SGbqXSKrQKp7x7tz2RRO84Pd+804zPpXUrTwD8XckU4UJA8hXqNA";
            IList<int> initialState = (IList<int>)DecodeBase64(data_b64, ',');

            IList<int> ExecuteVm(IList<int> state, int noun, int verb)
            {
                var ip = 0;
                var vm = new List<int>(state);
                var instr = vm.ElementAt(ip);
                vm[1] = noun;
                vm[2] = verb;
                while (instr != 99)
                {
                    switch (instr)
                    {
                        case 1:
                            {
                                // Addition
                                vm[vm[ip + 3]] = vm[vm[ip + 2]] + vm[vm[ip + 1]];
                                ip += 4;
                            }
                            break;
                        case 2:
                            {
                                // Multiplication
                                vm[vm[ip + 3]] = vm[vm[ip + 2]] * vm[vm[ip + 1]];
                                ip += 4;
                            }
                            break;
                    }
                    instr = vm.ElementAt(ip);
                }
                return vm;
            }

            foreach (var n in Enumerable.Range(0, 99))
            {
                foreach (var v in Enumerable.Range(0, 99))
                {
                    var finalState = ExecuteVm(initialState, n, v);
                    var result = finalState.FirstOrDefault();
                    if (result == 19690720)
                    {
                        Console.WriteLine($"Found it: noun= {n}, verb= {v}, result = {100 * n + v}");
                    }
                }
            }
        }
    }
}
