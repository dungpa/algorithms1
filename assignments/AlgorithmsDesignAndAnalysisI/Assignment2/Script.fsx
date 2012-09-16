#load "CountComp.fs"

open System
open System.IO

#time "on";;

let a = __SOURCE_DIRECTORY__ + "\\QuickSort.txt"
         |> File.ReadLines
         |> Seq.map Convert.ToInt32
         |> Array.ofSeq
         |> CountComp.count CountComp.pivotOnFirst;;

let b = __SOURCE_DIRECTORY__ + "\\QuickSort.txt"
         |> File.ReadLines
         |> Seq.map Convert.ToInt32
         |> Array.ofSeq
         |> CountComp.count CountComp.pivotOnLast;;

let c = __SOURCE_DIRECTORY__ + "\\QuickSort.txt"
         |> File.ReadLines
         |> Seq.map Convert.ToInt32
         |> Array.ofSeq
         |> CountComp.count CountComp.pivotOnMedian;;

