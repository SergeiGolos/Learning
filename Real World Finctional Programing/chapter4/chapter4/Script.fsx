// Learn more about F# at http://fsharp.net. See the 'F# Tutorial' project
// for more guidance on F# programming.

#load "Library1.fs"
open chapter4


// Define your library scripting code here

let convertDataRow(item:string) =
    match List.ofSeq(item.Split(',')) with
    | title::value::_ -> (title, System.Int32.Parse(value))
    | _ -> raise( new System.Exception("Incorect format"))