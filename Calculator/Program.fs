open System
open System.IO
open System.Collections
open System.Collections.Generic
open System.Text.RegularExpressions

let finCal = new ArrayList()
let historyA = new ArrayList()


//Need to implement BODMAS with bracket support 
//Need to implement parallel


let fileMathChoose() =
    Console.Write("Enter the path of your .txt file: ")
    let file = Console.ReadLine()
    let mutable output = ""

    if Directory.Exists(file) then
        //Get text file
        let inputFile = File.ReadAllLines(file)


        let math = new List<string>()
        let numbers = new List<int>()
    
        //Read lines in file
        for line in inputFile do
            math.Clear
            numbers.Clear


            let mathSymbol = Regex.Replace(line, @"\d", "").Trim() //replace numbers with letters (the operation)
        
            //STORE THE SYMBOL IN THE LIST (STRINGS)
            for mathS in mathSymbol do

                match mathS.ToString() with
                | "+" -> math.Add(mathS.ToString())
                | "-" -> math.Add(mathS.ToString())
                | "*" -> math.Add(mathS.ToString())
                | "/" -> math.Add(mathS.ToString())
    

            //STORE THE NUMBER IN THE NUMBERS LIST (INTERGERS)

            let number = Regex.Matches(line, @"\d+") //Matches input with numbers same a 0-9

            for num in number do
                numbers.Add(int num.Value)



            let operation = math.[0].ToString()

            //Calculate first two numbers
            match operation with
            | "+" ->    let result = numbers.[0] + numbers.[1]
                        ignore(numbers.[0] <- result)
                        ignore(numbers.Remove(numbers.[1]))
                        ()
            | "-" ->    let result = numbers.[0] - numbers.[1]
                        ignore(numbers.[0] <- result)
                        ignore(numbers.Remove(numbers.[1]))
                        ()
            | "/" ->    let result = numbers.[0] / numbers.[1]
                        ignore(numbers.[0] <- result)
                        ignore(numbers.Remove(numbers.[1]))
                        ()
            | "*" ->    let result = numbers.[0] * numbers.[1]
                        ignore(numbers.[0] <- result)
                        ignore(numbers.Remove(numbers.[1]))
                        ()

            //Calculate multiple

            let mutable position = 1

            while numbers.Count <>  1 do
                match math.[position] with
                | "+" ->    let result = numbers.[0] + numbers.[1]
                            ignore(numbers.[0] <- result)
                            ignore(numbers.Remove(numbers.[1]))
                            ()
                | "-" ->    let result = numbers.[0] - numbers.[1]
                            ignore(numbers.[0] <- result)
                            ignore(numbers.Remove(numbers.[1]))
                            ()
                | "/" ->    let result = numbers.[0] / numbers.[1]
                            ignore(numbers.[0] <- result)
                            ignore(numbers.Remove(numbers.[1]))
                            ()
                | "*" ->    let result = numbers.[0] * numbers.[1]
                            ignore(numbers.[0] <- result)
                            ignore(numbers.Remove(numbers.[1]))
                            ()
                position <- position + 1
        
        
            output <- output + "\n" + line + "=" + numbers.[numbers.Count-1].ToString()

            ignore(historyA.Add(line + "=" + numbers.[numbers.Count-1].ToString()))
        
            numbers.Clear()
            math.Clear()

    
        printfn "%s" output
    else
        output <- "Path does not exist"
        printfn "%s" output

let fileMathDefault() =

    //Get text file
    let inputFile = File.ReadAllLines("sums.txt")

    let mutable output = ""
    

    let math = new List<string>()
    let numbers = new List<int>()
    
    //Read lines in file
    for line in inputFile do
        math.Clear
        numbers.Clear


        let mathSymbol = Regex.Replace(line, @"\d", "").Trim() //replace numbers with letters (the operation)
        
        //STORE THE SYMBOL IN THE LIST (STRINGS)
        for mathS in mathSymbol do

            match mathS.ToString() with
            | "+" -> math.Add(mathS.ToString())
            | "-" -> math.Add(mathS.ToString())
            | "*" -> math.Add(mathS.ToString())
            | "/" -> math.Add(mathS.ToString())
    

        //STORE THE NUMBER IN THE NUMBERS LIST (INTERGERS)

        let number = Regex.Matches(line, @"\d+") //Matches input with numbers same a 0-9

        for num in number do
            numbers.Add(int num.Value)



        let operation = math.[0].ToString()

        //Calculate first two numbers
        match operation with
        | "+" ->    let result = numbers.[0] + numbers.[1]
                    ignore(numbers.[0] <- result)
                    ignore(numbers.Remove(numbers.[1]))
                    ()
        | "-" ->    let result = numbers.[0] - numbers.[1]
                    ignore(numbers.[0] <- result)
                    ignore(numbers.Remove(numbers.[1]))
                    ()
        | "/" ->    let result = numbers.[0] / numbers.[1]
                    ignore(numbers.[0] <- result)
                    ignore(numbers.Remove(numbers.[1]))
                    ()
        | "*" ->    let result = numbers.[0] * numbers.[1]
                    ignore(numbers.[0] <- result)
                    ignore(numbers.Remove(numbers.[1]))
                    ()

        //Calculate multiple

        let mutable position = 1

        while numbers.Count <>  1 do
            match math.[position] with
            | "+" ->    let result = numbers.[0] + numbers.[1]
                        ignore(numbers.[0] <- result)
                        ignore(numbers.Remove(numbers.[1]))
                        ()
            | "-" ->    let result = numbers.[0] - numbers.[1]
                        ignore(numbers.[0] <- result)
                        ignore(numbers.Remove(numbers.[1]))
                        ()
            | "/" ->    let result = numbers.[0] / numbers.[1]
                        ignore(numbers.[0] <- result)
                        ignore(numbers.Remove(numbers.[1]))
                        ()
            | "*" ->    let result = numbers.[0] * numbers.[1]
                        ignore(numbers.[0] <- result)
                        ignore(numbers.Remove(numbers.[1]))
                        ()
            position <- position + 1
        
        
        output <- output + "\n" + line + "=" + numbers.[numbers.Count-1].ToString()

        ignore(historyA.Add(line + "=" + numbers.[numbers.Count-1].ToString()))
        
        numbers.Clear()
        math.Clear()

    
    printfn "%s" output

let menuFile() =
    Console.WriteLine("1:\tUse default .txt file\n2:\tChoose own")
    let input = Console.ReadLine()

    match input with
            | "1" -> fileMathDefault()
            | "2" -> fileMathChoose()


let calculator() =
    let mutable output = ""

    let math = new List<string>()
    let numbers = new List<int>()

    Console.Write ("Enter your equation: ")
    let equa = Console.ReadLine()


    //REPLACE AND MATCH
    let mathSymbol = Regex.Replace(equa, @"\d+", "").Trim() //replaces any numbers 0-9 with nothing ("")
    
    //STORE THE SYMBOL IN THE LIST (STRINGS)
    for mathS in mathSymbol do

        match mathS.ToString() with
        | "+" -> math.Add(mathS.ToString())
        | "-" -> math.Add(mathS.ToString())
        | "*" -> math.Add(mathS.ToString())
        | "/" -> math.Add(mathS.ToString())
    

    //STORE THE NUMBER IN THE NUMBERS LIST (INTERGERS)
    let number = Regex.Matches(equa, @"\d+")
    for num in number do

        numbers.Add(int num.Value)



    let operation = math.[0].ToString()

    //Calculate first two numbers
    match operation with
    | "+" ->    let result = numbers.[0] + numbers.[1]
                ignore(numbers.[0] <- result)
                ignore(numbers.Remove(numbers.[1]))
                ()
    | "-" ->    let result = numbers.[0] - numbers.[1]
                ignore(numbers.[0] <- result)
                ignore(numbers.Remove(numbers.[1]))
                ()
    | "/" ->    let result = numbers.[0] / numbers.[1]
                ignore(numbers.[0] <- result)
                ignore(numbers.Remove(numbers.[1]))
                ()
    | "*" ->    let result = numbers.[0] * numbers.[1]
                ignore(numbers.[0] <- result)
                ignore(numbers.Remove(numbers.[1]))
                ()

    //Calculate multiple

    let mutable position = 1

    while numbers.Count <>  1 do
        match math.[position] with
        | "+" ->    let result = numbers.[0] + numbers.[1]
                    ignore(numbers.[0] <- result)
                    ignore(numbers.Remove(numbers.[1]))
                    ()
        | "-" ->    let result = numbers.[0] - numbers.[1]
                    ignore(numbers.[0] <- result)
                    ignore(numbers.Remove(numbers.[1]))
                    ()
        | "/" ->    let result = numbers.[0] / numbers.[1]
                    ignore(numbers.[0] <- result)
                    ignore(numbers.Remove(numbers.[1]))
                    ()
        | "*" ->    let result = numbers.[0] * numbers.[1]
                    ignore(numbers.[0] <- result)
                    ignore(numbers.Remove(numbers.[1]))
                    ()
        position <- position + 1
        

    output <- equa + "=" + numbers.[numbers.Count-1].ToString()

    ignore(historyA.Add(output))
        
    
    printfn "%s" output

//GET HISTORY
let history() = 
    let mutable output = ""

    //ITERATE THROUGH HISTORY AND PRINT
    for item in historyA do
        output <- output + "\n" + string item

    //CHECK IS HISTORY CONTAINS ANYTHING
    if historyA.Count.Equals(0) then
        output <- "No History"
        
    printfn "%s" output



//MAIN CODE
[<EntryPoint>]
let main argv = 
    Console.Write ("Advanced Calculator")
    let mutable loop = true

    //MENU
    while loop do
        Console.Write ("\n\n----------Menu------------\n\n 1:\tMain Calculator\n 2:\tAnswer File\n 3:\tHistory\n 4:\tExit\n\n--------------------------\n\nInput: ")
    
        let uInput = Console.ReadLine().ToUpper()

        //PATTERN MATCH
        match uInput with
        |  "1" ->   Console.WriteLine("\n----Calculator----\n")
                    calculator()
        |  "2" ->   Console.WriteLine("\n----Reading File----\n")
                    menuFile()
        |  "3" ->   Console.WriteLine("\n----History----\n")
                    history()
        |  "4" ->
            loop <- false
            printfn("Ended")
        | _ -> printfn("Your selection was invalid")

    ignore(Console.ReadKey())
    0 // return an integer exit code

 