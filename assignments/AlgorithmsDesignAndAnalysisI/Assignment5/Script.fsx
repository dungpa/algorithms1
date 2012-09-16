#load "Graph.fs"

open System
open System.IO

open Graph

let shortestPathFromFile f =
    f |> File.ReadLines
      |> Seq.map (fun s -> let arr = s.Split ([|' '; '\t'; ','|], StringSplitOptions.RemoveEmptyEntries) |> Array.map Convert.ToInt32                           
                           [| for i in 1..2..arr.Length-1 do
                                  yield arr.[i]-1, arr.[i+1]|]
                           )
      |> Array.ofSeq
      |> shortestPath 0

#time "on";;

let result = 
    let arr = __SOURCE_DIRECTORY__ + "\\dijkstraData.txt" |> shortestPathFromFile
    [|7;37;59;82;99;115;133;165;188;197|] 
    |> Array.map (fun i -> sprintf "%i" arr.[i-1])
    |> fun s -> String.Join(",", s);;
