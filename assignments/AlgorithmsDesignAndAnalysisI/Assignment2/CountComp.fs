module CountComp

let swap (arr: _ []) i j =
    let temp = arr.[j]
    arr.[j] <- arr.[i]
    arr.[i] <- temp

/// Assume the pivot is the first element
let partition (arr: _ []) l r =
    let p = arr.[l]
    let mutable i = l+1
    for j in l+1..r do
        if arr.[j] < p then
            swap arr i j
            i <- i+1
    swap arr l (i-1)
    i-1

let rec countQS pivotFn arr l r c =
    if l < r then 
        pivotFn arr l r
        let i = partition arr l r
        let c' = countQS pivotFn arr l (i-1) (c+i-l)
        countQS pivotFn arr (i+1) r (c'+r-i) 
    else c

let count pivotFn arr =
    let arr' = Array.copy arr
    countQS pivotFn arr' 0 (arr'.Length-1) 0 // The range is integer for this input.

let pivotOnFirst (arr: _ []) l r = ()
let pivotOnLast (arr: _ []) l r = swap arr l r
let pivotOnMedian (arr: _ []) l r = 
    let m = (l+r)/2
    let median = arr.[l] + arr.[m] + arr.[r] - min arr.[l] (min arr.[m] arr.[r]) - max arr.[l] (max arr.[m] arr.[r])
    if arr.[m] = median then swap arr l m
    elif arr.[r] = median then swap arr l r

let rec qsort pivotFn arr l r =
    if l < r then 
        pivotFn arr l r
        let i = partition arr l r
        qsort pivotFn arr l (i-1)
        qsort pivotFn arr (i+1) r

let sort pivotFn arr =
    let arr' = Array.copy arr
    qsort pivotFn arr' 0 (arr'.Length-1)
    arr'


    
