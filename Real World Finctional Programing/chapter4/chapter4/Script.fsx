// Learn more about F# at http://fsharp.net. See the 'F# Tutorial' project
// for more guidance on F# programming.
open System
open System.Drawing
open System.Windows.Forms

// Define your library scripting code here
let data = ["Asia, 3634"; "Australia/Oceania, 30"; "Africa, 767"; "South America, 511"; "Europe, 729"; "North America, 307"]
let convertDataRow(item:string) =
    match List.ofSeq(item.Split(',')) with
    | title::value::_ -> (title.Trim(), float(value.Trim()))
    | _ -> raise( new System.Exception("Incorect format"))

let convertData data =         
    let rows = List.map convertDataRow data            
    let sum = List.sumBy(fun (_, value) -> value) rows
    List.map(fun (name, population) -> (name, population, int(population / sum * 360.0))) rows

let rows = convertData data

let convertFile fileName = 
    let data = List.ofSeq(System.IO.File.ReadAllLines(fileName));        
    convertData data

let data1900 = convertFile("C:\Users\serge_000\Documents\GitHub\Learning\Real World Finctional Programing\chapter4\chapter4\population_1900.csv")
let data2000 = convertFile("C:\Users\serge_000\Documents\GitHub\Learning\Real World Finctional Programing\chapter4\chapter4\population_2000.csv")

let rnd = new Random()
let randomBrush = 
    let r, g, b = rnd.Next(256), rnd.Next(256), rnd.Next(256)
    (new SolidBrush(Color.FromArgb(r,g,b)))

let drawPieSegment(gr:Graphics, title:string, startAngle , sweepAngle) = 
    let br = randomBrush
    
    Console.WriteLine(startAngle.ToString() + " : " + sweepAngle.ToString())    
    gr.FillPie(br, 170, 70, 260, 260, startAngle, sweepAngle)    
    br.Dispose();

let pieChart = new Bitmap(600,400)
let gr = Graphics.FromImage(pieChart)

let rec drawGraphData gr data start =     
    match data with    
    | ((name, _, angle)::tail) ->                 
        let endAngle = start + angle
        drawPieSegment(gr, name, start, endAngle)
        drawGraphData gr tail endAngle
    | [] -> ()        

drawGraphData gr rows 0


let boxChart = new PictureBox (BackColor = Color.White, Dock = DockStyle.Fill, SizeMode = PictureBoxSizeMode.CenterImage)
let main = new Form(Width = 620, Height = 450, Text = "Pie Chart")
let menu = new ToolStrip()
let btnOpen = new ToolStripButton("Open")
let btnSave = new ToolStripButton("Save", Enabled = false)
ignore(menu.Items.Add(btnOpen))
ignore(menu.Items.Add(btnSave))
main.Controls.Add(menu)
main.Controls.Add(boxChart)
boxChart.Image <- pieChart
main.ShowDialog()