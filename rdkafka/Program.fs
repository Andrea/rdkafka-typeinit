// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

open System
open System.Text
open RdKafka


[<EntryPoint>]
let main argv = 
    use p  = new Producer("127.0.0.1:2181")
    use topic = p.Topic("Bla")
    let datak = Encoding.UTF8.GetBytes("Hello RdKafka")
    let result = 
        async {
            let! deliveryReport = topic.Produce datak |> Async.AwaitTask
            printfn "Produced to Partition: %i, Offset: %i" deliveryReport.Partition deliveryReport.Offset
            return deliveryReport
            }
    0 