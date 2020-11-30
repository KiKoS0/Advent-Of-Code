using System;
using System.Linq;
using System.Collections.Generic;

IEnumerable<int> DecodeBase64(string encoded, char separator)
{
    var data = Convert.FromBase64String(encoded);
    var base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data);
    var array = base64Decoded.Split(separator).Select(x => Int32.Parse(x));
    return array.ToList();
}

var data_b64 = "NzczNTUKMTE1NzM0CjU5OTgzCjEwNjc5OAo3MTM4NAoxMTI0MzEKODcyNjEKOTg0NjkKMTA0NDg1CjYzMTg1CjExMjQ0Mgo5MDExMwo2MjgwNQo3NzYxMAo2MTQ1OQo1NTI5MAoxMzkzMjUKNTg0NjMKNjUxNzMKOTU1NTAKMTAxMjI4CjcwOTEyCjE0NzUxNgo2MjU0NwoxMzc5NjYKNTM4MDEKMTE1OTI3CjEzMzI3NQoxNDczNTgKMTI2ODUyCjExMDM3OQoxMDcyMzQKMTMwMjU4CjEyNzg0NwoxMTgxNjcKMTIyMjIzCjkwOTU2CjE0MTY4OAo4ODI3OAo1NDA0OQoxMzU0OTgKMTIzMTg3CjEyNTE0OQo2MTQ3NQoxMzY2OTEKMTMzMDg5CjEyMDczNAoxMTIxOTYKODgzNDIKOTQ1MzEKMTA1MDEzCjExODM3OQoxMDYwMDkKNzg2OTAKODc5MzQKNzUzOTYKODM1NDYKNjQyMjUKMTA0ODEzCjEyNzgxOQo3ODMyMQoxMDcyMjcKMTA3NjUxCjEzOTc1OAo1MDE1MAo1NTI3MgoxMDY3NzQKNjgyOTAKMTA0NjM5CjE0MDk3MwoxMjE0OTgKODkzOTEKMTA4NDM1CjczNzI1CjUxMDA0CjEwNDcwMAoxMjcyOTcKOTE0OTAKMTAzNTgzCjEyODA0MQoxNDYyNTAKMTQyMDgyCjk1NDc1CjY1Mjk4CjEzMDUxNAo5MjAwMgoxNDE1NTMKMTI2NTMzCjc1MjUxCjE0MzI0OQoxNDYzMDcKNTA2ODEKMTI4MjY2CjEwOTE5OQo3MjQ4Nwo1MDQxNgo5MjE1MwoxMjA2MjcKMTE5MTkyCjU2NTEw";
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
data_b64 = "MSwwLDAsMywxLDEsMiwzLDEsMyw0LDMsMSw1LDAsMywyLDEsOSwxOSwxLDE5LDUsMjMsMSwxMywyMywyNywxLDI3LDYsMzEsMiwzMSw2LDM1LDIsNiwzNSwzOSwxLDM5LDUsNDMsMSwxMyw0Myw0NywxLDYsNDcsNTEsMiwxMyw1MSw1NSwxLDEwLDU1LDU5LDEsNTksNSw2MywxLDEwLDYzLDY3LDEsNjcsNSw3MSwxLDcxLDEwLDc1LDEsOSw3NSw3OSwyLDEzLDc5LDgzLDEsOSw4Myw4NywyLDg3LDEzLDkxLDEsMTAsOTEsOTUsMSw5NSw5LDk5LDEsMTMsOTksMTAzLDIsMTAzLDEzLDEwNywxLDEwNywxMCwxMTEsMiwxMCwxMTEsMTE1LDEsMTE1LDksMTE5LDIsMTE5LDYsMTIzLDEsNSwxMjMsMTI3LDEsNSwxMjcsMTMxLDEsMTAsMTMxLDEzNSwxLDEzNSw2LDEzOSwxLDEwLDEzOSwxNDMsMSwxNDMsNiwxNDcsMiwxNDcsMTMsMTUxLDEsNSwxNTEsMTU1LDEsMTU1LDUsMTU5LDEsMTU5LDIsMTYzLDEsMTYzLDksMCw5OSwyLDE0LDAsMA==";
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
    foreach (var v in Enumerable.Range(0,99)){
        var finalState = ExecuteVm(initialState,n,v);
        var result = finalState.FirstOrDefault();
        if(result == 19690720){
            Console.WriteLine($"Found it: noun= {n}, verb= {v}, result = {100*n+v}");
        }
    }
}
