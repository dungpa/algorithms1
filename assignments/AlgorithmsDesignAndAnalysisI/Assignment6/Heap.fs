module Heap

open System.Collections.Generic

// Heap property: at every node x, key.[x] <= all keys of x's children

// Array-based implementation (zero-based index):
// parent(i) = i/2-1 if i is even
//           = (i-1)/2 if i is odd

type Heap<'T when 'T: comparison>(capacity: int) =
    let arr = ResizeArray<'T>(capacity)

    let parent i = (i-1)/2
    let smallerChildIndex i =
        if 2*i+2 = arr.Count then 2*i+1 // i has only left child
        elif arr.[2*i+1] < arr.[2*i+2] then 2*i+1
        else 2*i+2

    let rec bubleUp i =
        if i > 0 then
            let pi = parent i
            if arr.[pi] > arr.[i]then
                let temp = arr.[i] 
                arr.[i] <- arr.[pi]
                arr.[pi] <- temp
                bubleUp pi

    let rec bubleDown i =
        if 2*i+1 < arr.Count then // It has some child
            let childi = smallerChildIndex i
            if arr.[i] > arr.[childi] then // Always swapping with smaller child
                let temp = arr.[i] 
                arr.[i] <- arr.[childi]
                arr.[childi] <- temp
                bubleDown childi

    /// Whether the heap is empty
    member x.IsEmpty() = arr.Count = 0

    member x.Clear() = arr.Clear()

    /// Insert a new key into heap, T = O(logn)
    member x.Insert k =
        arr.Add k // put into the end
        bubleUp (arr.Count-1) // buble up until restoring heap property

    /// Extract minimum key, T = O(logn)
    member x.ExtractMin() =
        let root = arr.[0]
        let last = arr.[arr.Count-1]
        arr.RemoveAt(arr.Count-1)
        if not <| x.IsEmpty() then
            arr.[0] <- last // Move last leaf to be new root
            bubleDown 0
        root

    /// Get the min key without removal
    member x.PeekMin() = arr.[0]

    /// Get the number of elements in the heap
    member x.Count = arr.Count

    override x.ToString() = 
        let sb = System.Text.StringBuilder()
        for el in arr do
            sprintf "%O, " el |> sb.Append |> ignore
        sb.ToString()

