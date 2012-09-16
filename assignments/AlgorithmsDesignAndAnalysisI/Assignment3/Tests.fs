module Tests

open System

open Xunit
open FsUnit.Xunit

let minCutFromString (s: string) =
    s.Split ([|'\n'|], StringSplitOptions.RemoveEmptyEntries)
    |> Array.map (fun s -> let arr = s.Split ([|' '; '\t';|], StringSplitOptions.RemoveEmptyEntries) |> Array.map Convert.ToInt32
                           arr.[0], arr.[1..])
    |> MinCut.minCutTest

[<Fact>]
let test1() =
    "1\t2\t3\n2\t1\t3\t4\t5\n3\t1\t2\t5\n4\t2\t5\t6\n5\t3\t4\t6\t2\n6\t4\t5\n"
    |> minCutFromString
    |> should equal 2

[<Fact>]
let test2() =
    "1\t2\t3\t4\n2\t1\t3\t4\n3\t1\t2\t4\n4\t1\t2\t3\n"
    |> minCutFromString
    |> should equal 3

[<Fact>]
let test3() =
    "1\t2\t3\n2\t1\t4\n3\t1\t4\n4\t2\t3\n"
    |> minCutFromString
    |> should equal 2

[<Fact>]
let test4() =
    "1\t2\t3\t7\n2\t1\t3\t4\t5\t7\n3\t1\t2\t5\t7\n4\t2\t5\t6\t7\n5\t3\t4\t6\t2\t7\n6\t4\t5\t7\n7\t1\t2\t3\t4\t5\t6\n"
    |> minCutFromString
    |> should equal 3

[<Fact>]
let test5() =
    "1\t2\t3\t4\n2\t1\t4\t5\t8\n3\t1\t4\t6\n4\t1\t2\t3\t5\t6\t7\t8\t10\n5\t2\t4\t8\n6\t3\t4\t9\t10\n7\t4\t8\t10\n8\t2\t5\t4\t7\t10\t11\t12\n9\t6\t10\t12\n10\t4\t6\t7\t8\t9\t11\t12\n11\t8\t10\t12\n12\t8\t9\t10\t11\n"
    |> minCutFromString
    |> should equal 3
            
[<Fact>]
let test6() =
    "1\t2\t3\t4\n2\t1\t4\t5\t8\n3\t1\t4\t6\n4\t1\t2\t3\t5\t6\t7\t8\t10\n5\t2\t4\t8\n6\t3\t4\t9\t10\n7\t4\t8\t10\n8\t2\t5\t4\t7\t10\t11\t12\t13\n9\t6\t10\t12\n10\t4\t6\t7\t8\t9\t11\t12\n11\t8\t10\t12\n12\t8\t9\t11\t10\n13\t14\t16\t17\t19\t21\t22\t8\n14\t13\t15\t16\t18\t20\n15\t14\t16\t17\t18\n16\t13\t14\t15\t17\n17\t15\t16\t13\t19\t18\n18\t14\t15\t17\t19\t23\n19\t13\t17\t18\t20\t21\n20\t14\t19\t21\t23\n21\t13\t19\t20\t22\t23\n22\t13\t21\t23\n23\t18\t20\t21\t22\n"
    |> minCutFromString
    |> should equal 1
