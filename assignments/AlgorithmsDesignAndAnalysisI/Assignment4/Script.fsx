#load "Graph.fs"

open System
open System.IO

open Graph

let sccFromFile n f =
    f |> File.ReadLines
      |> Seq.map (fun s -> let arr = s.Split ([|' '; '\t';|], StringSplitOptions.RemoveEmptyEntries) |> Array.map Convert.ToInt32
                           arr.[0]-1, arr.[1]-1)
      |> calculateSCC n

#time "on";;

let a1 = __SOURCE_DIRECTORY__ + "\\test1.txt" |> sccFromFile 11 |> Seq.take 4 |> Seq.toArray;; // 4; 3; 3; 1
let a2 = __SOURCE_DIRECTORY__ + "\\test2.txt" |> sccFromFile 13 |> Seq.take 5 |> Seq.toArray;; // 3; 3; 3; 3; 1
let a3 = __SOURCE_DIRECTORY__ + "\\test3.txt" |> sccFromFile 30 |> Seq.take 5 |> Seq.toArray;; // 7; 6; 5; 5; 4
let a4 = __SOURCE_DIRECTORY__ + "\\test4.txt" |> sccFromFile 1000 |> Seq.take 5 |> Seq.toArray;; // 152; 88; 82; 76; 66
let a5 = __SOURCE_DIRECTORY__ + "\\test5.txt" |> sccFromFile 5 |> Seq.take 3 |> Seq.toArray;; // 3; 1; 1
let a6 = __SOURCE_DIRECTORY__ + "\\test6.txt" |> sccFromFile 14 |> Seq.take 2 |> Seq.toArray;; // 10; 4

