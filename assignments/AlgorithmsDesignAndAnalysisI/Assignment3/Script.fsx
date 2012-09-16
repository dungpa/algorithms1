#r "FSharp.PowerPack"
#load "MinCut2.fs"

open System
open System.IO

let minCutFromFile f =
    f |> File.ReadLines
      |> Seq.map (fun s -> let arr = s.Split ([|' '; '\t';|], StringSplitOptions.RemoveEmptyEntries) |> Array.map Convert.ToInt32
                           arr.[0], arr.[1..])
      |> Array.ofSeq
      |> MinCut2.minCut

#time "on";;

let result = __SOURCE_DIRECTORY__ + "\\kargerMinCut.txt" |> minCutFromFile;;

