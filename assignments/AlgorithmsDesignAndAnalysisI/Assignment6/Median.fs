module Median

open Heap

let medianModuloSum m sq =
    let heapLow = Heap(m/2)
    let heapHigh = Heap(m/2)
    sq 
    |> Seq.fold (fun acc v ->                     
                    if heapHigh.Count > 0 && v >= heapHigh.PeekMin() then 
                        heapHigh.Insert v
                        // Balancing two heaps
                        if heapHigh.Count - heapLow.Count = 2 then
                            let m = heapHigh.ExtractMin()
                            heapLow.Insert (-m)
                    elif heapLow.Count > 0 && v <= - heapLow.PeekMin()  then 
                        heapLow.Insert (-v)
                        // Balancing two heaps
                        if heapLow.Count - heapHigh.Count = 2 then
                            let m = - heapLow.ExtractMin()
                            heapHigh.Insert m
                    elif heapHigh.Count < heapLow.Count then heapHigh.Insert v
                    else heapLow.Insert (-v)

                    let median = if heapHigh.Count > heapLow.Count then heapHigh.PeekMin() else - heapLow.PeekMin()
                    //printf "High and low have %i and %i elements with median = %i" heapHigh.Count heapLow.Count median
                    //if heapHigh.Count > 0 && heapLow.Count > 0 then printfn ". Selected between %i and %i" (heapHigh.PeekMin()) (- heapLow.PeekMin()) else printfn ""
                    //printfn "high: %O" heapHigh
                    //printfn "low: %O" heapLow
                    //printfn "****"
                    (acc + median)%m
                ) 0