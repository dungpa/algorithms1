module MinCut2

open System
open System.Collections.Generic
open Microsoft.FSharp.Collections

let contraction (d: ResizeArray<int * int []>) =
    let rand = Random()

    let countEdges (d: ResizeArray<_>) =
        let c = ResizeArray.fold (fun acc (_, v) -> acc + Array.length v) 0 d
        c/2

    let rec loop (d: ResizeArray<_>) =
        if d.Count = 2 then countEdges d
        else
            // Find a random edge (start, finish)
            let i = rand.Next() % d.Count
            let start, vs = d.[i]
            let j = rand.Next() % vs.Length
            let finish = vs.[j]
            // Fuse two nodes start and end
            let _, vs' = ResizeArray.find (fun (k, vs) -> k = finish) d
            let ra = ResizeArray(vs.Length + vs'.Length)
            for f in vs do
                if f <> finish then ra.Add(f)
            for s in vs' do
                if s <> start then ra.Add(s) 
            let vs''= ra.ToArray()

            let d' = ResizeArray(d.Count-1)
            d'.Add(start, vs'') // Merge two nodes

            for (k, vs) in d do
                if k <> start && k <> finish then
                    d'.Add(k, Array.map (fun n -> if n = finish then start else n) vs)
            
            loop d'

    loop d

let minCut arr =
    let n = Array.length arr
    let d = ResizeArray.ofArray arr
    let mutable count = Int32.MaxValue
    for i in 1..n do
        let c = contraction d
        if c < count then count <- c
    count