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



