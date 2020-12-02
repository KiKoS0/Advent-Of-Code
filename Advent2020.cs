﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Util.Utility;

namespace Advent
{
    public static class Advent2020
    {
        public static void Day1()
        {
            var data_b64 = "MTY4OAoxNDYzCjE0NjEKMTg0MgoxNDQxCjE4MzgKMTU4MwoxODkxCjE4NzYKMTU1MQoxNTA2CjIwMDUKMTk4OQoxNDE3CjE3ODQKMTk3NQoxNDI4CjE0ODUKMTU5NwoxODcxCjEwNQo3ODgKMTk3MQoxODkyCjE4NTQKMTQ2NgoxNTg0CjE1NjUKMTQwMAoxNjQwCjE3ODAKMTc3NAozNjAKMTQyMQoxMzY4CjE3NzEKMTY2NgoxNzA3CjE2MjcKMTQ0OQoxNjc3CjE1MDQKMTcyMQoxOTk0CjE5NTkKMTg2MgoxNzY4CjE5ODYKMTkwNAoxMzgyCjE5NjkKMTg1MgoxOTE3CjE5NjYKMTc0MgoxMzcxCjE0MDUKMTk5NQoxOTA2CjE2OTQKMTczNQoxNDIyCjE3MTkKMTk3OAoxNjQxCjE3NjEKMTU2NwoxOTc0CjE0OTUKMTk3MwoxOTU4CjE1OTkKMTc3MAoxNjAwCjE0NjUKMTg2NQoxNDc5CjE2ODcKMTM5MAoxODAyCjIwMDgKNjQ1CjE0MzUKMTU4OQoxOTQ5CjE5MDkKMTUyNgoxNjY3CjE4MzEKMTg2NAoxNzEzCjE3MTgKMTIzMgoxODY4CjE4ODQKMTgyNQoxOTk5CjE1OTAKMTc1OQoxMzkxCjE3NTcKMzIzCjE2MTIKMTYzNwoxNzI3CjE"
+ "3ODMKMTY0MwoxNDQyCjE0NTIKNjc1CjE4MTIKMTYwNAoxNTE4CjE4OTQKMTkzMwoxODAxCjE5MTQKOTEyCjE1NzYKMTk2MQoxOTcwCjE0NDYKMTk4NQoxOTg4CjE1NjMKMTgyNgoxNDA5CjE1MDMKMTUzOQoxODMyCjE2OTgKMTk5MAoxNjg5CjE1MzIKNzY1CjE1NDYKMTM4NAoxNTE5CjE2MTUKMTU1NgoxNzU0CjE5ODMKMTM5NAoxNzYzCjE4MjMKMTc4OAoxNDA3CjE5NDYKMTc1MQoxODM3CjE2ODAKMTkyOQoxODE0CjE5NDgKMTkxOQoxOTUzCjU1CjE3MzEKMTUxNgoxODk1CjE3OTUKMTg5MAoxODgxCjE3OTkKMTUzNgoxMzk2CjE5NDIKMTc5OAoxNzY3CjE3NDUKMTg4MwoyMDA0CjE1NTAKMTkxNgoxNjUwCjE3NDkKMTk5MQoxNzg5CjE3NDAKMTQ5MAoxODczCjEwMDMKMTY5OQoxNjY5CjE3ODEKMjAwMAoxNzI4CjE4NzcKMTczMwoxNTg4CjExNjgKMTgyOAoxODQ4CjE5NjMKMTkyOAoxOTIwCjE0OTMKMTk2OAoxNTY0CjE1NzI=";
            IList<int> data = (IList<int>)DecodeBase64(data_b64, '\n');

            var count = data.Count;
            for (var i = 0; i < count; ++i)
            {
                for (var j = i + 1; j < count; ++j)
                {
                    for (var k = i + 2; k < count; k++)
                    {
                        if (data[j] + data[i] + data[k] == 2020)
                        {
                            Console.WriteLine($"Found it: {data[j] * data[i] * data[k]}");
                        }
                    }

                }

            }
        }
        public static void Day2()
        {
            var data_b64 = "Ni0xMCBzOiBzbmtzY2dzenhzc3NzY3NzCjYtNyBiOiBiYmJiYnhrYgoyLTQgbjogbm5uam4KMS0yIGo6IGpqamoKNS05IHo6IGpnenp6cWhiago0LTExIG06IG1mbW1tcG1qbWtkcgoxMi0xNSB0OiB0d3FyeHR0d3R0dGh0a3hiego4LTkgejogZnR6anp6enpyCjE3LTE4IGg6IGNwa2hzc3ZwcGh6dnByZm5mdAo3LTggYjogYmpiYmJiYmIKNC01IHA6IHBwcHBwcHBwcGdwcHBzCjE2LTE4IHI6IHJycnJycnJycnJycnJycnJycgo5LTE2IHY6IHZ2dnJwdmJ2dnZ2dnZ2dnZ3dnZoCjExLTE1IGQ6IGRkZGRkZGRkZGRkZGRkamQKOS0xNCBnOiBnZ2JnZ2doZ2dnZ2dnZ2d3CjEtNSBkOiBkZGRkYmQKMS00IHg6IHh4eHd4eHgKMS0yIGw6IGJkampkZGxxZwoxLTQgYjogbGJieGIKMTUtMTYgZjogZmZmZmZmZmZmZmZmZmZtegoxMC0xNiBtOiBtbWxtbW12bW1tYmhtbW1xCjQtMTUgdjogdmxmdnZxcGhoamZ2bGd0CjUtMTIgbTogbW1tbWptd21tbW1jbW1tCjctOCBxOiBxcXFxcXF4a3EKNC05IGg6IGhoemhoaGhoaGhoaHNoCjMtNyB0OiB0aGx0ZHRqdHN0enJ0d3R0CjYtNyBrOiBra2tra2trCjEtNSBxOiBqcXdxZAo0LTEzIHg6IHh4eHh4eHh4eHh4eHh4eHh4eAoxLTQgbDogbGxmbAo2LTEyIG46IG5uZmZuZm5ubW5mZm54CjQtNiBtOiB4bXZ4bm1wbW0KNS03IG06IG1tbW1ibW1tbW1tbW1tCjktMTcgZjogZmZmZmZsZmZiZmZmZmZjZmZmZgo0LTEwIGs6IGtra2xra2tra2hrdGtrYmt6cQo4LTE1IHo6IGtkeHh6emxocHpnYnpqenoKMi01IHE6IHFycXFicXFxcXFxcWtxcQozLTUgdDogenJ0dGh0CjktMTIgdDogdHR4Z250am12bnRjdHBmcnQKMi0zIGs6IGtra2sKOC0xMCBqOiBqampqampqampqCjItOSBrOiB2a3draGNxbmsKOS0xMCB0OiB0dHR0dHR0aHR0CjQtNiBiOiBiYmJiYmJiYgo5LTEyIG46IHhudm5udmxkaHRobHNuCjItNCB3OiB3d3d3d3dqCjYtMTAgdDogdHR0dHR3dHR0dHZ0dAozLTEwIGo6IGpxampqeGpkam5qampqCjE1LTE4IHE6IGtxbG5jZHF3Y2xxcGp6cmJucQo3LTggcDogZ3B3YmpwcHAKMy0xMyBtOiBtbW1tbHNtZnZtaG1tbW0KNy0xMCBzOiB3ZHNoc3JzZ3NsCjgtMTYgZjogZmZmZmZmZnhmZmZmZmZmY2YKMTYtMTggczogc3Nza3N3aHN2c2x3c3NzcnNxCjEyLTE0IGo6IGdqampqa2pnamtqaGp2agoxMy0xNCB0OiBndHR0dmZ0d3RndmhsdAo2LTcgdjogdnZ2dnZnYnYKMi04IGw6IHNzbGRzbG12bAozLTkgbDogYmZsemxscWtxbGtsbAo4LTkgbjogcnJubm5ubm5zbgo3LTE0IHA6IGJxc3J4Z3Bsa3BkdmJwa24KMi01IHo6IHd6YmNsbnN4dAoyLTQgazoga25reGsKNi04IGQ6IGRyZGRqZGRqZGQKMTUtMTYgcDogenRncHRwZnBjd3BwcXJ6cHBwcwoxLTMgazogbm1zcWtzdgo3LTEwIG46IHB3aGJjd25sem5mbnZybG5kcwoxMy0xNSB0OiB0dHR0dHR0dHR0dHR0dHR0dHQKMTAtMTIgYjogYmJiYmJiZGJiZ2Z4YmJiZgozLTUgdzogcnd3d2oKMTgtMTkgeDogeHh4eG14eHh4d3B4eHhmeGdsbgoxLTQgZzogbGZzanRnZ2dnCjEzLTE1IHg6IG14emd0eGhyeGpoeHRuZgoxMy0xNCBkOiBkZGRkZGRkZGRkZGRseAozLTUgcjogcnJydHJydG1scgoxLTcgdDogdGh0dHR0dHR0dHQKMi01IGc6IHNuZ2dnago4LTkgbjogdG5ubm5ubm5uCjYtMTAgdzogd2t3d2pmd2x0awoxMi0xOCBuOiBubm5ubm5ubm5ubm5ubnNubmgKMTQtMTggbTogbW1tbW1tbW1tbW1tbW1tbW1tbW0KNS0xNSB2OiBmdnZmcmNxa3ZrZ2ducGwKMTMtMTkgZjogZmZmZmZmZnRmZmZkbmZmZmZwc2YKMTMtMTUgazoga2dra2tta2trZ2Z0a2xiCjQtNiBoOiBoaGhjaHZoCjctMTQgbDogcW1iZGhkamJyZ2x4cWwKMTMtMTcgdzoga3d3d3d3d3d3d3d3ZHB3d3cKMS01IHE6IHBxcXFkcXFxcQo4LTkgcDogdmh3cGh2cGZwCjItNCBoOiBobGptaAoxLTIgYzogdG1jYwozLTUgZjogZHBudndmZmhscAozLTUgbTogbW1tbW1tCjEwLTEyIGM6IG5nam5jem1jc2N4YwoyLTQgeDogbXh4ago0LTYgbTogeGJta21tCjEtNiBsOiBrbGxsbHNibHFobmdsCjExLTE4IHg6IHhwcmtqY3J4a2d4eGd3dGJteAo0LTYgazogdnd4c2hra2trYnRmYmhsCjExLTE1IHo6IGR6emt6amp6enp6enp6bG16Ym4KNS02IGY6IGZmZmZuZmZmZmxmamZmCjMtNiBkOiBkZGRkZGRiZAo2LTkgcjogd3JycnZycnJyCjgtOSBuOiBubm5uam5ubnQKMi03IGI6IGJ4cHRka2N0YnJ4ZmxscHZqCjMtNCB4OiBoeHh2CjUtMTQgbjogbnJubm5sc256bm56cnFuanhucAoxLTMgdzogd3d3dwo5LTEyIHg6IHh4bXh4eHh4eHh4eHR4eAoxMC0xNCBqOiBqam5qampqbHZqa2NzampkbGx2ago0LTYgdzogd2d3Ynd3d3cKMTAtMTIgdDogdHRxdHR0dHR0dHRsCjEwLTExIHQ6IHR0d3R0dHR0dHR2CjktMTUgdDogdHR0dHR0dHRmdHR0dHR0dHQKMi0zIHA6IHBmZ3AKMi00IHo6IGJycmtzbnZxanp3cWp2anMKOC05IG46IGtubm5mdHpqYnFqCjYtNyB3OiBzd2p3d2R3d3d3d3d3d3cKMS0yIGo6IHhqbHJramp6dHJqZnBzcwoxMy0xNCBsOiBsbGxsbGxsbGxsbGx2bGxsbGxyCjctMTIgbDogbGxsbGxsbGxsbGxibGxsbGwKNy04IGo6IGdxZGNtanFoCjMtOSBnOiBnY2hrYnZndmd3CjE1LTE3IGI6IGJiYmJjYmJiZ2JiYmJibWJnCjEtNyBoOiBxbG1oaGNkaGhoaGhoaGhoaAoyLTE1IGM6IGNjY2NjY2NjY2NjY2Njc2NjY2MKMS0yIHE6IHh2Y2gKMy05IHc6IHd3d3d3d3h3d3cKMi00IHg6IGpza3gKMy03IHQ6IGJ0d3NudnRzCjktMTEgZzogZ2toZ3djdGdnYm0KMi03IGc6IHh2Z3d3bHRkdm56c2NidHF3YgoxLTExIGs6IGtrcWtwa2tka2tra2tra2hrawo0LTEyIGg6IG5icWxoamJxaHh0bnhsemxyCjMtNCBkOiBkd2RkCjgtOSBrOiBra2t6YmNra2xxcWtoZmtxa2sKNy04IGM6IHBjeG1xZHdjCjItNCB2OiBxYnZ3dnZudnZwCjMtOSBjOiBwZnFjYmx3eGNybXgKMS05IHQ6IGZ3Z3RjcmZ0a3R0CjctOCBwOiBwcHBwcHBwcAo2LTEzIHc6IGRud2Zod2tqZmZwZHdnemRmCjEwLTE0IGs6IGtra2tra2hra3dra2tra2sKMi00IHM6IHpzY3NzZGR0cG1xYmxtZAoxMS0xMyBiOiBkYnZ6d3RobGNtYmtiCjEtNCBrOiBrcWx4d3Zia2Nrd3ptcXh2dGNjCjItMTAgczogc3hzc3NzZ3Nzc3hzc3Nuc3MKMy05IHc6IG54cm13bHBndwoxMC0xMyB3OiB3d3Nnd3d3d3d3d2t3CjktMTMgdjogdmh2dndqdmN2YnZ2Zwo1LTcgbjogZmJ2bmpwdAozLTQgeDogeHh4eAo5LTEwIGw6IHJsbGxtbGxsbGwKNy05IGQ6IGRkZGRkZGRkaGQKNC04IHo6IHp6emh6enpmCjExLTEyIG06IG1tbW1tbW1tbW1rZgo0LTggbTogYm1menBwY3F0dGN0CjItNCBtOiBtZm1jbW1tY3gKMi05IHA6IHJwcHpndnNobgo3LTggcjogcnJycnJycnJycnZyCjYtNyBwOiBoa2x0cHBwCjctMTAgbTogbW1tbW1mbW10bW1tcGJtbQo2LTE0IHA6IHBwcHBwcHBwcHBwcHB4cAo0LTYgcDogd2JzcHBwbmxtYwoyLTQgbjogeG5mbmwKMi01IHE6IG5xa2NxbXZ3cAoyLTMgZDogZGRrYmtkamQKNS05IGI6IHF4amJibGJyYgoxNC0xNiBiOiBiYmJiYmJiYmJiYmJicWJiYgo1LTYgcDogZHBwcHBwCjUtOCBqOiBreHp0bmpqbgoxNC0xOCBrOiBrcmtra2tja2tra21rdGtra2tkCjctOCBuOiBubm5neG5mcG5uCjE2LTE3IGM6IGNjbWNjY2NjY2NjY2NjY2ZjY2NjCjEtMyBnOiB3Z2dnCjEtMiBjOiBjcWNja2MKMi04IGc6IGdqd2RrYmRzCjEwLTE3IHM6IGhzd3Fzc210dHNrc3BkbGtrc3MKMTQtMTYgYjogYmJiYmJiYmJiYmJicGJicmJiYmIKMTItMTYgcjogc3JybWNicnJjcnpyZHd6bmcKMi0zIGg6IGZjd3MKOS0xMyBwOiBna2dwcXBnaHBqYnB6CjktMTAgbTogbW1tbW1tbW1tbW0KMy00IGI6IGJyYmIKMi0zIHA6IGduY3ZxZGhwCjItNyBnOiBnZGdnZ2dnZ2dnZ2dnZ2cKMi03IGo6IGpqampqanJqcWpqagozLTUgdjogbHRwdGpsbnRmCjEtNyB3OiBnd3d3d3dmd3cKNy0xMCB6OiB6enp6enptenp6egoxMC0xMiB4OiB4eGh4eHh4eHhneHN4eHh4CjExLTEyIGI6IGJiYmJiYmJiYmJiYmQKMTYtMTcgdjogdnZ2dnZ2dnZ2dnZ2dnZqaHQKMS00IHg6IGJ4eHgKMTYtMTkgZzogZ2dnZ2dnZ3dnZ2dnZ2dqZ2dnZwo1LTEwIHE6IHFqcHFxdmxua3F4bWx2CjQtNiBwOiBxcnBmZnBsdnBwCjctOSByOiBycnJycnJncmIKMi0zIGc6IGJnamcKMTAtMTIgdDogdHRqdHR0dG50dGR0dAoyLTQgZzogZGduZwoxMS0xMiByOiBycm1ycnJscnRycmoKMS01IHY6IHF2dnZ2dnZ2dnZ2dnZ2dgozLTE4IHA6IGZ0bmZucG1qcHJtcnptaGJueGoKMTAtMTIgdzogZHFuc2pqeHNxcndxCjItNCB6OiBsemdrenNiCjgtOSBuOiBkd2NseGR0bm5kdHBjZ3FteAoxMC0xMSB3OiB6andkc3BoYmJ3bGhwCjItOSBkOiB6enBya2d6Y3picwoxNC0xOSBjOiBncGpmcnZzcmNuYnhiY2xjdHhjCjEtOSBmOiBmbWhmdmZmZnJmd3MKMTItMTQgZDogZGRyZGRiZGRkZGRkZGRobWRnCjE0LTE1IHM6IHNzbHNzc21zbnNzZHhzagoyLTEwIHY6IGxqcHB6amZ2Zm5mcAoxLTIgejogcWJ3YnprbnJ6enMKMTgtMTkgbDogbGxsbGxsbGxmbGxsbGxsbGxsbAoyLTMgcDogcHBncAoxMy0xNSBrOiBrbmtra2trY2tra2toa3hrCjMtNiB2OiB2Ymp2bXYKNC04IGg6IGhtaGN4ZmhnCjEyLTE0IHY6IHZ2bmdjdnZ2dmt2Z3ZzCjItMyBqOiB4ZGpqcmsKNS0xMyBzOiBzc3Nzc3Jxc3Nzc3NxCjEtNyBzOiBzc3Nzc3Nzc3MKNi0xNCBiOiBwdGx2bWJicmJ4bnZxYnJtcAoxNi0xOCB3OiB3d3dzd3dud3dtd3d3d3d3d2YKMS00IGs6IGtra25ra2trawoxLTQgZzogZ2dyYmsKOS0xMSByOiBycnJocnJycnJycnJyCjExLTEzIHg6IHh4eHh4eHh4eHh4eG54CjMtOCB4OiBuc3h2bHZkZmJrcHhzZ3NjbgoxMi0xNSBoOiBoZ2hoY2h2amhoaGhsdmhoaGhoCjExLTEyIG46IG5ubm5ubm5ubm5qcW4KMTAtMTMgcjoganJ6ZnpyenJxYmxta3MKNy04IHc6IHd3d3d3d3doCjMtNCBrOiBra2JmdAoxLTkgYzogY2NjY2NqY2NjY2NjbgoyLTcgcjogcnJ2bnJ4cnZyenNyYnJzCjMtMTAgbDogbGxnZGxkbWxwbHFsaGRsbGwKNC04IG06IG1tem1ibWdtCjUtNiBxOiBzZnhxbmZ0bmJucXdxCjUtNiB2OiB2dnZ2Z3Z2cXYKOS0xNCBoOiBkaG13cmh6cXF2aGhoZmhmaGhodAo0LTcgcDogand3cHB2cGtsYwo5LTEzIHo6IHp6enp6enp6enB6enp4CjEzLTE0IGw6IGZsbGtsbHRsbGxsbGNwaGxsbGwKMTItMTUgbTogaHRtYm1xZ2xqY212bWNsZ25tCjktMTAgYjogYmJiYmJiYm5iYgo2LTEyIHg6IG54amJ4eGh4eHh4Z2R4eAo2LTcgdDogdHR0Yndsawo4LTExIHE6IGZxcWp0bHN3cWdrcWRxYwoxNi0yMCB0OiB4cGx3cXhid3RzZnB0YnZ0dmN4dAozLTQgazoga2tsa2tra2treGtra2sKMy05IG06IGttbXN2bXBteG1nbWIKNi0xMiBqOiBqanRqampqampqanBqandqCjMtNCBtOiBra21ibXpreAo3LTggZjogZ21meGxnZmp0ZnN0CjEtMyB3OiB3d3duCjEtNyBrOiBrbmtrdGtrbgoxMy0xNiB2OiB2dnZ2dnZ2dnZ2dnZ2dnZtdnYKMTAtMTEgaDogcmh2ZGhuZmh2dGNobGZoaAoxMC0xMiB4OiB4Z3h3YnF4a3h4Y3dzZmQKMTAtMTQgbTogbW1tcmR4cGNtY21tbWttbW1tbQoyLTUgeDogdnZ4cHgKOC05IGg6IGhoaGhoaGhtZmgKMTYtMTkgajogam13ampqampqampqampqampqegoyLTMgcjogc3FybnIKMTQtMTkgcDogcHBwcHBwcHBwcHBwcHBwcHBwawoyLTUgdzogd3d3d3cKMTUtMTYgcTogZHBweHRuaG14cmhtbmNycXEKNC01IHY6IGRyaHBwCjEtNCBwOiBwa2huCjMtNiBxOiBnd21yZndoCjYtMTAgdjogZGx2dmZodnZrYgoxLTggcTogcXFxcXFxcXFxZHFxcXFxcXFxCjE3LTE4IG46IG5ubm5ubm5ubnhubnpubnBubmcKMy03IG06IGdteHpmZndtYmRtCjEyLTE0IG06IGRtem1jbW1oam1xbHRtCjMtMTYgdzogZHJjYnd0dnFnYnBwYnd6dm0KOC0xMCBkOiBkZGJkZGRkemRkZGRka3BkCjgtOSBtOiBtbW1tbW1tbW1tbW0KMS0zIGw6IGdsbGwKNy0xMSB4OiBmeHJ4eGR4eHhxeG54eAo2LTcgZDogZGRkZHhnZGQKNy04IGc6IGhnZ2diZ2dnCjItMyB3OiBwd3d0d3cKNy0xMCBoOiBsaHdiaGpoemh4CjMtMTQgYjogYmJicnZyYnNmYm54cmdxYmJxCjQtNyBsOiBqenFreGxucHhsZ2xmc2xsCjYtNyBiOiBoYnBiYmJiCjItNCB3OiBwc2t3d3h6cGp2bXdjbmZyCjEzLTE1IG06IG1tbW1tbW1te" +
    "G1wbXhtbW0KNC05IGs6IGtyeGt6cXpra2hycHF0aAo0LTcgZjogeGZmZmt2ZnF6d2hjZndraHEKNC0xMCBxOiBxcXFxcWNxYnFxcQoxNC0xNSBzOiBsZ3N6c2RzdHN0bHBnamJzCjctMTIgczogc3NwYnNzc3NrZm5zCjctOCBkOiBjZGRkcXBuZAoxMy0xNSBwOiBwcHBwcHBwcHBwcHB4cHBwCjEwLTExIHI6IHJycmZ4cnJycnJycnJyCjEwLTEyIHo6IHp6enp6enp6enZ6dnp6CjMtNCBsOiBsbGx3bGwKNy05IHA6IHBwcHBrcHBwcXBwcHBwc3Z4CjMtNCBrOiBra2tyawo0LTUgdjogenhtbXZtaHZyCjE0LTE1IHI6IHJycnJycnJycnJycnJmanIKNi0xMCBiOiB2d2JnYmJiYmRicXNiYgo1LTcgajoganNqamprdgozLTQgbTogdHptaHIKMTEtMTMgcjogcnJycnJycnJycnFyaHJyCjEtNCBzOiBwc3FtY3NzbmsKNS02IHo6IHpka3p6enoKMy01IHA6IGNucG1idGtucWRwcG1janB6dmNuCjEzLTE0IGc6IGdnZ2drZ2dnZ210Z2dkCjE0LTE3IGM6IG54bXpjY3pjY252ZGN4cGNtYgo2LTEwIHc6IHdsd3diZHd3d3d3d3d3CjktMTcgbDogbGxsbGxsbGxsbGxsbGxsbGxsCjItMTIgajoganBqZGpqanptanhqCjEtMyBuOiBzempudG5ubAo3LTggbDogZHB4bG1obGJ0cwo1LTE2IHM6IHNzc3Nzc3Nzc3Nzc3Nzc3JzCjEtNiBtOiBwbXF2bGMKNy0xNSBmOiBmZmZmZmZmZnFma2ZmZmR4ZmYKMTAtMTEgdzogd3d3d3d3d3d3d3N3d3d3CjctMTIgcDogdGtwcHZmcHdrc3JwCjQtNyBmOiBmZGpkZ2R2c2tzYmZibmprc3BjCjQtMTEgYjogYmptdmZybWxtbGJuZGwKMS0zIHI6IHJycm54aGdid3IKNS0xMCBoOiB4aGhtaGhobGhiaAoxMC0xMSBoOiBoZ2hoaGhoaGRsaGhoCjUtNiBnOiBncHRnbGcKOS0xMSB0OiB3dGd0eHR0dHF0bXR0dAo1LTExIGY6IGp4cWZmaGZzZm16CjQtNyBmOiBmcmpmZmJmCjEtMTUgbTogbW1tbW1tbW14bW1tbW1tbW0KMS0xMiBkOiBkcndsYnBkYnpkZ2RqcG56bWoKOS0xNCBuOiBuZm5ta3Rqbm5jbm5ubG4KMS0yIGg6IHBzaGhqaGhoaGYKMi00IHQ6IHRndHR0dHR0ZmIKMi00IHc6IGR3cHdobnhiZgo3LTExIGI6IHZiY2J6aGJ3aHBiCjQtNSBrOiBoa25jawo1LTEyIG06IG1tbW10ZG1tbW1tbW1tCjUtNyB3OiBxd2Zsd3hxCjItNSBnOiBqZG54ZGxjbHBsdmIKNS03IHQ6IHR0cnR0dHR0a3IKOC0xOCBsOiBsd3NjandsbWRsemxsbG5zbGxwdwoyLTggYzogY2NjeHRjY2NoYnJrcgoxLTMgcTogcXF0cXFxcXEKMy0xMyBkOiBkZGRkZGRkYmRkZGRkZGQKMS03IHI6IGprcHpycGZucmdwa2MKOS0xMCB0OiB0dHR0dHR0dHR0dAoxMS0xMiB3OiB3andwbHd3d3d3bXcKOS0xMiByOiBycHN2cmhyYm5yd3FjaAo2LTExIHA6IHpwemJwa3BtdG5wdHNucGJzd2MKNC02IHQ6IGpoenN0dAozLTQgdDogZGRwa2NncHpoZAo0LTYgczogY3Z6c2hqZnJzc2x4bnNscWRkd3QKMS0zIGM6IGNnc2N6aGwKMS00IGQ6IGxkZHFkcWQKNi03IHY6IHZ2dnZ2dmIKNS04IHc6IHd3d3d3d3d3d3cKNS0xMSBwOiBkZHN3cGJwcHBzcXBwCjUtNiB4OiBkZnp4eHhoaHFqdmoKMy03IG06IG1tbW1tbW1tbW0KNC04IGc6IGdnZ2dnZ2dnZwo1LTYgajogampjampuCjUtNiBuOiBubmR0bnMKNC01IHQ6IGx0eGtkcHN0CjItOCBiOiBsZHdrYnpieGdwYmJiYgoxMS0xMiB3OiB3d3F3ZHF3d3dxaHZ3d3cKMTUtMTcgazoga2xrY3hxYndya3R4Y21xbG5iCjUtNiBrOiB0a3Foa2tra3JramZkCjEyLTEzIHg6IG54eHhyanh4eGRqbHh4YnQKOS0xMiBtOiBtbXptbW1ybW1mbWdtbW1tYgoyLTUgdjogdGtiaHZsdnAKMTItMTQgdjogZHZidnZ2dmhyY3Z2dnh4dnZ2dnYKMTQtMTYgeDogeHh4eHh4eHh4eHh4eHJ4eHh4CjYtNyB2OiB4dnN3bnZ2bQo2LTkgYzogdmNwY2tzeHdiZGxjCjUtMTEgczogc3Nzc3Nqc3Nzc3JzZGpzc3NxCjYtMTYgajogampqamptampqampqampqbmoKOC0xMiBnOiBnZ2dnd2dnZ2dnZ25nZ2cKNC01IGM6IGNjY3prCjE0LTE1IGw6IGxsbGxsbGxsbGxsbGxrbQoxMC0xMSByOiBycnJycnJycnJycnJyCjMtNSBuOiBkd252bmxqCjItNCB4OiB4ZHh4eHgKNS02IGo6IGpqampqamoKMy05IGs6IGtra2traGxya2t0dAozLTcgdDogc3RxdGdmZHBydHFqc2d6bnJ0amgKMTEtMTYgbjogaHNubm5ubm5ubmZudm5wcW5ubgoxMy0xNiB2OiBrZHZidnh2dnR2aHZ2dnZxCjEtMyB2OiB2d3B2a3ZkcHhnYwoxNC0xNyB2OiB2dnZ2dnZ2dnZ2dnZ2bnZ2aHYKMTQtMTUgbTogbW1tbW1tbW1tbW1tbXRtCjYtMTAgbTogbW1tbW1obW1tbQo1LTggdDogdHR0anJ0dGRzdHRmdHR3c3RmCjYtNyBjOiBjY3FjdmNjCjItNSB2OiB2dnZ2dnYKOC0xNiBjOiBjY2NjY2NjY2N3Y3BjY2NtY2NjYwo0LTUgdDogenR2dHRrdHR0dHR0CjEwLTExIG46IHJubW5ubm5ubm5ubm5ubnB0CjUtNiBnOiBsZ3NnZ2dnZwoxNS0xOCBzOiBsY3NtZ2tqcXpkcGNndnNybmcKMi02IHA6IHd3cHBwcAo5LTEwIHY6IHZ2dnZzdnZ2bXZ2CjYtMTEgYzogcXJtZGp4enNteGNtY2NjZ3JyCjE3LTE4IGI6IGJiYmJiYmJiYmJiYmJiYmJiYmJiCjYtMTAgdDogdGh0eGd0cHh3dAoyLTggZjogeGtnYnJwcWZzcmhoYm5mcGRnCjMtOCBjOiBncWtrdmdrY3Fmd2RjCjUtNiBjOiBqamNzamYKOC0xNiBxOiBmYndkbWx3bGpxcWNycXNxCjMtMTAgbTogbWptbXNtbW1tbW1jbW0KNS0xNSB4OiB4bXJ2Y3Nqd3h4ZHBzcnh6Y3J6agozLTcgeDogcnhuZ3p4eGcKMTctMTkgejogbW12Zmd6cG1idnpzcm1rZ21tbWIKMy00IHo6IHpkenoKNC01IHY6IHZ6Y3ZiCjMtMTEgejogdHpsbHBnenptd3h6bmgKOC0xMSB4OiBwdGd2bmJ4enN4d2RiCjItMyByOiBycnJycgo2LTEwIGI6IGJibWJiYmJiYmIKNi0xMSBxOiB3dm1xcnpybGxoeGZ6bXBrcAoxMy0xNyB2OiB2dnJndnZzdnZjcWt2dnZ2YnZ2dwoxNi0xOCBwOiBwcHBwcHBwcG5wcGdwcHBwY2xwCjEzLTE1IGc6IGdnbGdnZ2dnZ25nZ2dnZ2dnZ2dnCjE1LTE3IGI6IGJiYmJiYmJiYmJiYmJiYmJiCjMtNiB0OiB0cHd6a3RsemtkdAoyLTMgbTogbG12dG5manptbQoxLTcgajoganpqamZqeAoxNS0xNyByOiBydGZkbmhycmhycmRjc3dybAoxLTMgZDogZ2RmZG1kZGRkd2RkZGxzZAozLTQgcjogcXJ0cgoxMC0xMSBtOiBtbW1tbW1tbW1rYwoyLTUgbjogZ250bm5ubmNjCjktMTQgYjogYmJiYmJiYmJiYmJiYmIKMTAtMTMgZjogZnhmZmZ6bmZmZmZ6d2ZmZmx6CjUtMTIgajogdmpqcmpqampuZ2pqamptCjYtOCBrOiBra2tya2tsa2tra2trawo1LTcgcjogcnJoenN4cmpqdwoxNy0xOCBnOiBnZ2dnZ2dnZ2dnZ2dnZ2dnZ2YKMi0zIGg6IGdoaHZyaAoxLTMgajogaGpqeGpqamoKMy01IHE6IGdicW5xa3ByY2t4cWdsa2h3CjE3LTE4IG46IG5nbm5ubm5xbm5ubm5ubm5ubm5uCjItMyBtOiB4bGhtbXEKNi03IHA6IGt2dnBoZ2oKOS0xMiBrOiBrcGt6a2t6a2tra2tid2sKOS0xMCBrOiBra3Jra2tra210CjUtMTAgdDogdHR0dHR0dHR0dHR0dHR0dAoxMC0xMSBsOiB6dGR2bGxsemZsdGx3bGdsa2hjago3LTEyIHQ6IGJ0dHR0cXRxdHR0dHR0dHRnCjMtNCB6OiB4enZiCjUtMTAgaDogbGhjZGhraGhoaGIKMS02IHo6IGpxenpxenp6enp6enp6enp6ego2LTcgeDogcXh4eHh0eHoKMTMtMTQgZzogZ2dnbmdnZ2dnZ2dyZ3NnZwoxLTIgdDogdHR0dAoxMS0xNSB3OiBocHdod213bGtid3R3bXdsago4LTEwIHI6IHJucmhycm1wcm5ycnIKNS0xMiB6OiByc2h6aHdnemhmamIKMTUtMTYgczogc3NzcXNzc3Nzc3NzbXNzcwo5LTEyIHo6IHpkenp6enp6a3ptegoxMC0xMiBjOiBtZmdwc2tuY2ZjZmN0am10CjUtMTAgcDogc3Bwd25wZHBwdHBwd2RwcHBwcAozLTE0IHE6IG1uemZnZm12bXNkbHFnCjEtMTMgczogc3Nzc3Nzc2Zzc3NzYnNzcwo2LTggZDogZGRkZGRkZGRkCjItNSBqOiB2c2JiamgKMTQtMTYgbTogbm1rbG1zcnBqeHdwZGJtagozLTggdjogcmZ2dnZqcXYKMTgtMjAgcDogcHBwcHBwcHBwcWhwZmxwcGJwcHAKNy0xMSB4OiB4eHh4eHh3eHh4eAozLTQgbDogbGxtdmxsbAo4LTkgdzogZ3Jtdnd0d2J6CjItMTEgbTogbW1tbW1tcW1tbXNtbW1tbW1tbW0KNi0xMyBoOiBoaGhoaHJzaHNoaGhsaGhoaAozLTEyIHQ6IHRudHRibHR0dHRjdnJ0dHR4CjUtMTggZjogY2ZmZmNmZnZnZmZmZnJtbGZ4CjEtMyBuOiBybmpubm5ubm5ubm5ubm5ubm4KMS0yIHc6IHNtbWRxCjEtNSB2OiB2dnZ2dnYKNS0xNSBzOiB0c3Nzc3Njc3NmZmhzc3dzc3NzCjMtMTEgYjogYmJiYmJiYmJzYmtiYmJyCjEzLTE1IGo6IHhqanBqamNqampqampjago1LTEwIGc6IGJ2anZncHpnZGdrbW16d253cnh6CjItNyBxOiBxcXFxcXJxCjEwLTEyIGQ6IGZkZGRkYmRkZHhkcXBkCjUtNyBjOiBoc2NjamNjcmxtCjExLTE1IHI6IG5ycnJscnJ2cmRscnBydwoxMy0xNCByOiBkcnJ0YnJycnJycnJyY3Jycgo4LTEwIGM6IGNjY2N4Y2NoZmpjY2NjY3hwYwo4LTkgczogc3Nzc3Nzc3NzCjEtMTAgcjogcnZsZ2tycnJybQo4LTEzIHc6IGp3Yndjd213d3Z3d3d3d3cKNy0xMiBrOiBmeGtrY25ra2J2a3hia3BoeAo3LTggbDogbGxsbG1sdmxsCjExLTE1IHE6IHFkanBxd2dmcWpkcW5ucQo4LTkgbTogbW1tbW1tbXZtbW0KNi03IGs6IGtra2tzbWtiCjQtNiBoOiBoaGhsaGhoaGZoaGhoaGgKMi01IGs6IHh6amx3YgozLTEyIGo6IHNqd3FyanpqZ3Fyago1LTE4IHA6IHBwcHBwcHBwcHBwcHBwcHBwaHBwCjEtMyBnOiBnZ2dyZ2dnZ2cKMTQtMTUgbjogbm5ubm5ubm5ubnhubmhubm4KMTktMjAgZDogamtwenN4d3NkZHpjY2pka2NwdGoKMi00IHY6IHdwZHoKMS04IHc6IGR3anRuZ3d3d3J3aHAKMTMtMTUgdDogdHR0dHRjdHR0dHR4dmZydAo2LTExIGg6IGtzdnNocWhoZHRoCjgtOSBrOiBraGZrZGtwcGwKMTEtMTIgZDogd2hsbWNkbWZnZmRkZAoxMS0xMiBwOiBodHZ4cGtmbmd0aHoKNi05IHY6IHZxdm12dmJidgo1LTggbTogbGdobW1tcm1tdwoxNC0xNiBxOiBkdG1xcXJxcXFxcWdwZ3F0cXIKMi0xMSBmOiBiZmpza3h6bGd2Zm1sCjEwLTE5IHA6IGtwcHBwcHBwcGhwcHBwcHBwcHAKNS03IGo6IHJmYnB6bWp0amoKOS0xMCBwOiBrcHBwcHBwcHFwcAozLTE1IGs6IGhna2dycWJsbmptc2J2cmdoemRrCjYtNyByOiBycnR3cndsZnJzd3dyCjMtNCBrOiBma2tkdgoxMi0yMCBnOiBnZ2dnZ2dnZ2tnZ2dnZ2dnZ2tnaAozLTUgeDogeHh4eHB4eHh4eHh4eHhiCjgtMTAgazoga2tra2tra3praAo0LTEwIHE6IHFxcW1xcXFxcWNxcQo0LTEyIHQ6IHR0Z3RxYmx6cXpwdHRjeGR0Zm4KMTgtMjAgczogc3NzYmJzc2NzanZzbHN2c3Nzc3MKMy02IHg6IHh4eHh4eHgKNC01IHQ6IHR0dHR0dAo1LTcgcTogeHFxcXFxcXF4a3FxcXFxcXF0cXEKMi00IHM6IHpzdnEKNi03IGI6IG1tYmNrbHgKMS0xMyB6OiB6emZ6a3NocHNsd2NuCjEtMTQgZDogZGRwZGR0ZGRkZGRtbWYKOC0xMyBqOiBqampqampqampqampqampqanoKNS02IGM6IGNqamx4YgoxMC0xMiB2OiB2dnZ2dnZ0dnZtdnYKMi0zIGI6IHdmYmJnCjEtMTAgbDogbGxsbGxsbGxsbGxsbGxsbGxsCjUtMTAgZDogaGRiaGRneGNqZAoxMC0xMyB0OiB0dHR0dHR0dHR0dHRudAo1LTYgaDogdmhtaGhoCjE2LTE3IHg6IHh4eHh4eHh4eHh4eHh4eHNxeAo2LTE0IGc6IGd6Z2dnZ3poZ2dnZ3pnZwoxNS0yMCBmOiBmZmJmeGZmZmZ2ZmZmZmZmZmhmZAoyLTMgZDogeGR2dwo1LTcgZzogemdnZ2pncQoyLTEyIGc6IGdnZ2dnZ2dnbWdnZ2dnZwo2LTggaDogaGhoaGhocGhoaGxoamhoeGZoCjMtMTAgajoga25qa2xzdHF4d2NzamYKMi0zIGg6IGh2bndqeGhwc2MKNy04IHc6IHd3d2x3d2d3CjE0LTE2IHM6IGNoZ3Rwc3dzc3hzcXR3enJzcXQKNS02IGQ6IHpkYmRrbAozLTQgcDogbHdrcGJyYnAKOC0xNCBjOiBjYmh0Y2NqbXJjY3JjcAoyLTMgczogdGN0ZmxtZ2R0c2pqZnhwbAozLTQgZzogZ2dnamtjdHdkc2dsCjItNCBoOiB" +
    "naGJoCjQtMTMgaDogZmN6cGhodmZsZ2hoaGQKMy0xMCB4OiBqa3poZ2xqd3NibGNybWJ3ZngKMTItMTMgcDogbnBmZ3BwcHJ6cHBwYwo3LTEyIGw6IHNxYnBsbXFubG13cGgKMS04IHA6IGhwcHB2cHBycHBwCjEyLTE4IG46IG5oYnpuem54bmNua2NjaHNjbAo5LTEwIGc6IGdyanhtZ3pwZ2sKNi03IGc6IHJjbWtnZ2dnZ2dnCjEtNyBiOiBiYmJiYmJiYgoyLTMgdDogdHRmdHpxdAo4LTEwIGw6IHR3YmpsbmJsaGNrCjEtMiBjOiBjdmJjCjQtOSBkOiBtZnBkZGRzbmQKNS04IGY6IGZscHZiZHJmbAo3LTEyIHM6IHJoc3BzeGxicHNtc2NsenJkc2ZjCjItNCBoOiB2aGhoCjEtMTAgazogYmhra2tra2t4a2tremsKNS0xNSBxOiBxcXFxcXFxcXFxcXFkcWRxcWwKMTItMTUgYzogbGp2Y2tsd2p2bmdmZ2Zncmpzdgo4LTEwIHc6IHB3d3RwYnd3dnd3cnd3dwo1LTEzIGI6IHRiam1iZm1rbmpoYmIKMS0yIHY6IGNzc2QKMi01IHM6IHNzc3NzcwozLTQgaDogYmhoeHhoZmgKMy01IHA6IHBmcHBwCjEzLTIwIGw6IGxjeHhsbGNmam1sbGNsbGpsbGZsCjItNCBwOiBzcXB6awoyLTQgbDogeGxsbGIKMS03IHQ6IHR0dHR0dHJ0dHR0cnR0dHR0dHh0CjEwLTEyIG06IGJ3bW1naHptcW1tcG1qCjUtOCBsOiBqdGxsanBxbAo1LTYgZDogbGRkZGRkCjYtOCBjOiBubGpjemNjZHd2bm1ybHF2bHNjCjgtOSBkOiBkemRkZGNkZHQKMTAtMTEgejogenp6enp6enptcWoKMy00IHM6IG1zc3NzcwozLTUgejogeHp2ZHpienQKMi0xOCB2OiBidmNicHdrYmRtY2xibmJtc3YKOS0xMiBiOiBqcmNjY3NuZHN0emJ4cHJrdnRxCjMtMTEgbjogdmxudGdsenZ2Y25uZ24KMy04IHY6IHJwZ2Nrd3B0bHZkcXNycXF0CjYtMTEgcTogcWRxZGtxdmt2aGRyZHFtCjktMTIgYjoga2hibWJnYmJ2YnFiCjktMTAgZzogZ3RnZ2dnZ2djemdnCjMtNSBjOiB6cWN0Y3MKMTUtMTggejoga2J6c2RoYmJ6eGZ6enFkanpjCjctOCBnOiBnZ2dnZ2d6eAo5LTEwIHM6IHNzd3NzcnNzcW1zCjE0LTE3IGc6IGdnZ2djZ2dnZ2dnZ2dwZ2djZ2cKMTAtMTUgZzogcWd6bWJramxnZ3JoZ2tnCjktMTEgajogampqampqampxcWpqampqago1LTYgYzogY2djZGNjaGNjY2JjYwoyLTQgZzogZ2dnZwo1LTEzIGg6IHBsa2hocm14aHhobWgKMTEtMTYgdjogdmtrcXJ2YnZiY3Z2bnZ2dnZ2CjYtNyBjOiBybGZtcXBocXJocWtoY2gKMy01IHo6IGh6c3B6CjgtOSBkOiBrZGRtZGRkcGR2ZGRsbgo1LTExIGs6IHdrcWtjZmtwdm5rdmgKNC03IHI6IGZuenp3eHJ4cgoxNS0xNiByOiBycnJycnJycnJycnJycndyCjItMTkgZjogZnZmZmZmZmZmZmZmZmZmZmZmd2YKOS0xMSB2OiBoYnZidnZnY3Z2dmoKMi00IG06IG1yeHB2CjEzLTE0IHo6IHp6dHpnenpwenp6enpnCjQtMTAgdDogcXR2dGNyZm1sa3JndHdzdnd0dwozLTcgZzogZ2dnZ2dnZmdnZ2dnZ2dnCjUtOCBjOiBjY2NjZmNjY25tY2NjCjYtMTIgejogYnpmY2p6ZHpuend6cnpienpxcm4KMTQtMTUgYzogY2NjY2NjY2NjY2NjY3prY2NjY2MKMy00IGo6IGpqampqamYKMS0yIHg6IGt4eHh4CjMtNCBzOiBza3NqCjE3LTE5IGM6IGh2Y2hjY3ZjY2R4Z2NjbnhkY2MKMy02IHI6IHRycnJycnJyCjEwLTExIGM6IGNrY2p6Y3J6Y2JjCjEtNyBwOiBwbXFwbGZwdmdxCjMtNCBoOiBoaG14CjUtNiBuOiBubnduZGxuCjUtMTAgdjogYmtrdmZndnF3ZHQKNy0xNCBoOiBoa2psd3ZoZG5oeGh3Y25ocwo0LTEyIGY6IHh4d2ZqZmN3c2xyZnpyeGZreGoKMi0zIGM6IGNjY2NjCjQtMTMgazoga2trZGtra2tra2tra2trCjgtMTAgYjogbXFsbGprcGJiYnhicmJmeAoxLTQgcDogcHBwcAoxNC0xNyBuOiBubm5ubm5ubm5ubm5ubm5uZ25uCjUtNiBkOiBkZGRkZGRkdncKOS0xMCByOiByanRycnJtcXJycnpycnJyanJybQo3LTExIHg6IGJ4eHh4eHJ3eHBtbgoxMy0xNCB3OiBnd213d3dsd3dqd2p3eAoyLTQgZDogZGRkZGR2ZGRkCjctOSBwOiBwam1kcHBncHNwY3NsaAoxMy0xNiBsOiB0bGxsbHpsbHB2bGx2bHpkCjktMTEgcTogcXptd3FxenF0cXFxCjQtNSBkOiBkdmRuZ2RkCjktMTEgajogeHh4dmpybWdqcGsKMy00IGM6IHJ2dmNuCjE1LTE2IHI6IHJ4dm1sc2xrcG1xZHF0ZGQKMi01IGI6IHNiZmxiCjQtNSB3OiB3bnRwdwo4LTE2IG46IG5ubm5ubm5obnFubm5ubm5uCjUtNiBuOiBubm5ubm5uCjItNSBxOiBic2pmaHEKNi0xOCByOiBwcnJycWttcnJydmJycnJyZGZydgozLTUgZzogeG54bHAKNC0xMSBzOiBqc3N0c3NzanNzZnNzc3MKMTQtMTYgZDogZGRkZGRkZGRkc2RkZGRkZAoxOC0xOSBuOiB2Z25ndmJoZGpmcmJuem5oaGp6bgoxMS0xMyBmOiBmZmZmZmZmZmZmZ2ZnZgo1LTExIG46IGRiZ3ZuZ2NobmtuZ3QKMy00IGY6IGdzZmYKMi00IHI6IHJmZHJsem5remcKMTAtMTggejogenpnend6enp6enpkenptemh6em4KNC01IHM6IHFzY21ic3NzcwoxMS0xNSB4OiB4Ynh4eHhneHh4Ynh4encKMi0xMCBoOiBka3JueGtubXRoY3YKMTItMTMgYjogYmJiYnZic2JiYmJnY2JuYgo0LTUgbTogbW1sbW1zbW1oCjMtNiBqOiBuanJqamtjcgoxMC0xMiB4OiB4eHh4d2RueHh4eHgKMTQtMTYgZzogaGdnZ2dnZ2dnbmdnZ2dnZwo4LTkgeDogZ2pxZnh4eHR4eHhiCjE2LTE3IGY6IGZmZmZmZmZmamZma2ZmZmZtZmZiCjItOCB6OiB0c2t0a3pmeG50cnYKMi02IHY6IGh2dnN3ZAoxLTIgdzogeGRkbAoyLTYgazogc3Z3dnZrcW16d2preAo5LTEyIHA6IHBwcHBwcHBwYnBwc3BwcGIKMTItMTkgbTogbWRqbWxoc214bXdjbW1tbW1tbQozLTUgeDogcnhqeGIKMTctMTggcjogcnJycnJycnJycnJycnJycndrCjItOSBiOiBjYmZicWNmd2Jtd2QKMS0xMSBoOiBoaGhoaGJoaGhobXZoaGhoCjItMyBqOiBqa2pqZ2poeGoKNS02IGY6IGZmZmZmZmZmZmhmCjE3LTE4IGo6IGpwcnZ0c3p2Z3NidHhscmhsanN6CjEtNCBtOiBtbWhtbW1wCjItNiBwOiB4dmZrcGtjCjEtMiBmOiB4cXRmY2YKMS01IHI6IGJycnJycnIKNy0xMCB3OiB3d2h3d3dkd3dqCjEtNCB3OiB2d3dkaAoxLTMgZjogaG5wdmdmd3RoCjEwLTEyIGs6IGtra2tra2tra2RrcQo1LTEzIHI6IHJycHFycnZycXJzd3pyCjktMTcgeDogeGp4eHZ4dmJ0eHh4dHB4cHgKMTItMTMgajogbmpyamtjamdiampuagoyLTQgbDogbHZsbAoxMi0xNyBwOiBkcHBwcHJwYnBwbnZwcHBwcnAKNC0xOCBiOiB6ZnRibWJ4Z3pmemR2ZG52aGIKMTItMTYgcjogbGNxZ3FqdGhwcmx4cnpycngKMi03IG06IG1zY2xjY214aHNtZgozLTQgYjogYmZrYgoyLTYgazogc2tmZ3JrCjQtNSBxOiBxcXFoaHgKNi04IGM6IGNjY212Y2NoCjE2LTE3IGw6IGJ4bmx2YnZ3enZmdmJjbXhsCjctMTIgYzogY2NjY2NjY2NjY2NjCjYtNyBiOiBiYmJianNqYmJicwoyLTcgcTogcGh4bmZ4cXJxdgo0LTUgaDogaGhoaGhoCjktMTUgbjogbnFubmdsc2pubmdoeHJuCjMtNCBoOiBoa2toCjUtMTEgcjogcmxzanZycnJycmwKNS03IGI6IGJiYmJ6YndiYmJiCjItMyBmOiBxY3pmZgo4LTE0IGM6IGZjY3FjY2NjY2NjbGNjY2NjawoxLTggcjogcnJiZm1qc3IKNC01IHA6IGRwcGh6CjExLTEzIGQ6IHdkbXdrY3FkZHJkdmR6CjgtMTUgaDogaGhoaGhoaGhoaGhoaGhoaGgKNi0xMCBsOiBkaGdkY2xobGtsdG5jCjE0LTE1IHQ6IHR0dG50dHRudGh0dHR6dwo0LTYgcDogcHBwcHBkcAoxMy0xNCBsOiBkdmxudmxndGJwbmhsbAoxMS0xMiBzOiBicnNxZ2ZzbnBtd3NraGRubQo2LTcgajogaHR0anZqagoyLTE0IHc6IHd3d2Z3anp3cnpmd253and3bQo4LTkgdzogd3dyd3d3d2d0CjItNSByOiBkdnJ3Ygo3LTkgYjogd3d2cWJzYmpiCjEtMTIgbDogbGxqeGxic2x3bGduCjExLTEyIG06IG1tbW1tbWhtbW13Ym1rbW10CjEwLTExIGw6IGxibGxsbWxsbGRsCjMtOSB3OiB3d3B3d3d3YmZ3d3dtCjktMTAgcTogcGNycWZxbHNrego3LTkgbDogbGx2bGxsYmxrbGxseAo2LTcgZzogcWdnZ2ptd2cKNS0xMCB2OiB2dnZ2dnhicnZ2cAo5LTEwIGQ6IGhxZGRna2tkcnBkZAoxNy0xOCBxOiBxcXFxcXFxbHFxcXFxcXFxZHQKNi0xMCBoOiBoc3BuaGh6bGR4cGhkaAo4LTEzIGw6IHZ2dnNjZG5sYmxsbG1sCjYtMTIgcDogcHBrcnBycHh3cHBwd3gKNC01IGs6IHRrc2xiCjctOCBkOiBoZGpkaG56ZGQKOS0xMCB4OiB3a3h0YmxneHhqeHhscW5meHhseAo4LTkgZzogcmdnZ2dnZ2RrCjEwLTIwIGQ6IGtjZ2R0YmJzd3dkdHZnZGd4ZndkCjMtNCBnOiBnZ2dnZ2cKMTYtMTcgbDogbGxuemxxbGxsbHpsbGxsbWxsbGwKNC0xMCByOiBuc3JycmJ6cmZ6Y3JyenJyZHFrCjQtNiBrOiBra2tra3Brawo0LTggbjogbm5ubW50bm5ybm5uCjEyLTE0IGw6IGxsbGxsbGxsbHdscWxsbGwKMy02IHI6IHJycnJycnIKMS02IHM6IHNzc2tjc2hzeHRkCjctMTUgZDogbmRyYmRubnRkbWtkZHhkCjktMTAgajogcGpqampnanNqaGpqCjctMTAgazogcGtia2tra2tna3EKNC04IG06IG1teG1tbWRtbW1tbQo5LTEzIGM6IG5namNyY2NjdmJjdnFkam1waAozLTUgcTogcXFxcXFxCjctMTAgczogZmNzc25zc3Nzc3NseHNwcgozLTUgazoga2tra3Z2CjUtMTAgZjogdGxiY3Znd2Z6bGYKNS05IHg6IHh4eHhxeHh4eAoyLTEwIHE6IHFycHJoYnJoamhiCjMtNCBnOiBnZ2dtZ2cKOC0xMCBqOiBqampqampqZ2pwampqCjItNCB2OiBkdnp2dnRmbQo3LTEyIHE6IHp2enFwcmpocWRjcWZ6cgoxMi0xMyBmOiBmZmZmZmZmZmZmZmZxZgoyLTMgZjogZmZmc2R3cQoxMC0xMSB6OiB6dHp6anpqenp6bHp6ego1LTcgazoga2tra3F0a2tra2sKNi05IHo6IGRmYnpoZ3NyenNwCjItNCBiOiB3cHFiCjktMTUgYzogY3djaGNkaHhscXpjY3hiYgo4LTExIHE6IHFxeHB0cXF2cXJncWcKNS03IHQ6IHR0dHR6dGN2dGp0a3RzCjItNiBuOiBubmJtZG5qeGNsd2tmZnJueGZmCjMtNyBwOiBwcHBwcHBoCjktMTIgZDogeGhtZm5kemNkZGZkZHZnZGRmCjEtNSBoOiBodGhtaHZsdGhoaGhoCjYtNyBtOiBtbW1tbW1tCjYtNyBqOiBqamp2ampqcmoKMS01IHE6IG1xbnF3cXFxcXFqcQoxMC0xMSBiOiBibWJiYmRicGJiYmJ6YmIKMS00IGs6IGd2Y2N2ZGx0a3djZGQKMTItMTYgczogc3Nzc3Nzc3Nzc3Nqc3NzaHMKNC0xMCBrOiB3enZsa21kaGNrbGhkcAoxMC0xMyB6OiB6enp6enp6enpmenpqCjYtMTIgZzogYm16bXZ2Z2dwZ3RtCjMtMTEgbTogbnZjcGZndm5zcW13eG1tegoxLTUgbjogZG53bm5ubm5ubmJuZG5ubgo0LTUgaDogbGhoaGgKNC01IGc6IGdnZ2RnCjItNSBoOiB4dGhxaGZqCjItNCBmOiBsZmtmCjQtNiBrOiBycWJocnR6a3Rtdm1yeGNrCjQtNSBxOiBqcWRzYwoxMC0xMSBoOiBoaGhoaGhoaGh2amgKMi0xNyByOiBycnJycnJycHJ3cnJyZmpycgoxNi0xNyBiOiBiYmJiYmJiYmJiYmJiYmJiaGJiYgozLTUgejogcGt2enpmcmxqcmpjdHcKMTMtMTQgdzogd3d3d3d3d2p3d3d3d3cKOC0xMCBkOiBkZGRkZGRkbGR6cHEKMS00IGI6IHNiYmdiCjItMTAgZDogdm5ocHptdnBjZGRocwo4LTE1IHQ6IHpmdHB3dHJ0cWpxdGZudHAKMTEtMTIgajogZGpqampqampjampjago0LTcgcjoganJydHJycnZtenpycnZzbAoyLTQgcjogcnBrcAozLTQgYjogcWJ4YwoxMC0xMSB3OiB3d3d3d3dmemtkbW53d3YKNi0xNCB6OiBtenR4enp6dG16d3p6cXZtCjEyLTE0IHc6IHd3d3d3d21zZ3dkd3Nxd2p3d3cKNi0xMCBmOiB6ZmhxamZobmpmZHZ3c2ZmdGYKMi0xMSBxOiBtd2JicWRuY2RmcQo4LTExIHY6IHp2dHZ2d3ZmdnZxCjYtOCBuOiB4bndoem1kc2t3aG4KOC0xNSBxOiBxcXFxa3FxcXFxcXFxcXN0CjEtNCBuOiBubm5ubgo1LTE4IGM6IHNxY3pjaGN3Y2NjY2xjY2NjY2NjCjMtNCBqOiBrbGdyCjExLTEyIG06IG1tbW1tbW1tbW1tbQoyLTMgZDogcWR4Zm1xd2JtZG52agoxLTUgbTogY21tbW0KNi03IGw6IGxsbGxsbGxsCjEtOSBtOiB6bW1tbW1tbWxtbW1tbW1tCjktMTEgbTogZHdzcHdybWpzeHBjCjUtNiBwOiBxcHBwZnoKMTAtMTkgdDogZnZ0cGh3enNwdHF6bnRia3hxdAo3LTkgbTogbXBjbXBtbW12cHRtbQozLTkgaDogaGhocHFxd2hodG0KMTEtMTYgcDogcHBwcHBwcHBwcHBwcHBwdnAKMS05IGs6IGt0a2tsa2tra2trawoxMC0xNyBxOiBydGh0cXZnc3Bxa3Zma2drcWZoagoxMS0xNCBnOiBnZ3hnZ2dnZ3hnZ3pnZ2NuZ2dnCjMtNCB0OiB0dHR0CjktMTAgdDogc3F0YmR0dHRodHR0bQoxLTQgdDogdHRrYmdkenp0YnhkCjMtOCBmOiBneGZjcnJzZm50ZnR2ZmZuZnFmZgo5LTExIHE6IHFxcXFxcXFqbHFxcQoxMi0xMyB2OiB2dnZ2dnZ2dnZ2dnZrCjctMTEgYjogbmJ4YmJic21idGtiCjctOCBrOiBra2tra2tubgo0LTYgajogampqamx2CjEzLTE2IG06IG1tY21tbW1tbW1tbW1tbXZzCjctOSBrOiBrZGtra2tya2drawoxLTQgYzogY3JjZGxyZGJ6YwoxLTE2IGs6IGtra2tra2tra2tnbWtra3Rra2sKMi0xMiBsOiBsbGxscmxsbGxsbGxsbAo0LTkgZzogZ2dnYmtncGd6CjYtNyBxOiBxcXFxcXFqcQo2LTcgdjogaHZ2dnZwbQoxMC0xNCB0OiB0dGZ4bXF0Z3R0dHR0YnRjdAo1LTcgaDogaHdoaGZybmNoCjQtMTMgdzogemRscnF2eHd3enNmcmZxCjQtNSBoOiBoaGhzaGhoaAoyLTQgbjogdmhqZm56CjUtNiBzOiBzc3Nzc3NzCjExLTEzIG46IG5ud3Jubm5sbm5nbm4KMy00IHM6IHdic3MKMy00IHM6IHduc3MKMTYtMTcgcDogcHBmcHJwdGtwbXprYmpwcHAKMi00IHY6IHB2eHYKOC05IHc6IHN3d3d3d3dod3dud3d3eGoKNC02IHM6IHB6aGt2c3MKNC01IHg6IHdueHB4CjQtNSBmOiBmc2Z3cAo0LTUgejogenpkanoKMy02IHY6IHZudnZ2dnZ2dnZ2dnYKNS02IGY6IHdmeGZmZgo0LTcgejogenp6cWZ6egozLTUgcTogcXFqcXNxcXFmCjMtNyB3OiBrd3drbXd3CjYtNyBoOiBoaGhoaGhnaAoyLTUgdjogdnZienZ2a24KOC0xNSByOiBzdnJxcHFyZ3JyaG16Ym1zCjktMTcgbjogam5ubm5jbm5ubm54bm5ubm5wCjUtNiBuOiBkZ25oc2MKNS03IGw6IGxwbGx0YnYKNC02IG46IG1tcm5zYmNxcgo3LTggdzogd3dqd3d3d3d3CjEtMTYgYzogYmNjY2NjY2ZjY2NjY2NjZGNjCjYtOSBsOiBzam5sbXh3bGxnCjMtOSBxOiBjcXZoa3dodHN0d3JsCjUtOSBoOiBraHZ4aGhoZ2ZjaGhrbmhoaHoKOC05IGM6IGNjY2NjY2NjZGMKMi0xOSBuOiBqanhibWJ3bW5xYmJsZmJnenN6CjMtNCBwOiBwcHBwCjEtMyBiOiBqenhiYmIKMy02IGg6IGhoaGdqaGh3CjItOCBmOiB2ZnhmdHprbWx6awoxMS0xOSBoOiBtbWRwdGR6aHdkYmpodmtjY3Joawo0LTE0IHM6IHNzc3ZzZHBzc3Nzc3NwbnMKMTEtMTIgZjogZmZmZmZmZmZsZmJrCjItMTMgaDogbmhiZ3RianZicG1ybmhmCjEtMyB0OiB0dHR0dHR0dHR0dHR0dHR0dHRtCjMtNCB0OiB0c3R0cgoyLTkgbjogZm5ra25wdHFuCjEtOCBqOiBxanBqampqamp0cHhqcWp3CjItMTIgYzogY2xjY2NjY2NjY2NrY2NjCjE4LTE5IGY6IGRwZnRmZnpjZmhxZmZkZGZwZmYKMS00IGo6IHRyamoKOS0xMSB6OiB6d3ptenpjenNkZAo1LTggZzogdnJwYmdnZm4KMi01IGs6IHFrc3Z6a2oKMi00IGY6IHdmZGZqbGZ3bWpyZG14eAo0LTEyIGw6IGJucGxubGdxY3dxbAoxMy0xNCBuOiBucWxmZG5ubm5ubm52Ym53bmxoCjQtOCBsOiBkZ3hoc3JxbAoxMC0xMSBrOiBxdndjcmt4dGtqeGxxCjUtNiBnOiBja2dnZ2cKNi0xNCBoOiB4Ymhodnp2eGJoaGhoaGJoa3poaAo2LTkgdzogd2h3ZHdyeGdjCjctOSBiOiBiYnJibmpiZmIKNy04IHc6IGJyd3drZnZ3d3d3dwoyLTExIGc6IGdtZ2dnaG5nZ2dnCjEyLTE3IGw6IGJnc2xsanpudGJtdnRrYmdsbGdnCjEyLTE4IGc6IGdnZ2dnZ2dnZ2dna2dnZ2dnZ2cKMS0zIGw6IGdsbGxsbGxsbAoxNC0xNiBrOiBqa2txa2tna3Jrdnhra2trc2tnYgoyLTMgdjogdmxqdmdudm0KNy04IHI6IGpyanZycHJyCjctOCBmOiB4eGZmcm5mZgoyLTE4IGo6IGpoampqampqampqdGpqZmpqcGpyCjgtOSBxOiByZmxsaG1ucXRya3YKMi0zIG46IGxubmR2CjItMTUgczogaHp6c3Jwcm5uamx3ZGZzCjEtNSBxOiB2cXFxcQo5LTE4IGI6IGd4YnBiYnBwYnJiYm5sa21iYgoyLTEzIGI6IGJiYmJiYmJiYmJiYnBiCjYtNyB0OiBtdHJmdHRodHR0ZnR0dHp0dHRzdAoxLTcgejogbmZ6enp6dnp6Y3p6enp6enp6CjQtMTIgbTogbW1tY21tbW1tbW1tbW0KOS0xMSBwOiBqcHN3cHBxYm1wZnB6cGcKMTAtMTEgYzogY2NjY2NjcGNjY2MKMi02IHQ6IHp0c2Nkcmt4eGN0ZGZ0CjMtMTMgcTogbXFmcXFxcWpxcWZxZHFxcQoxNi0yMCB6OiB6empjeGRtemd6enpwcGJ0enR6ego1LTE1IHc6IHd3d3B3aHdxY3d3d3d3Z3cKMi00IHA6IHBjenAKNS03IGQ6IGRkZGRtZGZkCjItMyBmOiBmZnRjCjEtMyB2OiB2dm12CjExLTE1IGs6IHRqa2N2a2tra2dremtreHF2CjQtNiBiOiB2ZGt2Ym4KNy04IGM6IHdiY2poc3djCjktMTAgbDogbGxsYnFybGxsbAo0LTUgczogc2pubHcKMTItMTQgajogbWp0bXpmamp0c2d2Z3RxCjEtMyBsOiBsbHJsbG1sCjEyLTEzIGQ6IGRuZ2RkbHFkdGdkY2QKMy01IGw6IGNibGhsZAozLTQgcjogdHJycQoxLTMgYzoga2NjY2MKOS0xMCBnOiBiZ2JnamdncHZncGdwZ2dnCjMtNiBkOiBzendsZm0KMTMtMTQgZjogZmZmZmZmZmZmZmZmemZmZgo2LTcgZDogZGRkZGRkZGRkZG5uZGRkZHIKNy0xNiBoOiB4bWJwd21oc3pubWxkaG54ZmxjCjQtNiBxOiBxcXFucXFxZwoyLTcgdDogdHR3YnBtbnRobWpyCjgtMTYgeDogeGJjeHhid3h4cnB4bmZ4ZAoyLTMgZDogZG5nZGQKOS0xMCBuOiBxa3hmZGxqbm5sCjQtNSBmOiBmdGZmZmZmCjEyLTE1IG46IG5ubm5ubmNubm5ubm5uc25uCjEtMiBkOiBka2RkCjItNSB2OiB2dnZ2Z3YKMS0xNCB2OiBqdnZ2dnZ2dnZ2dnZ2bXZ2dgo1LTYgcjogcnJycnJyCjItMyBiOiBibnZiYmJ0YmpneGZjaG5raGNqYgoxLTE0IGc6IHdqZ2d4Z2dnZ2dnZ3hnbXJ2Y2cKMS02IHg6IGJodnhoeHh4eAoxLTIgcjogcnBycgo2LTcgYzogY2NjY2NjY3FjCjQtOCBiOiBiYmdwbGJiY2R0YmJkYmdiYmhiegoxLTQgdzogd2pndwoxLTMgaDogemh6enQKMi0xMSBqOiBzampydGpramhqago2LTcgbTogbWxtcnJtbQ==";
            IList<string> data = (IList<string>)DecodeBase64AsStr(data_b64, '\n');

            var count = data.Count;
            var sum = 0;
            for (var i = 0; i < count; ++i)
            {
                var item = data[i].Split(' ');
                var str = item[2];
                var chr = item[1].Trim()[0];
                var pos = item[0].Split('-').Select(x => Int32.Parse(x)).ToList();

                if (str[pos[0] - 1] == chr ^ str[pos[1] - 1] == chr)
                    sum++;
            }
            Console.WriteLine($"Result: {sum}");
        }
    }
}
