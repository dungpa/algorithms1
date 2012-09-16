module Graph

open System.Collections.Generic

let shortestPath s g =
    let processed = HashSet() // vertices processed so far
    processed.Add s |> ignore

    let len = Array.length g
    let dist = Array.create len 1000000 // shortest path distances
    dist.[s] <- 0

    let inline fst3 (x, _, _) = x

    let rec loop () =
        if processed.Count = len then dist
        else
            // Find an edge (v, w) minimizing the distance
            let d, v, w =
                g |> Seq.mapi (fun i arr -> arr |> Array.map (fun (w, l) -> i, w, l)) // First vertex is stored implicitly in indices
                  |> Seq.concat          
                  |> Seq.choose (fun (v, w, l) -> if processed.Contains v && not (processed.Contains w)
                                                  then Some (dist.[v] + l, v, w)
                                                  elif processed.Contains w && not (processed.Contains v) // reflecting for undirected graph
                                                  then Some (dist.[w] + l, w, v)
                                                  else None)
                  |> Seq.minBy fst3
            processed.Add w |> ignore
            // printfn "Update w=%i with distance d=%i from v=%i" w d v
            dist.[w] <- d // update shortest path
            loop ()
    loop()
