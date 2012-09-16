module Tests

open System
open System.IO

open Xunit
open FsUnit.Xunit

let medianModuloSumFromFile f = 
       f |> File.ReadLines
         |> Seq.map Convert.ToInt32
         |> Median.medianModuloSum 10000

let srcDir = @"..\..\"

[<Fact>]
let testTwoSum() = srcDir + "\\2sum.txt"
                   |> File.ReadLines
                   |> Seq.map Convert.ToInt32
                   |> Array.ofSeq
                   |> TwoSum.countRange 2500 4000
                   |> should equal 1453

[<Fact>]
let testMedianSum1() = srcDir + "med.txt" |> medianModuloSumFromFile |> should equal 1666

[<Fact>]
let testMedianSum2() = srcDir + "med2.txt" |> medianModuloSumFromFile |> should equal 4758

[<Fact>]
let testMedianSum3() = srcDir + "med3.txt" |> medianModuloSumFromFile |> should equal 4011

[<Fact>]
let testMedianSum4() = srcDir + "med4.txt" |> medianModuloSumFromFile |> should equal 94

[<Fact>]
let testMedianSum5() = srcDir + "med5.txt" |> medianModuloSumFromFile |> should equal 112