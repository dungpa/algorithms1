module Tests

open Xunit
open FsUnit.Xunit

[<Fact>]
let countPivotOnFirst1() =
    CountComp.count CountComp.pivotOnFirst [|1; 2; 3; 4;|] |> should equal 6
    CountComp.count CountComp.pivotOnFirst [|9; 6; 3; 7; 2; 4|] |> should equal 11
    CountComp.count CountComp.pivotOnFirst [|9; 6; 3; 7; 4; 2|] |> should equal 13

[<Fact>]
let countPivotOnLast1() =
    CountComp.count CountComp.pivotOnLast [|1; 2; 3; 4;|] |> should equal 6
    CountComp.count CountComp.pivotOnLast [|9; 6; 3; 7; 2; 4|] |> should equal 9
    CountComp.count CountComp.pivotOnLast [|9; 6; 3; 7; 4; 2|] |> should equal 13

[<Fact>]
let countPivotOnMedian1() =
    CountComp.count CountComp.pivotOnMedian [|1; 2; 3; 4;|] |> should equal 4
    CountComp.count CountComp.pivotOnMedian [|9; 6; 3; 7; 2; 4|] |> should equal 8
    CountComp.count CountComp.pivotOnMedian [|9; 6; 3; 7; 4; 2|] |> should equal 9

[<Fact>]
let countPivotOnMedian2() =
    CountComp.count CountComp.pivotOnMedian [|0; 9; 8; 7; 6; 5; 4; 3; 2; 1|] |> should equal 25
    CountComp.count CountComp.pivotOnMedian [|0; 1; 2; 3; 4; 5; 6; 7; 8; 9|] |> should equal 19
    CountComp.count CountComp.pivotOnMedian [|1; 11; 5; 15; 2; 12; 9; 99; 77; 0|] |> should equal 22
    CountComp.count CountComp.pivotOnMedian [|999;3;2;98;765;8;14;15;16;88;145;100|] |> should equal 29
    CountComp.count CountComp.pivotOnMedian [|1;11;5;15;2;999;3;2;98;765;8;14;15;16;88;145;100;12;9;99;77;0|] |> should equal 82

open FsCheck

[<Property>]
let ``Increased integer arrays have maximum number of comparison`` (xs: int []) =
    let xs' = Array.sort xs
    let n = Array.length xs'
    CountComp.count CountComp.pivotOnFirst xs' = n*(n-1)/2

let strictlyDecreased = function 
    | [||] -> false
    | [|_|] -> true
    | xs -> Seq.forall (fun i -> xs.[i] > xs.[i+1]) {0..Array.length xs - 2}

[<Property>]
let ``Strictly Decreased integer arrays have maximum number of comparison`` (xs: int []) =
    let xs' = Array.sortBy (~-) xs
    let n = Array.length xs'
    strictlyDecreased xs' ==> (CountComp.count CountComp.pivotOnLast xs' = n*(n-1)/2)
