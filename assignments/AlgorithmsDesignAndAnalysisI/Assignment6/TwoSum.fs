module TwoSum

open System.Collections.Generic

// There is no need for a hashtable. A hastable with generic key has terrible performance.

/// Check whether there are pairs x, y so that x + y = t and x <> y
let exists t arr (dic: HashSet<_>) =
    let len = Array.length arr
    let rec loop i =
        i < len && ((t <> 2*arr.[i] && dic.Contains (t-arr.[i])) || loop (i+1))
    loop 0

/// Let t run from a to b, count number of two-sum
let countRange a b arr =
    let dic = HashSet()
    Array.iter (dic.Add >> ignore) arr
    let mutable count = 0
    for t in a..b do
        if exists t arr dic then
            count <- count + 1
    count

