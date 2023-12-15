module Program

open System
open System.IO
open FSharp.Formatting.Literate
open FSharp.Formatting.Literate.Evaluation

open DotLiquid

// Sample literate content
let content =
    """
(**
# Here is some markdown - H1

> Here is a block quote

This is some text.

And here is some math!
$$ x = 1 $$

*)

let square x = x * x

// Now square a value - 5
square 5
(*** include-it ***)

"""

let render path litterate =

    let fsi = FsiEvaluator()

    let doc = Literate.ParseScriptString(litterate, fsiEvaluator = fsi)

    let body = Literate.ToHtml(doc)

    let templateString = File.ReadAllText(path)
    let template = Template.Parse(templateString)

    Hash.FromAnonymousObject({| main = body |}) |> template.Render

let renderToHtml templateDir fileName =

    let join p1 p2 = [| p2; p1 |] |> Path.Join
    
    let outputPath = __SOURCE_DIRECTORY__ |> join templateDir

    let filePath = outputPath |> join fileName

    let template = templateDir |> join "template.html"

    let html = content |> render template
    File.WriteAllText(filePath, html)

renderToHtml "build" "index.html"
printfn "Done"
