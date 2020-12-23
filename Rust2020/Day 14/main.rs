use regex::Regex;
use std::io::{prelude::*, BufReader};
use std::{collections::HashMap, fs::File};

fn main() {
    let file = File::open("input").unwrap();
    let reader = BufReader::new(file);

    let lines: Vec<String> = reader
        .lines()
        .map(|l| l.expect("Could not parse line"))
        .collect();

    part1(&lines);
    part2(&lines);
    fn get_addrs(adr: u64, mask: u64, depth: u64, lst: &mut Vec<u64>) {
        if mask == 0 {
            lst.push(adr);
            return;
        }
        let mut depth = depth;
        let mut mask = mask;
        while mask & 0b1 != 0b1 {
            depth += 1;
            mask >>= 1;
        }
        depth += 1;
        mask >>= 1;
        get_addrs(adr | (0u64 | 1u64 << depth), mask, depth, lst);
        get_addrs(adr & (!(0u64 | 1u64 << depth)), mask, depth, lst);
    }
    fn part2(lines: &Vec<String>) {
        let mut mem = HashMap::new();
        let mut f_mask = 0u64;
        let mut or_mask = 0u64;
        for line in lines {
            let re = Regex::new(r"mask\s+=\s+((0|X|1)+)\s*").unwrap();
            if let Some(caps) = re.captures(&line) {
                let a = caps.get(1).map(|m| m.as_str()).unwrap();
                f_mask = 0u64;
                or_mask = 0u64;
                for (i, c) in a.chars().enumerate() {
                    match c {
                        '1' => or_mask |= 1u64 << 35 - i,
                        'X' => f_mask |= 1u64 << 35 - i,
                        '0' => (),
                        _ => panic!("Invalid character"),
                    };
                }
                continue;
            }
            let re = Regex::new(r"mem\[(\d+)\]\s+=\s+(\d+)").unwrap();
            if let Some(caps) = re.captures(&line) {
                let addr: usize = caps.get(1).map(|m| m.as_str()).unwrap().parse().unwrap();
                let val: u64 = caps.get(2).map(|m| m.as_str()).unwrap().parse().unwrap();
                let mut addrs = Vec::new();
                get_addrs(addr as u64 | or_mask, f_mask, 0, &mut addrs);
                for addr in addrs {
                    mem.insert(addr, val);
                }
            }
        }
        let sum: u64 = mem.values().sum();
        println!("Result Part2: {} ", sum);
    }

    fn part1(lines: &Vec<String>) {
        let mut mem = vec![0u64; 70000];
        let mut and_mask = !0u64;
        let mut or_mask = 0u64;

        for line in lines {
            let re = Regex::new(r"mask\s+=\s+((0|X|1)+)\s*").unwrap();
            if let Some(caps) = re.captures(&line) {
                let a = caps.get(1).map(|m| m.as_str()).unwrap();
                and_mask = !0u64;
                or_mask = 0u64;
                for (i, c) in a.chars().enumerate() {
                    match c {
                        '0' => and_mask &= !(1u64 << 35 - i),
                        '1' => or_mask |= 1u64 << 35 - i,
                        'X' => (),
                        _ => panic!("Invalid character"),
                    };
                }
                continue;
            }
            let re = Regex::new(r"mem\[(\d+)\]\s+=\s+(\d+)").unwrap();
            if let Some(caps) = re.captures(&line) {
                let addr: usize = caps.get(1).map(|m| m.as_str()).unwrap().parse().unwrap();
                let val: u64 = caps.get(2).map(|m| m.as_str()).unwrap().parse().unwrap();
                mem[addr] = (val | or_mask) & and_mask;
            }
        }
        let sum: u64 = mem.iter().sum();
        println!("Result Part1: {} ", sum);
    }
}
