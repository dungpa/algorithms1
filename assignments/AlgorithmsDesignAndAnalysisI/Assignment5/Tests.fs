module Tests

open System
open System.IO

open Xunit
open FsUnit.Xunit

let shortestPathFromFile f =
    f |> File.ReadLines
      |> Seq.map (fun s -> let arr = s.Split ([|' '; '\t'; ','|], StringSplitOptions.RemoveEmptyEntries) |> Array.map Convert.ToInt32                           
                           [| for i in 1..2..arr.Length-1 do
                                  yield arr.[i]-1, arr.[i+1]|]
                           )
      |> Array.ofSeq
      |> Graph.shortestPath 0

let srcDir = @"..\..\"


/// should equal doesn't work correctly with array
[<Fact>]
let test1() = srcDir + "test01.txt" |> shortestPathFromFile |> List.ofArray |> should equal [0; 7; 8; 5; 7]

[<Fact>]
let test2() = srcDir + "test02.txt" |> shortestPathFromFile |> List.ofArray |> should equal [0; 3; 2; 4; 7; 9; 7; 12]

[<Fact>]
let test3() = srcDir + "test03.txt" |> shortestPathFromFile |> List.ofArray |> should equal [0; 7; 5; 7; 6]

