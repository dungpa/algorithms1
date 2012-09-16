#load "Heap.fs"
#load "Median.fs"

open System
open System.IO

#time "on";;

let result = __SOURCE_DIRECTORY__ + "\\Median.txt"
             |> File.ReadLines
             |> Seq.map Convert.ToInt32
             |> Median.medianModuloSum 10000;;