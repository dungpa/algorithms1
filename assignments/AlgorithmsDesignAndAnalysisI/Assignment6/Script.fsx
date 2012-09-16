#load "TwoSum.fs"

open System
open System.IO

#time "on";;

let result = __SOURCE_DIRECTORY__ + "\\HashInt.txt"
             |> File.ReadLines
             |> Seq.map Convert.ToInt32
             |> Array.ofSeq
             |> TwoSum.countRange 2500 4000;;