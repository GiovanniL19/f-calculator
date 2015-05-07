open System
open System.IO

let fileMath =
    use inputFile = File.OpenText("sums.txt")
    let line = inputFile.ReadLine()
    let mutable output = ""

    if line.Contains("+") then
        let split = line.Split[|'+'|]
        let num1 = System.Int32.Parse(Array.get split 0)
        let num2 = System.Int32.Parse(Array.get split 1)
        let total = num1 + num2 
        output <- line + " = " + total.ToString()
    else if line.Contains("-") then
        let split = line.Split[|'-'|]
        let num1 = System.Int32.Parse(Array.get split 0)
        let num2 = System.Int32.Parse(Array.get split 1)
        let total = num1 - num2 
        output <- line + " = " + total.ToString()
     else if line.Contains("*") then
        let split = line.Split[|'*'|]
        let num1 = System.Int32.Parse(Array.get split 0)
        let num2 = System.Int32.Parse(Array.get split 1)
        let total = num1 * num2 
        output <- line + " = " + total.ToString()
     else if line.Contains("/") then
        let split = line.Split[|'/'|]
        let num1 = System.Int32.Parse(Array.get split 0)
        let num2 = System.Int32.Parse(Array.get split 1)
        let total = num1 / num2 
        output <- line + " = " + total.ToString()
    output

let calculator =
    Console.Write("Please enter your calculation: ")
    Console.ReadLine()

[<EntryPoint>]


let main argv = 
    Console.Write ("Advanced Calculator")
    let mutable loop = true

    while loop do
        Console.Write ("\n\n----------Menu------------\n\n A:\tAnswer File\nC:\tMain Calculator\n E:\tExit\n\n--------------------------\n\nInput: ")
    
        let uInput = Console.ReadLine().ToUpper()

        match uInput with
        |  "A" -> printfn "%s" fileMath
        |  "C" -> calculator
        |  "E" -> 
            loop <- false
            printfn("Ended")
        | _ -> printfn("Your selection was invalid")

    ignore(Console.ReadKey())
    0 // return an integer exit code

 