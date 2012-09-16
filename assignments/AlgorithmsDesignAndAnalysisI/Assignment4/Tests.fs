module Tests

open System
open System.IO

open Xunit
open FsUnit.Xunit

let sccFromFile n f =
    f |> File.ReadLines
      |> Seq.map (fun s -> let arr = s.Split ([|' '; '\t';|], StringSplitOptions.RemoveEmptyEntries) |> Array.map Convert.ToInt32
                           arr.[0]-1, arr.[1]-1)
      |> Graph.calculateSCC n

let srcDir = @"..\..\"


/// should equal doesn't work correctly with array
[<Fact>]
let test1() = srcDir + "test1.txt" |> sccFromFile 11 |> Seq.take 4 |> Seq.toList |> should equal [4; 3; 3; 1]

[<Fact>]
let test2() = srcDir + "test2.txt" |> sccFromFile 13 |> Seq.take 5 |> Seq.toList |> should equal [3; 3; 3; 3; 1]

[<Fact>]
let test3() = srcDir + "test3.txt" |> sccFromFile 30 |> Seq.take 5 |> Seq.toList |> should equal [7; 6; 5; 5; 4]

[<Fact>]
let test4() = srcDir + "test4.txt" |> sccFromFile 1000 |> Seq.take 5 |> Seq.toList |> should equal [152; 88; 82; 76; 66]

[<Fact>]
let test5() = srcDir + "test5.txt" |> sccFromFile 5 |> Seq.take 3 |> Seq.toList |> should equal [3; 1; 1]

[<Fact>]
let test6() = srcDir + "test6.txt" |> sccFromFile 14 |> Seq.take 2 |> Seq.toList |> should equal [10; 4]