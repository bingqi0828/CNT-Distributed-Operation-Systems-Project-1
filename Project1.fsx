open System
open Akka.Actor
open Akka.Configuration
open Akka.FSharp
open Akka.TestKit

let system = ActorSystem.Create("FSharp")

let n = int(fsi.CommandLineArgs |> Seq.item 1)
let k = int(fsi.CommandLineArgs |> Seq.item 2)
let work_unit=10000
let num_actor=n/work_unit  //number of actors

let WorkerCalculation (actorNum:int) (k:int)=
   // function body
   for x = 1 to work_unit do
        let upperLimit=(actorNum-1)*work_unit+x+k-1
        let lowerLimit =(actorNum-1)*work_unit+x-1
        let sum1=float((upperLimit*(upperLimit+1)*((2*upperLimit)+1)))/6.0
        let sum2=float((lowerLimit*(lowerLimit+1)*((2*lowerLimit)+1)))/6.0
        let sN=sum1-sum2
        let perfectsquare=Math.Sqrt sN
        let floor=floor perfectsquare
        if (perfectsquare=floor) then
            printfn "%d" ((actorNum-1)*work_unit+x)
        else
            ()

type EchoServer(name) =
    inherit Actor()

    override x.OnReceive message =

        match message with
        | :? int as msg -> WorkerCalculation msg k
        | _ ->  failwith "unknown message"

let echoServers = 
    [1 .. num_actor]
    |> List.map(fun id ->   let pro = [| string(id) :> obj |]
                            system.ActorOf(Props(typedefof<EchoServer>, pro)))

let rand = Random(1234)

for id = 1 to num_actor do
    (rand.Next() % num_actor) |> List.nth echoServers <! id

system.Shutdown()