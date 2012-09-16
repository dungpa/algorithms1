#load "CountInv.fs"

open System
open System.IO

#time "on";;

let a = __SOURCE_DIRECTORY__ + "\\IntegerArray.txt"
         |> File.ReadLines
         |> Seq.map Convert.ToInt32
         |> Array.ofSeq
         |> CountInv.count;;

let b = __SOURCE_DIRECTORY__ + "\\IntegerArray.txt"
         |> File.ReadLines
         |> Seq.map Convert.ToInt32
         |> Array.ofSeq
         |> CountInv.count2;;

// Better runtime but worst memory usage
let c = __SOURCE_DIRECTORY__ + "\\IntegerArray.txt"
         |> File.ReadAllLines
         |> Array.map Convert.ToInt32
         |> CountInv.count;;