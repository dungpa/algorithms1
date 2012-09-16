module Graph

open System.Collections.Generic

/// Pass 1: Find the order for constructing SCC
let dfsPass1 (g: int [] []) n = 
    let explored = Array.create n false
    let fts = Array.zeroCreate n
    let t = ref 0
    let rec loop i =
        explored.[i] <- true
        for j in g.[i] do
            if not explored.[j] then
                loop j
        fts.[!t] <- i
        incr t
       
    for i = n-1 downto 0 do
        if not explored.[i] then
            loop i
    fts

/// Pass 2: Get SCCs based on index of one of its element
let dfsPass2 (g: int [] []) n (fts: _ []) =
    let explored = Array.create n false
    let d = Dictionary()
    let rec loop i s =
        explored.[i] <- true
        match d.TryGetValue s with
        | true, v -> d.[s] <- v + 1
        | false, _ -> d.[s] <- 1
        for j in g.[i] do
            if not explored.[j] then
                loop j s
    for i = n-1 downto 0 do
        let v = fts.[i]
        if not explored.[v] then
            loop v v
    d |> Seq.map (fun (KeyValue(k, v)) -> v)
      |> Seq.sortBy (~-)

let scc g grev n =
    dfsPass1 grev n |> dfsPass2 g n

/// Represent graph as a sequence of edges
let calculateSCC n sq =
    let g = let arr = Array.create n [||]
            sq |> Seq.groupBy fst |> Seq.map (fun (i, xs) -> i, Seq.map snd xs |> Array.ofSeq) 
               |> Seq.iter (fun (i, xs) -> arr.[i] <- xs)
            arr
    let grev =  let arr = Array.create n [||]
                sq |> Seq.groupBy snd |> Seq.map (fun (i, xs) -> i, Seq.map fst xs |> Array.ofSeq)
                   |> Seq.iter (fun (i, xs) -> arr.[i] <- xs)
                arr
    scc g grev n
