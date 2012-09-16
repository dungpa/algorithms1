module MinCut

open System
open System.Linq
open System.Collections.Generic

let contraction (d: Dictionary<_, _>) =
    let rand = Random()

    let countEdges (d: Dictionary<_, _ []>) =
        let mutable c = 0
        for KeyValue(_, v) in d do
            c <- c + v.Length
        c/2

    let rec loop (d: Dictionary<_, _>) =
        if d.Count = 2 then countEdges d
        else
            // Find a random edge (start, finish)
            let i = rand.Next() % d.Count
            let start = d.Keys.ElementAt(i)
            let vs = d.[start]
            let j = rand.Next() % vs.Length
            let finish = vs.[j]
            // Fuse two nodes start and end
            let vs' = d.[finish]
            let ra = ResizeArray(vs.Length + vs'.Length)
            for f in vs do
                if f <> finish then ra.Add(f)
            for s in vs' do
                if s <> start then ra.Add(s) 
            let vs''= ra.ToArray()

            let d' = Dictionary()
            for KeyValue(k, vs) in d do
                if k <> start && k <> finish then
                    d'.Add(k, Array.map (fun n -> if n = finish then start else n) vs)
            d'.Add(start, vs'') // Merge two nodes

            loop d'

    loop d

let minCut arr =
    let n = Array.length arr
    let d = Dictionary()
    for (k, v) in arr do
        d.Add(k, v)
    let mutable count = Int32.MaxValue
    for i in 1..n do
        let c = contraction d
        if c < count then count <- c
    count

let minCutTest arr =
    let n = Array.length arr
    let d = Dictionary()
    for (k, v) in arr do
        d.Add(k, v)
    let mutable count = Int32.MaxValue
    for i in 1..n*n do
        let c = contraction d
        if c < count then count <- c
    count
