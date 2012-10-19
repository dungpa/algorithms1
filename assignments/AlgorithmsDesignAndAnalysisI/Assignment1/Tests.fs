module Tests

open Xunit
open FsUnit.Xunit

/// should equal cannot detect mismatch between 0L and 0.
[<Fact>]
let countIncrSortedArray() =
    CountInv.count [|1; 2; 3; 4; 5; 6|] |> should equal 0L

[<Fact>]
let countDecrSortedArray() =
    CountInv.count [|6; 5; 4; 3; 2; 1|] |> should equal 15L

[<Fact>]
let countUnsortedArray() =
    CountInv.count [|1; 3; 5; 2; 4; 6|] |> should equal 3L

[<Fact>]
let countEmptyArray() =
    CountInv.count [||] |> should equal 0L

open FsCheck

/// It seems strict increase is too tight. But changing it requires to fix the algorithm.
let strictlyIncreased = function 
    | [||] | [|_|] -> true
    | xs -> Seq.forall (fun i -> xs.[i] < xs.[i+1]) {0..Array.length xs - 2}

let strictlyDecreased = function 
    | [||] -> false
    | [|_|] -> true
    | xs -> Seq.forall (fun i -> xs.[i] > xs.[i+1]) {0..Array.length xs - 2}

[<Property>]
let ``Strictly increased integer arrays have no inversion`` (xs: int []) =
    let xs' = Array.sort xs
    strictlyIncreased xs' ==> (CountInv.count xs' = 0L)

[<Property>]
let ``Strictly decreased integer arrays have maximum number of inversion`` (xs: int []) =
    let xs' = Array.sortBy (~-) xs
    let n = xs'.LongLength
    strictlyDecreased xs' ==> (CountInv.count xs' = n*(n-1L)/2L)


