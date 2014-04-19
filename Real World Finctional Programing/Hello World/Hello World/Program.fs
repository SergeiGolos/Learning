// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.

[<EntryPoint>]
let main argv =  
    let great = 
        let message = "Hello World!"
        printfn "%s" message 
    great
    0 // return an integer exit code

