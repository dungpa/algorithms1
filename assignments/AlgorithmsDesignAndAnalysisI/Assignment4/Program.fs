module Program

open System.Threading

open System
open System.IO

open Graph

let sw = new System.Diagnostics.Stopwatch()

let time fn x =
    sw.Restart()
    let res = fn x
    sw.Stop()
    printfn "Time taken: %f s" ((float sw.ElapsedMilliseconds)/1000.0)
    res

let sccFromFile n f =
    f |> File.ReadLines
      |> Seq.map (fun s -> let arr = s.Split ([|' '; '\t';|], StringSplitOptions.RemoveEmptyEntries) |> Array.map Convert.ToInt32
                           arr.[0]-1, arr.[1]-1)
      |> calculateSCC n

let benchmarks() = @"..\..\SCC.txt" |> sccFromFile 875714 |> Seq.take 5 |> Seq.iter (printfn "Result = %i")

let main() =
    let thread = new Thread(time benchmarks, 50000000) // Stack size in byte
    thread.Start()
    thread.Join() // thread finishes    
    Console.ReadKey() |> ignore

do main()

