// Learn more about F# at http://fsharp.net. See the 'F# Tutorial' project
// for more guidance on F# programming.

#load "Library1.fs"
open Chapter_Examples

// Define your library scripting code here
let printCity (cityInfo) = 
    printfn "The puplation of %s is %d" (fst cityInfo) (snd cityInfo)

let shelton = ("Shelton", 1000)
printCity shelton

// invalid code float going into int
//let newyork = ("New York", 23123123.2)
//printCity newyork
    
// Pattern matching on tuples
let newCityPopulation value (item1, _) = (item1, value)
let sheltonNew = newCityPopulation 10000000 shelton
printCity sheltonNew


// Example of pattern matching in F#
let increaseSheltonOnly tuple = 
    match tuple with
    | ("Shelton", value) -> ("Shelton", value + 100)
    | (city,value) -> (city, value)

printCity (increaseSheltonOnly ("Shelton", 100))
printCity (increaseSheltonOnly ("Derby", 100))

// Factorial 

let rec getfactorial num = 
    match num with
    | 1 -> 1
    | _ -> num * getfactorial(num - 1)
getfactorial 4
getfactorial 10


//Lists
let lista = []
let listb = 6::5::4::3::[]
let listc = [1;3;4;3]
let listd = [1 .. 5]
let liste = 0::listd


let rec printList list = 
    match list with
    | [] -> printfn "Done"
    | head::tail -> 
        printfn "%d" head
        printList tail

printList [1..5]

let rec sumList list = 
    match list with 
    | [] -> 0
    | head::tail -> head + sumList tail
sumList [1..10]


let rec aggragateList list func dflt = 
    match list with 
    | [] -> dflt
    | head::tail -> func head (aggragateList tail func dflt)

let mult a b = a * b
let add  a b = a + b
aggragateList [1..5] mult 1
aggragateList [1..5] add 0

aggragateList [1..5] (*) 1
aggragateList [1..5] (+) 0


aggragateList [1..5] max -1

